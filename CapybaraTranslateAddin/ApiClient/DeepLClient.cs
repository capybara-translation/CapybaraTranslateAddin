using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using RestSharp;

namespace CapybaraTranslateAddin.ApiClient
{
    public class DeepLClient : ITranslationClient
    {
        public const string DefaultSourceLanguage = "JA";
        public const string DefaultTargetLanguage = "EN-US";

        public const string EngineCode = "deepl";
        public const string EngineName = "DeepL";

        public static readonly List<Language> SupportedSourceLanguages =
            new List<Language>
            {
                new Language { Value = "BG", Label = "Bulgarian" },
                new Language { Value = "CS", Label = "Czech" },
                new Language { Value = "DA", Label = "Danish" },
                new Language { Value = "DE", Label = "German" },
                new Language { Value = "EL", Label = "Greek" },
                new Language { Value = "EN", Label = "English" },
                new Language { Value = "ES", Label = "Spanish" },
                new Language { Value = "ET", Label = "Estonian" },
                new Language { Value = "FI", Label = "Finnish" },
                new Language { Value = "FR", Label = "French" },
                new Language { Value = "HU", Label = "Hungarian" },
                new Language { Value = "ID", Label = "Indonesian" },
                new Language { Value = "IT", Label = "Italian" },
                new Language { Value = "JA", Label = "Japanese" },
                new Language { Value = "KO", Label = "Korean" },
                new Language { Value = "LT", Label = "Lithuanian" },
                new Language { Value = "LV", Label = "Latvian" },
                new Language { Value = "NB", Label = "Norwegian (Bokmål)" },
                new Language { Value = "NL", Label = "Dutch" },
                new Language { Value = "PL", Label = "Polish" },
                new Language { Value = "PT", Label = "Portuguese" },
                new Language { Value = "RO", Label = "Romanian" },
                new Language { Value = "RU", Label = "Russian" },
                new Language { Value = "SK", Label = "Slovak" },
                new Language { Value = "SL", Label = "Slovenian" },
                new Language { Value = "SV", Label = "Swedish" },
                new Language { Value = "TR", Label = "Turkish" },
                new Language { Value = "UK", Label = "Ukrainian" },
                new Language { Value = "ZH", Label = "Chinese" }
            };

        public static readonly List<Language> SupportedTargetLanguages =
            new List<Language>
            {
                new Language { Value = "BG", Label = "Bulgarian" },
                new Language { Value = "CS", Label = "Czech" },
                new Language { Value = "DA", Label = "Danish" },
                new Language { Value = "DE", Label = "German" },
                new Language { Value = "EL", Label = "Greek" },
                new Language { Value = "EN-GB", Label = "English (British)" },
                new Language { Value = "EN-US", Label = "English (American)" },
                new Language { Value = "ES", Label = "Spanish" },
                new Language { Value = "ET", Label = "Estonian" },
                new Language { Value = "FI", Label = "Finnish" },
                new Language { Value = "FR", Label = "French" },
                new Language { Value = "HU", Label = "Hungarian" },
                new Language { Value = "ID", Label = "Indonesian" },
                new Language { Value = "IT", Label = "Italian" },
                new Language { Value = "JA", Label = "Japanese" },
                new Language { Value = "KO", Label = "Korean" },
                new Language { Value = "LT", Label = "Lithuanian" },
                new Language { Value = "LV", Label = "Latvian" },
                new Language { Value = "NB", Label = "Norwegian (Bokmål)" },
                new Language { Value = "NL", Label = "Dutch" },
                new Language { Value = "PL", Label = "Polish" },
                new Language { Value = "PT-BR", Label = "Portuguese (Brazilian)" },
                new Language { Value = "PT-PT", Label = "Portuguese" },
                new Language { Value = "RO", Label = "Romanian" },
                new Language { Value = "RU", Label = "Russian" },
                new Language { Value = "SK", Label = "Slovak" },
                new Language { Value = "SL", Label = "Slovenian" },
                new Language { Value = "SV", Label = "Swedish" },
                new Language { Value = "TR", Label = "Turkish" },
                new Language { Value = "UK", Label = "Ukrainian" },
                new Language { Value = "ZH", Label = "Chinese (simplified)" }
            };

        private readonly RestClient _client;

        private readonly DeepLClientOptions _options;

        public DeepLClient(DeepLClientOptions options)
        {
            _options = options;
            _client = new RestClient("https://api.deepl.com/v2");
        }

        public async Task<string> TranslateAsync(string text, string from, string to)
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var request = new RestRequest("translate");
            request.AddHeader("Authorization", $"DeepL-Auth-Key {_options.ApiKey}");
            request.AddHeader("Content-Type", "application/json");
            var texts = new[] { text };
            var body = new { text = texts, source_lang = from, target_lang = to };
            request.AddJsonBody(body);
            var response = await _client.PostAsync<TranslationResult>(request);
            return string.Join("", response.Translations.Select(x => x.Text));
        }

        public static string NormalizeDialect(string dialect)
        {
            if (dialect == "EN-GB" || dialect == "EN-US") return "EN";

            if (dialect == "PT-BR" || dialect == "PT-PT") return "PT";

            if (dialect == "EN") return "EN-US";

            if (dialect == "PT") return "PT-PT";

            return dialect;
        }

        public class TranslationResult
        {
            [JsonPropertyName("translations")] public List<TranslationRecord> Translations { get; set; }

            public class TranslationRecord
            {
                [JsonPropertyName("detected_source_language")]
                public string DetectedSourceLanguage { get; set; }

                [JsonPropertyName("text")] public string Text { get; set; }
            }
        }
    }
}