using System.Threading.Tasks;

namespace CapybaraTranslateAddin.ApiClient
{
    public interface ITranslationClient
    {
        Task<string> TranslateAsync(string text, string from, string to);
    }
}