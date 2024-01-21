using System;
using System.Linq;
using System.Threading.Tasks;
using DiffMatchPatch;
using Microsoft.Office.Interop.Excel;

namespace CapybaraTranslateAddin.Utilities
{
    public static class Diff
    {
        public static async Task RunOnSelectedCells(Action<int> onProgress = null)
        {
            var dmp = new diff_match_patch();
            Range selection = Globals.ThisAddIn.Application.Selection;
            var progress = 0;
            foreach (var cells in selection.ToList().Chunk(10))
            {
                var tasks = cells.Select(cell1 =>
                {
                    return Task.Run(() =>
                    {
                        string text1 = cell1.Text ?? "";
                        Range cell2 = cell1.Offset[0, 1];
                        string text2 = cell2.Text ?? "";
                        if (!string.IsNullOrWhiteSpace(text1) || !string.IsNullOrWhiteSpace(text2))
                        {
                            var idx1 = 1;
                            var idx2 = 1;
                            var diffs = dmp.diff_main(text1, text2);
                            dmp.diff_cleanupSemantic(diffs);
                            diffs.ForEach(diff =>
                            {
                                if (diff.operation == Operation.INSERT)
                                {
                                    cell2.Characters[idx2, diff.text.Length].Font.ColorIndex = 5;
                                    cell2.Characters[idx2, diff.text.Length].Font.Underline =
                                        XlUnderlineStyle.xlUnderlineStyleSingle;
                                    idx2 += diff.text.Length;
                                }
                                else if (diff.operation == Operation.DELETE)
                                {
                                    cell1.Characters[idx1, diff.text.Length].Font.ColorIndex = 3;
                                    cell1.Characters[idx1, diff.text.Length].Font.Strikethrough = true;
                                    idx1 += diff.text.Length;
                                }
                                else
                                {
                                    idx1 += diff.text.Length;
                                    idx2 += diff.text.Length;
                                }
                            });
                        }


                        onProgress?.Invoke(++progress);
                    });

                });

                await Task.WhenAll(tasks);

            }

        }
        
    }
}