using System.ComponentModel;
using CapybaraTranslateAddin.ApiClient;
using Newtonsoft.Json;

namespace CapybaraTranslateAddin.Configuration
{
    public class GoogleConfiguration
    {
        public GoogleConfiguration()
        {
            Credentials = "";
            LastSelectedSourceLanguage = GoogleClient.DefaultSourceLanguage;
            LastSelectedTargetLanguage = GoogleClient.DefaultTargetLanguage;
            LastSelectedVoiceName = GoogleClient.DefaultTtsVoiceName;
            LastSelectedSoundFolder = "";
            LastSelectedFilenameColumn = "";
        }

        [DefaultValue("")]
        [JsonProperty("credentials", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string Credentials { get; set; }


        [DefaultValue(GoogleClient.DefaultSourceLanguage)]
        [JsonProperty("last_selected_src_lang", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LastSelectedSourceLanguage { get; set; }

        [DefaultValue(GoogleClient.DefaultTargetLanguage)]
        [JsonProperty("last_selected_tgt_lang", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LastSelectedTargetLanguage { get; set; }

        [DefaultValue(GoogleClient.DefaultTtsVoiceName)]
        [JsonProperty("last_selected_voice_name", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LastSelectedVoiceName { get; set; }

        [DefaultValue("")]
        [JsonProperty("last_selected_sound_folder", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LastSelectedSoundFolder { get; set; }

        [DefaultValue("")]
        [JsonProperty("last_selected_filename_column", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LastSelectedFilenameColumn { get; set; }
    }
}