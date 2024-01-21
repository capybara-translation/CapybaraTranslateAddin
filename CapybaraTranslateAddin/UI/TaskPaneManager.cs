using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Office.Tools;

namespace CapybaraTranslateAddin.UI
{
    // Adapted from https://stackoverflow.com/a/24732000
    public static class TaskPaneManager
    {
        private static readonly Dictionary<string, CustomTaskPane> _createdPanes =
            new Dictionary<string, CustomTaskPane>();

        /// <summary>
        ///     Gets the taskpane by name (if exists for current excel window then returns existing instance, otherwise uses
        ///     taskPaneCreatorFunc to create one).
        /// </summary>
        /// <param name="taskPaneTitle">Display title of the taskpane</param>
        /// <param name="taskPaneCreatorFunc">
        ///     The function that will construct the taskpane if one does not already exist in the
        ///     current Excel window.
        /// </param>
        public static CustomTaskPane GetOrCreate(string taskPaneTitle, string prefix,
            Func<UserControl> taskPaneCreatorFunc)
        {
            var key = $"{prefix}_{Globals.ThisAddIn.Application.Hwnd}";
            if (!_createdPanes.ContainsKey(key))
            {
                var taskPaneControl = taskPaneCreatorFunc();
                var width = taskPaneControl.Width;
                var pane = Globals.ThisAddIn.CustomTaskPanes.Add(taskPaneCreatorFunc(), taskPaneTitle);
                var margin = taskPaneControl.Margin.Horizontal + 8;
                pane.Width = width + margin;
                _createdPanes[key] = pane;
            }

            return _createdPanes[key];
        }
    }
}