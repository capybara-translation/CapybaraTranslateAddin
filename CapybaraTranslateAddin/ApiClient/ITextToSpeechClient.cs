using System.Threading.Tasks;

namespace CapybaraTranslateAddin.ApiClient
{
    public interface ITextToSpeechClient
    {
        Task<bool> TextToSpeechAsync(string text, string voiceName, string destination);
    }
}