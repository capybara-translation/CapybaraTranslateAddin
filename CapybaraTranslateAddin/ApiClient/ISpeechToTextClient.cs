using System.Threading.Tasks;

namespace CapybaraTranslateAddin.ApiClient
{
    public interface ISpeechToTextClient
    {

        Task<string> SpeechToTextAsync(string mp3File, string languageCode);
    }
}