using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Azure.AI.OpenAI;

namespace CapybaraTranslateAddin.ApiClient
{
    public class OpenAiClient : ITranslationClient
    {
        public const string DefaultSourceLanguage = "ja";
        public const string DefaultTargetLanguage = "en";

        public const string EngineCodeGpt4 = "gpt4";
        public const string EngineNameGpt4 = "GPT4";

        public static readonly List<Language> SupportedSourceLanguages = new List<Language>
        {
            new Language
            {
                Value = "af",
                Label = "Afrikaans"
            },
            new Language
            {
                Value = "sq",
                Label = "Albanian"
            },
            new Language
            {
                Value = "am",
                Label = "Amharic"
            },
            new Language
            {
                Value = "ar",
                Label = "Arabic"
            },
            new Language
            {
                Value = "hy",
                Label = "Armenian"
            },
            new Language
            {
                Value = "as",
                Label = "Assamese"
            },
            new Language
            {
                Value = "ay",
                Label = "Aymara"
            },
            new Language
            {
                Value = "az",
                Label = "Azerbaijani"
            },
            new Language
            {
                Value = "bm",
                Label = "Bambara"
            },
            new Language
            {
                Value = "eu",
                Label = "Basque"
            },
            new Language
            {
                Value = "be",
                Label = "Belarusian"
            },
            new Language
            {
                Value = "bn",
                Label = "Bengali"
            },
            new Language
            {
                Value = "bho",
                Label = "Bhojpuri"
            },
            new Language
            {
                Value = "bs",
                Label = "Bosnian"
            },
            new Language
            {
                Value = "bg",
                Label = "Bulgarian"
            },
            new Language
            {
                Value = "ca",
                Label = "Catalan"
            },
            new Language
            {
                Value = "ceb",
                Label = "Cebuano"
            },
            new Language
            {
                Value = "ny",
                Label = "Chichewa"
            },
            new Language
            {
                Value = "zh",
                Label = "Chinese (Simplified)"
            },
            new Language
            {
                Value = "zh-TW",
                Label = "Chinese (Traditional)"
            },
            new Language
            {
                Value = "co",
                Label = "Corsican"
            },
            new Language
            {
                Value = "hr",
                Label = "Croatian"
            },
            new Language
            {
                Value = "cs",
                Label = "Czech"
            },
            new Language
            {
                Value = "da",
                Label = "Danish"
            },
            new Language
            {
                Value = "dv",
                Label = "Divehi"
            },
            new Language
            {
                Value = "doi",
                Label = "Dogri"
            },
            new Language
            {
                Value = "nl",
                Label = "Dutch"
            },
            new Language
            {
                Value = "en",
                Label = "English"
            },
            new Language
            {
                Value = "eo",
                Label = "Esperanto"
            },
            new Language
            {
                Value = "et",
                Label = "Estonian"
            },
            new Language
            {
                Value = "ee",
                Label = "Ewe"
            },
            new Language
            {
                Value = "tl",
                Label = "Filipino"
            },
            new Language
            {
                Value = "fi",
                Label = "Finnish"
            },
            new Language
            {
                Value = "fr",
                Label = "French"
            },
            new Language
            {
                Value = "fy",
                Label = "Frisian"
            },
            new Language
            {
                Value = "gl",
                Label = "Galician"
            },
            new Language
            {
                Value = "lg",
                Label = "Ganda"
            },
            new Language
            {
                Value = "ka",
                Label = "Georgian"
            },
            new Language
            {
                Value = "de",
                Label = "German"
            },
            new Language
            {
                Value = "el",
                Label = "Greek"
            },
            new Language
            {
                Value = "gn",
                Label = "Guarani"
            },
            new Language
            {
                Value = "gu",
                Label = "Gujarati"
            },
            new Language
            {
                Value = "ht",
                Label = "Haitian Creole"
            },
            new Language
            {
                Value = "ha",
                Label = "Hausa"
            },
            new Language
            {
                Value = "haw",
                Label = "Hawaiian"
            },
            new Language
            {
                Value = "iw",
                Label = "Hebrew"
            },
            new Language
            {
                Value = "hi",
                Label = "Hindi"
            },
            new Language
            {
                Value = "hmn",
                Label = "Hmong"
            },
            new Language
            {
                Value = "hu",
                Label = "Hungarian"
            },
            new Language
            {
                Value = "is",
                Label = "Icelandic"
            },
            new Language
            {
                Value = "ig",
                Label = "Igbo"
            },
            new Language
            {
                Value = "ilo",
                Label = "Iloko"
            },
            new Language
            {
                Value = "id",
                Label = "Indonesian"
            },
            new Language
            {
                Value = "ga",
                Label = "Irish Gaelic"
            },
            new Language
            {
                Value = "it",
                Label = "Italian"
            },
            new Language
            {
                Value = "ja",
                Label = "Japanese"
            },
            new Language
            {
                Value = "jw",
                Label = "Javanese"
            },
            new Language
            {
                Value = "kn",
                Label = "Kannada"
            },
            new Language
            {
                Value = "kk",
                Label = "Kazakh"
            },
            new Language
            {
                Value = "km",
                Label = "Khmer"
            },
            new Language
            {
                Value = "rw",
                Label = "Kinyarwanda"
            },
            new Language
            {
                Value = "gom",
                Label = "Konkani"
            },
            new Language
            {
                Value = "ko",
                Label = "Korean"
            },
            new Language
            {
                Value = "kri",
                Label = "Krio"
            },
            new Language
            {
                Value = "ku",
                Label = "Kurdish (Kurmanji)"
            },
            new Language
            {
                Value = "ckb",
                Label = "Kurdish (Sorani)"
            },
            new Language
            {
                Value = "ky",
                Label = "Kyrgyz"
            },
            new Language
            {
                Value = "lo",
                Label = "Lao"
            },
            new Language
            {
                Value = "la",
                Label = "Latin"
            },
            new Language
            {
                Value = "lv",
                Label = "Latvian"
            },
            new Language
            {
                Value = "ln",
                Label = "Lingala"
            },
            new Language
            {
                Value = "lt",
                Label = "Lithuanian"
            },
            new Language
            {
                Value = "lb",
                Label = "Luxembourgish"
            },
            new Language
            {
                Value = "mk",
                Label = "Macedonian"
            },
            new Language
            {
                Value = "mai",
                Label = "Maithili"
            },
            new Language
            {
                Value = "mg",
                Label = "Malagasy"
            },
            new Language
            {
                Value = "ms",
                Label = "Malay"
            },
            new Language
            {
                Value = "ml",
                Label = "Malayalam"
            },
            new Language
            {
                Value = "mt",
                Label = "Maltese"
            },
            new Language
            {
                Value = "mi",
                Label = "Maori"
            },
            new Language
            {
                Value = "mr",
                Label = "Marathi"
            },
            new Language
            {
                Value = "mni-Mtei",
                Label = "Meiteilon (Manipuri)"
            },
            new Language
            {
                Value = "lus",
                Label = "Mizo"
            },
            new Language
            {
                Value = "mn",
                Label = "Mongolian"
            },
            new Language
            {
                Value = "my",
                Label = "Myanmar (Burmese)"
            },
            new Language
            {
                Value = "ne",
                Label = "Nepali"
            },
            new Language
            {
                Value = "nso",
                Label = "Northern Sotho"
            },
            new Language
            {
                Value = "no",
                Label = "Norwegian"
            },
            new Language
            {
                Value = "or",
                Label = "Odia (Oriya)"
            },
            new Language
            {
                Value = "om",
                Label = "Oromo"
            },
            new Language
            {
                Value = "ps",
                Label = "Pashto"
            },
            new Language
            {
                Value = "fa",
                Label = "Persian"
            },
            new Language
            {
                Value = "pl",
                Label = "Polish"
            },
            new Language
            {
                Value = "pt",
                Label = "Portuguese"
            },
            new Language
            {
                Value = "pa",
                Label = "Punjabi"
            },
            new Language
            {
                Value = "qu",
                Label = "Quechua"
            },
            new Language
            {
                Value = "ro",
                Label = "Romanian"
            },
            new Language
            {
                Value = "ru",
                Label = "Russian"
            },
            new Language
            {
                Value = "sm",
                Label = "Samoan"
            },
            new Language
            {
                Value = "sa",
                Label = "Sanskrit"
            },
            new Language
            {
                Value = "gd",
                Label = "Scots Gaelic"
            },
            new Language
            {
                Value = "sr",
                Label = "Serbian"
            },
            new Language
            {
                Value = "st",
                Label = "Sesotho"
            },
            new Language
            {
                Value = "sn",
                Label = "Shona"
            },
            new Language
            {
                Value = "sd",
                Label = "Sindhi"
            },
            new Language
            {
                Value = "si",
                Label = "Sinhala"
            },
            new Language
            {
                Value = "sk",
                Label = "Slovak"
            },
            new Language
            {
                Value = "sl",
                Label = "Slovenian"
            },
            new Language
            {
                Value = "so",
                Label = "Somali"
            },
            new Language
            {
                Value = "es",
                Label = "Spanish"
            },
            new Language
            {
                Value = "su",
                Label = "Sundanese"
            },
            new Language
            {
                Value = "sw",
                Label = "Swahili"
            },
            new Language
            {
                Value = "sv",
                Label = "Swedish"
            },
            new Language
            {
                Value = "tg",
                Label = "Tajik"
            },
            new Language
            {
                Value = "ta",
                Label = "Tamil"
            },
            new Language
            {
                Value = "tt",
                Label = "Tatar"
            },
            new Language
            {
                Value = "te",
                Label = "Telugu"
            },
            new Language
            {
                Value = "th",
                Label = "Thai"
            },
            new Language
            {
                Value = "ti",
                Label = "Tigrinya"
            },
            new Language
            {
                Value = "ts",
                Label = "Tsonga"
            },
            new Language
            {
                Value = "tr",
                Label = "Turkish"
            },
            new Language
            {
                Value = "tk",
                Label = "Turkmen"
            },
            new Language
            {
                Value = "ak",
                Label = "Twi"
            },
            new Language
            {
                Value = "uk",
                Label = "Ukrainian"
            },
            new Language
            {
                Value = "ur",
                Label = "Urdu"
            },
            new Language
            {
                Value = "ug",
                Label = "Uyghur"
            },
            new Language
            {
                Value = "uz",
                Label = "Uzbek"
            },
            new Language
            {
                Value = "vi",
                Label = "Vietnamese"
            },
            new Language
            {
                Value = "cy",
                Label = "Welsh"
            },
            new Language
            {
                Value = "xh",
                Label = "Xhosa"
            },
            new Language
            {
                Value = "yi",
                Label = "Yiddish"
            },
            new Language
            {
                Value = "yo",
                Label = "Yoruba"
            },
            new Language
            {
                Value = "zu",
                Label = "Zulu"
            },
            new Language
            {
                Value = "he",
                Label = "Hebrew"
            },
            new Language
            {
                Value = "jv",
                Label = "Javanese"
            },
            new Language
            {
                Value = "zh-CN",
                Label = "Chinese (Simplified)"
            }
        };


        public static readonly List<Language> SupportedTargetLanguages = new List<Language>
        {
            new Language
            {
                Value = "af",
                Label = "Afrikaans"
            },
            new Language
            {
                Value = "sq",
                Label = "Albanian"
            },
            new Language
            {
                Value = "am",
                Label = "Amharic"
            },
            new Language
            {
                Value = "ar",
                Label = "Arabic"
            },
            new Language
            {
                Value = "hy",
                Label = "Armenian"
            },
            new Language
            {
                Value = "as",
                Label = "Assamese"
            },
            new Language
            {
                Value = "ay",
                Label = "Aymara"
            },
            new Language
            {
                Value = "az",
                Label = "Azerbaijani"
            },
            new Language
            {
                Value = "bm",
                Label = "Bambara"
            },
            new Language
            {
                Value = "eu",
                Label = "Basque"
            },
            new Language
            {
                Value = "be",
                Label = "Belarusian"
            },
            new Language
            {
                Value = "bn",
                Label = "Bengali"
            },
            new Language
            {
                Value = "bho",
                Label = "Bhojpuri"
            },
            new Language
            {
                Value = "bs",
                Label = "Bosnian"
            },
            new Language
            {
                Value = "bg",
                Label = "Bulgarian"
            },
            new Language
            {
                Value = "ca",
                Label = "Catalan"
            },
            new Language
            {
                Value = "ceb",
                Label = "Cebuano"
            },
            new Language
            {
                Value = "ny",
                Label = "Chichewa"
            },
            new Language
            {
                Value = "zh",
                Label = "Chinese (Simplified)"
            },
            new Language
            {
                Value = "zh-TW",
                Label = "Chinese (Traditional)"
            },
            new Language
            {
                Value = "co",
                Label = "Corsican"
            },
            new Language
            {
                Value = "hr",
                Label = "Croatian"
            },
            new Language
            {
                Value = "cs",
                Label = "Czech"
            },
            new Language
            {
                Value = "da",
                Label = "Danish"
            },
            new Language
            {
                Value = "dv",
                Label = "Divehi"
            },
            new Language
            {
                Value = "doi",
                Label = "Dogri"
            },
            new Language
            {
                Value = "nl",
                Label = "Dutch"
            },
            new Language
            {
                Value = "en",
                Label = "English"
            },
            new Language
            {
                Value = "eo",
                Label = "Esperanto"
            },
            new Language
            {
                Value = "et",
                Label = "Estonian"
            },
            new Language
            {
                Value = "ee",
                Label = "Ewe"
            },
            new Language
            {
                Value = "tl",
                Label = "Filipino"
            },
            new Language
            {
                Value = "fi",
                Label = "Finnish"
            },
            new Language
            {
                Value = "fr",
                Label = "French"
            },
            new Language
            {
                Value = "fy",
                Label = "Frisian"
            },
            new Language
            {
                Value = "gl",
                Label = "Galician"
            },
            new Language
            {
                Value = "lg",
                Label = "Ganda"
            },
            new Language
            {
                Value = "ka",
                Label = "Georgian"
            },
            new Language
            {
                Value = "de",
                Label = "German"
            },
            new Language
            {
                Value = "el",
                Label = "Greek"
            },
            new Language
            {
                Value = "gn",
                Label = "Guarani"
            },
            new Language
            {
                Value = "gu",
                Label = "Gujarati"
            },
            new Language
            {
                Value = "ht",
                Label = "Haitian Creole"
            },
            new Language
            {
                Value = "ha",
                Label = "Hausa"
            },
            new Language
            {
                Value = "haw",
                Label = "Hawaiian"
            },
            new Language
            {
                Value = "iw",
                Label = "Hebrew"
            },
            new Language
            {
                Value = "hi",
                Label = "Hindi"
            },
            new Language
            {
                Value = "hmn",
                Label = "Hmong"
            },
            new Language
            {
                Value = "hu",
                Label = "Hungarian"
            },
            new Language
            {
                Value = "is",
                Label = "Icelandic"
            },
            new Language
            {
                Value = "ig",
                Label = "Igbo"
            },
            new Language
            {
                Value = "ilo",
                Label = "Iloko"
            },
            new Language
            {
                Value = "id",
                Label = "Indonesian"
            },
            new Language
            {
                Value = "ga",
                Label = "Irish Gaelic"
            },
            new Language
            {
                Value = "it",
                Label = "Italian"
            },
            new Language
            {
                Value = "ja",
                Label = "Japanese"
            },
            new Language
            {
                Value = "jw",
                Label = "Javanese"
            },
            new Language
            {
                Value = "kn",
                Label = "Kannada"
            },
            new Language
            {
                Value = "kk",
                Label = "Kazakh"
            },
            new Language
            {
                Value = "km",
                Label = "Khmer"
            },
            new Language
            {
                Value = "rw",
                Label = "Kinyarwanda"
            },
            new Language
            {
                Value = "gom",
                Label = "Konkani"
            },
            new Language
            {
                Value = "ko",
                Label = "Korean"
            },
            new Language
            {
                Value = "kri",
                Label = "Krio"
            },
            new Language
            {
                Value = "ku",
                Label = "Kurdish (Kurmanji)"
            },
            new Language
            {
                Value = "ckb",
                Label = "Kurdish (Sorani)"
            },
            new Language
            {
                Value = "ky",
                Label = "Kyrgyz"
            },
            new Language
            {
                Value = "lo",
                Label = "Lao"
            },
            new Language
            {
                Value = "la",
                Label = "Latin"
            },
            new Language
            {
                Value = "lv",
                Label = "Latvian"
            },
            new Language
            {
                Value = "ln",
                Label = "Lingala"
            },
            new Language
            {
                Value = "lt",
                Label = "Lithuanian"
            },
            new Language
            {
                Value = "lb",
                Label = "Luxembourgish"
            },
            new Language
            {
                Value = "mk",
                Label = "Macedonian"
            },
            new Language
            {
                Value = "mai",
                Label = "Maithili"
            },
            new Language
            {
                Value = "mg",
                Label = "Malagasy"
            },
            new Language
            {
                Value = "ms",
                Label = "Malay"
            },
            new Language
            {
                Value = "ml",
                Label = "Malayalam"
            },
            new Language
            {
                Value = "mt",
                Label = "Maltese"
            },
            new Language
            {
                Value = "mi",
                Label = "Maori"
            },
            new Language
            {
                Value = "mr",
                Label = "Marathi"
            },
            new Language
            {
                Value = "mni-Mtei",
                Label = "Meiteilon (Manipuri)"
            },
            new Language
            {
                Value = "lus",
                Label = "Mizo"
            },
            new Language
            {
                Value = "mn",
                Label = "Mongolian"
            },
            new Language
            {
                Value = "my",
                Label = "Myanmar (Burmese)"
            },
            new Language
            {
                Value = "ne",
                Label = "Nepali"
            },
            new Language
            {
                Value = "nso",
                Label = "Northern Sotho"
            },
            new Language
            {
                Value = "no",
                Label = "Norwegian"
            },
            new Language
            {
                Value = "or",
                Label = "Odia (Oriya)"
            },
            new Language
            {
                Value = "om",
                Label = "Oromo"
            },
            new Language
            {
                Value = "ps",
                Label = "Pashto"
            },
            new Language
            {
                Value = "fa",
                Label = "Persian"
            },
            new Language
            {
                Value = "pl",
                Label = "Polish"
            },
            new Language
            {
                Value = "pt",
                Label = "Portuguese"
            },
            new Language
            {
                Value = "pa",
                Label = "Punjabi"
            },
            new Language
            {
                Value = "qu",
                Label = "Quechua"
            },
            new Language
            {
                Value = "ro",
                Label = "Romanian"
            },
            new Language
            {
                Value = "ru",
                Label = "Russian"
            },
            new Language
            {
                Value = "sm",
                Label = "Samoan"
            },
            new Language
            {
                Value = "sa",
                Label = "Sanskrit"
            },
            new Language
            {
                Value = "gd",
                Label = "Scots Gaelic"
            },
            new Language
            {
                Value = "sr",
                Label = "Serbian"
            },
            new Language
            {
                Value = "st",
                Label = "Sesotho"
            },
            new Language
            {
                Value = "sn",
                Label = "Shona"
            },
            new Language
            {
                Value = "sd",
                Label = "Sindhi"
            },
            new Language
            {
                Value = "si",
                Label = "Sinhala"
            },
            new Language
            {
                Value = "sk",
                Label = "Slovak"
            },
            new Language
            {
                Value = "sl",
                Label = "Slovenian"
            },
            new Language
            {
                Value = "so",
                Label = "Somali"
            },
            new Language
            {
                Value = "es",
                Label = "Spanish"
            },
            new Language
            {
                Value = "su",
                Label = "Sundanese"
            },
            new Language
            {
                Value = "sw",
                Label = "Swahili"
            },
            new Language
            {
                Value = "sv",
                Label = "Swedish"
            },
            new Language
            {
                Value = "tg",
                Label = "Tajik"
            },
            new Language
            {
                Value = "ta",
                Label = "Tamil"
            },
            new Language
            {
                Value = "tt",
                Label = "Tatar"
            },
            new Language
            {
                Value = "te",
                Label = "Telugu"
            },
            new Language
            {
                Value = "th",
                Label = "Thai"
            },
            new Language
            {
                Value = "ti",
                Label = "Tigrinya"
            },
            new Language
            {
                Value = "ts",
                Label = "Tsonga"
            },
            new Language
            {
                Value = "tr",
                Label = "Turkish"
            },
            new Language
            {
                Value = "tk",
                Label = "Turkmen"
            },
            new Language
            {
                Value = "ak",
                Label = "Twi"
            },
            new Language
            {
                Value = "uk",
                Label = "Ukrainian"
            },
            new Language
            {
                Value = "ur",
                Label = "Urdu"
            },
            new Language
            {
                Value = "ug",
                Label = "Uyghur"
            },
            new Language
            {
                Value = "uz",
                Label = "Uzbek"
            },
            new Language
            {
                Value = "vi",
                Label = "Vietnamese"
            },
            new Language
            {
                Value = "cy",
                Label = "Welsh"
            },
            new Language
            {
                Value = "xh",
                Label = "Xhosa"
            },
            new Language
            {
                Value = "yi",
                Label = "Yiddish"
            },
            new Language
            {
                Value = "yo",
                Label = "Yoruba"
            },
            new Language
            {
                Value = "zu",
                Label = "Zulu"
            },
            new Language
            {
                Value = "he",
                Label = "Hebrew"
            },
            new Language
            {
                Value = "jv",
                Label = "Javanese"
            },
            new Language
            {
                Value = "zh-CN",
                Label = "Chinese (Simplified)"
            }
        };

        private readonly OpenAIClient _client;

        private readonly OpenAiClientOptions _options;

        public OpenAiClient(OpenAiClientOptions options)
        {
            _options = options;
            _client = new OpenAIClient(_options.ApiKey);
        }

        public async Task<string> TranslateAsync(string text, string from, string to)
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var fromLang = SupportedSourceLanguages.FirstOrDefault(x => x.Value == from);
            if (fromLang == null) return text;
            var toLang = SupportedTargetLanguages.FirstOrDefault(x => x.Value == to);
            if (toLang == null) return text;
            var response = await _client.GetChatCompletionsAsync(new ChatCompletionsOptions
            {
                DeploymentName = "gpt-4",
                Messages =
                {
                    new ChatRequestSystemMessage(
                        $"You will be provided with some sentences in {fromLang.Label}, and your task is to translate them into {toLang.Label}."),
                    new ChatRequestUserMessage(text)
                },
                Temperature = 0,
                MaxTokens = 1000,
                ChoiceCount = 1
            });
            if (!response.HasValue) return text;

            return string.Join("", response.Value.Choices.Select(c => c.Message.Content));
        }
    }
}