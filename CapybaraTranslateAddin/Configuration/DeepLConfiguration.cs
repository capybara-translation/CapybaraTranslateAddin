using System.ComponentModel;
using CapybaraTranslateAddin.ApiClient;
using Newtonsoft.Json;

namespace CapybaraTranslateAddin.Configuration
{
    public class DeepLConfiguration
    {
        public DeepLConfiguration()
        {
            ApiKey = "";
            LastSelectedSourceLanguage = DeepLClient.DefaultSourceLanguage;
            LastSelectedTargetLanguage = DeepLClient.DefaultTargetLanguage;
        }

        [DefaultValue("")]
        [JsonProperty("api_key", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ApiKey { get; set; }

        [DefaultValue(DeepLClient.DefaultSourceLanguage)]
        [JsonProperty("last_selected_src_lang", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LastSelectedSourceLanguage { get; set; }

        [DefaultValue(DeepLClient.DefaultTargetLanguage)]
        [JsonProperty("last_selected_tgt_lang", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LastSelectedTargetLanguage { get; set; }
    }
}