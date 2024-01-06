using System.ComponentModel;
using CapybaraTranslateAddin.ApiClient;
using Newtonsoft.Json;

namespace CapybaraTranslateAddin.Configuration
{
    public class OpenAiConfiguration
    {
        public OpenAiConfiguration()
        {
            ApiKey = "";
            LastSelectedSourceLanguage = OpenAiClient.DefaultSourceLanguage;
            LastSelectedTargetLanguage = OpenAiClient.DefaultTargetLanguage;
        }

        [DefaultValue("")]
        [JsonProperty("api_key", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ApiKey { get; set; }

        [DefaultValue(OpenAiClient.DefaultSourceLanguage)]
        [JsonProperty("last_selected_src_lang", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LastSelectedSourceLanguage { get; set; }

        [DefaultValue(OpenAiClient.DefaultTargetLanguage)]
        [JsonProperty("last_selected_tgt_lang", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LastSelectedTargetLanguage { get; set; }
    }
}