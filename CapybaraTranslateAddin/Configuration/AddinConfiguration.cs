using System.ComponentModel;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace CapybaraTranslateAddin.Configuration
{
    public class AddinConfiguration
    {
        private DeepLConfiguration _deepL;
        private GoogleConfiguration _google;
        private OpenAiConfiguration _openAi;

        [JsonProperty("deepl")]
        public DeepLConfiguration DeepL
        {
            get => _deepL ?? (_deepL = new DeepLConfiguration());
            set => _deepL = value;
        }

        [JsonProperty("openai")]
        public OpenAiConfiguration OpenAi
        {
            get => _openAi ?? (_openAi = new OpenAiConfiguration());
            set => _openAi = value;
        }

        [JsonProperty("google")]
        public GoogleConfiguration Google
        {
            get => _google ?? (_google = new GoogleConfiguration());
            set => _google = value;
        }

        [DefaultValue("deepl")]
        [JsonProperty("last_selected_engine", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string LastSelectedEngine { get; set; }


        public static AddinConfiguration LoadFrom(string configJson)
        {
            if (!File.Exists(configJson))
            {
                var configuration = new AddinConfiguration
                {
                    DeepL = new DeepLConfiguration(),
                    OpenAi = new OpenAiConfiguration(),
                    Google = new GoogleConfiguration()
                };
                return configuration;
            }

            try
            {
                using (var stream = new FileStream(configJson, FileMode.Open))
                using (var sr = new StreamReader(stream))
                {
                    var configuration = JsonConvert.DeserializeObject<AddinConfiguration>(sr.ReadToEnd());
                    return configuration ?? new AddinConfiguration
                    {
                        DeepL = new DeepLConfiguration(),
                        OpenAi = new OpenAiConfiguration(),
                        Google = new GoogleConfiguration()
                    };
                }
            }
            catch
            {
                var configuration = new AddinConfiguration
                {
                    DeepL = new DeepLConfiguration(),
                    OpenAi = new OpenAiConfiguration(),
                    Google = new GoogleConfiguration()
                };
                return configuration;
            }
        }


        public void SaveTo(string destination)
        {
            var folder = Path.GetDirectoryName(destination);
            if (!string.IsNullOrEmpty(folder)) Directory.CreateDirectory(folder);

            using (var sw = new StreamWriter(destination, false, Encoding.UTF8))
            {
                var jsonData = JsonConvert.SerializeObject(this, Formatting.Indented);
                sw.Write(jsonData);
            }
        }
    }
}