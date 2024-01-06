using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.TextToSpeech.V1;
using Google.Cloud.Translation.V2;

namespace CapybaraTranslateAddin.ApiClient
{
    public class GoogleClient : ITranslationClient, ITextToSpeechClient
    {
        public const string DefaultSourceLanguage = "ja";
        public const string DefaultTargetLanguage = "en";
        public const string DefaultTtsVoiceName = "en-US-Neural2-A";

        public const string EngineCode = "google";
        public const string EngineName = "Google";

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

        public static List<string> SupportedTtsVoiceNames = new List<string>
        {
            "af-ZA-Standard-A",
            "ar-XA-Standard-A",
            "ar-XA-Standard-B",
            "ar-XA-Standard-C",
            "ar-XA-Standard-D",
            "ar-XA-Wavenet-A",
            "ar-XA-Wavenet-B",
            "ar-XA-Wavenet-C",
            "ar-XA-Wavenet-D",
            "eu-ES-Standard-A",
            "bn-IN-Standard-A",
            "bn-IN-Standard-B",
            "bn-IN-Wavenet-A",
            "bn-IN-Wavenet-B",
            "bg-BG-Standard-A",
            "ca-ES-Standard-A",
            "yue-HK-Standard-A",
            "yue-HK-Standard-B",
            "yue-HK-Standard-C",
            "yue-HK-Standard-D",
            "cs-CZ-Standard-A",
            "cs-CZ-Wavenet-A",
            "da-DK-Neural2-D",
            "da-DK-Standard-A",
            "da-DK-Standard-C",
            "da-DK-Standard-D",
            "da-DK-Standard-E",
            "da-DK-Wavenet-A",
            "da-DK-Wavenet-C",
            "da-DK-Wavenet-D",
            "da-DK-Wavenet-E",
            "nl-BE-Standard-A",
            "nl-BE-Standard-B",
            "nl-BE-Wavenet-A",
            "nl-BE-Wavenet-B",
            "nl-NL-Standard-A",
            "nl-NL-Standard-B",
            "nl-NL-Standard-C",
            "nl-NL-Standard-D",
            "nl-NL-Standard-E",
            "nl-NL-Wavenet-A",
            "nl-NL-Wavenet-B",
            "nl-NL-Wavenet-C",
            "nl-NL-Wavenet-D",
            "nl-NL-Wavenet-E",
            "en-AU-Neural2-A",
            "en-AU-Neural2-B",
            "en-AU-Neural2-C",
            "en-AU-Neural2-D",
            "en-AU-News-E",
            "en-AU-News-F",
            "en-AU-News-G",
            "en-AU-Polyglot-1",
            "en-AU-Standard-A",
            "en-AU-Standard-B",
            "en-AU-Standard-C",
            "en-AU-Standard-D",
            "en-AU-Wavenet-A",
            "en-AU-Wavenet-B",
            "en-AU-Wavenet-C",
            "en-AU-Wavenet-D",
            "en-IN-Neural2-A",
            "en-IN-Neural2-B",
            "en-IN-Neural2-C",
            "en-IN-Neural2-D",
            "en-IN-Standard-A",
            "en-IN-Standard-B",
            "en-IN-Standard-C",
            "en-IN-Standard-D",
            "en-IN-Wavenet-A",
            "en-IN-Wavenet-B",
            "en-IN-Wavenet-C",
            "en-IN-Wavenet-D",
            "en-GB-Neural2-A",
            "en-GB-Neural2-B",
            "en-GB-Neural2-C",
            "en-GB-Neural2-D",
            "en-GB-Neural2-F",
            "en-GB-News-G",
            "en-GB-News-H",
            "en-GB-News-I",
            "en-GB-News-J",
            "en-GB-News-K",
            "en-GB-News-L",
            "en-GB-News-M",
            "en-GB-Standard-A",
            "en-GB-Standard-B",
            "en-GB-Standard-C",
            "en-GB-Standard-D",
            "en-GB-Standard-F",
            "en-GB-Studio-B",
            "en-GB-Studio-C",
            "en-GB-Wavenet-A",
            "en-GB-Wavenet-B",
            "en-GB-Wavenet-C",
            "en-GB-Wavenet-D",
            "en-GB-Wavenet-F",
            "en-US-Neural2-A",
            "en-US-Neural2-C",
            "en-US-Neural2-D",
            "en-US-Neural2-E",
            "en-US-Neural2-F",
            "en-US-Neural2-G",
            "en-US-Neural2-H",
            "en-US-Neural2-I",
            "en-US-Neural2-J",
            "en-US-News-K",
            "en-US-News-L",
            "en-US-News-N",
            "en-US-Polyglot-1",
            "en-US-Standard-A",
            "en-US-Standard-B",
            "en-US-Standard-C",
            "en-US-Standard-D",
            "en-US-Standard-E",
            "en-US-Standard-F",
            "en-US-Standard-G",
            "en-US-Standard-H",
            "en-US-Standard-I",
            "en-US-Standard-J",
            "en-US-Studio-O",
            "en-US-Studio-Q",
            "en-US-Wavenet-A",
            "en-US-Wavenet-B",
            "en-US-Wavenet-C",
            "en-US-Wavenet-D",
            "en-US-Wavenet-E",
            "en-US-Wavenet-F",
            "en-US-Wavenet-G",
            "en-US-Wavenet-H",
            "en-US-Wavenet-I",
            "en-US-Wavenet-J",
            "fil-PH-Standard-A",
            "fil-PH-Standard-B",
            "fil-PH-Standard-C",
            "fil-PH-Standard-D",
            "fil-PH-Wavenet-A",
            "fil-PH-Wavenet-B",
            "fil-PH-Wavenet-C",
            "fil-PH-Wavenet-D",
            "fil-ph-Neural2-A",
            "fil-ph-Neural2-D",
            "fi-FI-Standard-A",
            "fi-FI-Wavenet-A",
            "fr-CA-Neural2-A",
            "fr-CA-Neural2-B",
            "fr-CA-Neural2-C",
            "fr-CA-Neural2-D",
            "fr-CA-Standard-A",
            "fr-CA-Standard-B",
            "fr-CA-Standard-C",
            "fr-CA-Standard-D",
            "fr-CA-Wavenet-A",
            "fr-CA-Wavenet-B",
            "fr-CA-Wavenet-C",
            "fr-CA-Wavenet-D",
            "fr-FR-Neural2-A",
            "fr-FR-Neural2-B",
            "fr-FR-Neural2-C",
            "fr-FR-Neural2-D",
            "fr-FR-Neural2-E",
            "fr-FR-Polyglot-1",
            "fr-FR-Standard-A",
            "fr-FR-Standard-B",
            "fr-FR-Standard-C",
            "fr-FR-Standard-D",
            "fr-FR-Standard-E",
            "fr-FR-Studio-A",
            "fr-FR-Studio-D",
            "fr-FR-Wavenet-A",
            "fr-FR-Wavenet-B",
            "fr-FR-Wavenet-C",
            "fr-FR-Wavenet-D",
            "fr-FR-Wavenet-E",
            "gl-ES-Standard-A",
            "de-DE-Neural2-A",
            "de-DE-Neural2-B",
            "de-DE-Neural2-C",
            "de-DE-Neural2-D",
            "de-DE-Neural2-F",
            "de-DE-Polyglot-1",
            "de-DE-Standard-A",
            "de-DE-Standard-B",
            "de-DE-Standard-C",
            "de-DE-Standard-D",
            "de-DE-Standard-E",
            "de-DE-Standard-F",
            "de-DE-Studio-B",
            "de-DE-Studio-C",
            "de-DE-Wavenet-A",
            "de-DE-Wavenet-B",
            "de-DE-Wavenet-C",
            "de-DE-Wavenet-D",
            "de-DE-Wavenet-E",
            "de-DE-Wavenet-F",
            "el-GR-Standard-A",
            "el-GR-Wavenet-A",
            "gu-IN-Standard-A",
            "gu-IN-Standard-B",
            "gu-IN-Wavenet-A",
            "gu-IN-Wavenet-B",
            "he-IL-Standard-A",
            "he-IL-Standard-B",
            "he-IL-Standard-C",
            "he-IL-Standard-D",
            "he-IL-Wavenet-A",
            "he-IL-Wavenet-B",
            "he-IL-Wavenet-C",
            "he-IL-Wavenet-D",
            "hi-IN-Neural2-A",
            "hi-IN-Neural2-B",
            "hi-IN-Neural2-C",
            "hi-IN-Neural2-D",
            "hi-IN-Standard-A",
            "hi-IN-Standard-B",
            "hi-IN-Standard-C",
            "hi-IN-Standard-D",
            "hi-IN-Wavenet-A",
            "hi-IN-Wavenet-B",
            "hi-IN-Wavenet-C",
            "hi-IN-Wavenet-D",
            "hu-HU-Standard-A",
            "hu-HU-Wavenet-A",
            "is-IS-Standard-A",
            "id-ID-Standard-A",
            "id-ID-Standard-B",
            "id-ID-Standard-C",
            "id-ID-Standard-D",
            "id-ID-Wavenet-A",
            "id-ID-Wavenet-B",
            "id-ID-Wavenet-C",
            "id-ID-Wavenet-D",
            "it-IT-Neural2-A",
            "it-IT-Neural2-C",
            "it-IT-Standard-A",
            "it-IT-Standard-B",
            "it-IT-Standard-C",
            "it-IT-Standard-D",
            "it-IT-Wavenet-A",
            "it-IT-Wavenet-B",
            "it-IT-Wavenet-C",
            "it-IT-Wavenet-D",
            "ja-JP-Neural2-B",
            "ja-JP-Neural2-C",
            "ja-JP-Neural2-D",
            "ja-JP-Standard-A",
            "ja-JP-Standard-B",
            "ja-JP-Standard-C",
            "ja-JP-Standard-D",
            "ja-JP-Wavenet-A",
            "ja-JP-Wavenet-B",
            "ja-JP-Wavenet-C",
            "ja-JP-Wavenet-D",
            "kn-IN-Standard-A",
            "kn-IN-Standard-B",
            "kn-IN-Wavenet-A",
            "kn-IN-Wavenet-B",
            "ko-KR-Neural2-A",
            "ko-KR-Neural2-B",
            "ko-KR-Neural2-C",
            "ko-KR-Standard-A",
            "ko-KR-Standard-B",
            "ko-KR-Standard-C",
            "ko-KR-Standard-D",
            "ko-KR-Wavenet-A",
            "ko-KR-Wavenet-B",
            "ko-KR-Wavenet-C",
            "ko-KR-Wavenet-D",
            "lv-LV-Standard-A",
            "lt-LT-Standard-A",
            "ms-MY-Standard-A",
            "ms-MY-Standard-B",
            "ms-MY-Standard-C",
            "ms-MY-Standard-D",
            "ms-MY-Wavenet-A",
            "ms-MY-Wavenet-B",
            "ms-MY-Wavenet-C",
            "ms-MY-Wavenet-D",
            "ml-IN-Standard-A",
            "ml-IN-Standard-B",
            "ml-IN-Wavenet-A",
            "ml-IN-Wavenet-B",
            "ml-IN-Wavenet-C",
            "ml-IN-Wavenet-D",
            "cmn-CN-Standard-A",
            "cmn-CN-Standard-B",
            "cmn-CN-Standard-C",
            "cmn-CN-Standard-D",
            "cmn-CN-Wavenet-A",
            "cmn-CN-Wavenet-B",
            "cmn-CN-Wavenet-C",
            "cmn-CN-Wavenet-D",
            "cmn-TW-Standard-A",
            "cmn-TW-Standard-B",
            "cmn-TW-Standard-C",
            "cmn-TW-Wavenet-A",
            "cmn-TW-Wavenet-B",
            "cmn-TW-Wavenet-C",
            "mr-IN-Standard-A",
            "mr-IN-Standard-B",
            "mr-IN-Standard-C",
            "mr-IN-Wavenet-A",
            "mr-IN-Wavenet-B",
            "mr-IN-Wavenet-C",
            "nb-NO-Standard-A",
            "nb-NO-Standard-B",
            "nb-NO-Standard-C",
            "nb-NO-Standard-D",
            "nb-NO-Standard-E",
            "nb-NO-Wavenet-A",
            "nb-NO-Wavenet-B",
            "nb-NO-Wavenet-C",
            "nb-NO-Wavenet-D",
            "nb-NO-Wavenet-E",
            "pl-PL-Standard-A",
            "pl-PL-Standard-B",
            "pl-PL-Standard-C",
            "pl-PL-Standard-D",
            "pl-PL-Standard-E",
            "pl-PL-Wavenet-A",
            "pl-PL-Wavenet-B",
            "pl-PL-Wavenet-C",
            "pl-PL-Wavenet-D",
            "pl-PL-Wavenet-E",
            "pt-BR-Neural2-A",
            "pt-BR-Neural2-B",
            "pt-BR-Neural2-C",
            "pt-BR-Standard-A",
            "pt-BR-Standard-B",
            "pt-BR-Standard-C",
            "pt-BR-Wavenet-A",
            "pt-BR-Wavenet-B",
            "pt-BR-Wavenet-C",
            "pt-PT-Standard-A",
            "pt-PT-Standard-B",
            "pt-PT-Standard-C",
            "pt-PT-Standard-D",
            "pt-PT-Wavenet-A",
            "pt-PT-Wavenet-B",
            "pt-PT-Wavenet-C",
            "pt-PT-Wavenet-D",
            "pa-IN-Standard-A",
            "pa-IN-Standard-B",
            "pa-IN-Standard-C",
            "pa-IN-Standard-D",
            "pa-IN-Wavenet-A",
            "pa-IN-Wavenet-B",
            "pa-IN-Wavenet-C",
            "pa-IN-Wavenet-D",
            "ro-RO-Standard-A",
            "ro-RO-Wavenet-A",
            "ru-RU-Standard-A",
            "ru-RU-Standard-B",
            "ru-RU-Standard-C",
            "ru-RU-Standard-D",
            "ru-RU-Standard-E",
            "ru-RU-Wavenet-A",
            "ru-RU-Wavenet-B",
            "ru-RU-Wavenet-C",
            "ru-RU-Wavenet-D",
            "ru-RU-Wavenet-E",
            "sr-RS-Standard-A",
            "sk-SK-Standard-A",
            "sk-SK-Wavenet-A",
            "es-ES-Neural2-A",
            "es-ES-Neural2-B",
            "es-ES-Neural2-C",
            "es-ES-Neural2-D",
            "es-ES-Neural2-E",
            "es-ES-Neural2-F",
            "es-ES-Polyglot-1",
            "es-ES-Standard-A",
            "es-ES-Standard-B",
            "es-ES-Standard-C",
            "es-ES-Standard-D",
            "es-ES-Wavenet-B",
            "es-ES-Wavenet-C",
            "es-ES-Wavenet-D",
            "es-US-Neural2-A",
            "es-US-Neural2-B",
            "es-US-Neural2-C",
            "es-US-News-D",
            "es-US-News-E",
            "es-US-News-F",
            "es-US-News-G",
            "es-US-Polyglot-1",
            "es-US-Standard-A",
            "es-US-Standard-B",
            "es-US-Standard-C",
            "es-US-Studio-B",
            "es-US-Wavenet-A",
            "es-US-Wavenet-B",
            "es-US-Wavenet-C",
            "sv-SE-Standard-A",
            "sv-SE-Standard-B",
            "sv-SE-Standard-C",
            "sv-SE-Standard-D",
            "sv-SE-Standard-E",
            "sv-SE-Wavenet-A",
            "sv-SE-Wavenet-B",
            "sv-SE-Wavenet-C",
            "sv-SE-Wavenet-D",
            "sv-SE-Wavenet-E",
            "ta-IN-Standard-A",
            "ta-IN-Standard-B",
            "ta-IN-Standard-C",
            "ta-IN-Standard-D",
            "ta-IN-Wavenet-A",
            "ta-IN-Wavenet-B",
            "ta-IN-Wavenet-C",
            "ta-IN-Wavenet-D",
            "te-IN-Standard-A",
            "te-IN-Standard-B",
            "th-TH-Neural2-C",
            "th-TH-Standard-A",
            "tr-TR-Standard-A",
            "tr-TR-Standard-B",
            "tr-TR-Standard-C",
            "tr-TR-Standard-D",
            "tr-TR-Standard-E",
            "tr-TR-Wavenet-A",
            "tr-TR-Wavenet-B",
            "tr-TR-Wavenet-C",
            "tr-TR-Wavenet-D",
            "tr-TR-Wavenet-E",
            "uk-UA-Standard-A",
            "uk-UA-Wavenet-A",
            "vi-VN-Neural2-A",
            "vi-VN-Neural2-D",
            "vi-VN-Standard-A",
            "vi-VN-Standard-B",
            "vi-VN-Standard-C",
            "vi-VN-Standard-D",
            "vi-VN-Wavenet-A",
            "vi-VN-Wavenet-B",
            "vi-VN-Wavenet-C",
            "vi-VN-Wavenet-D"
        };

        private readonly GoogleClientOptions _options;
        private readonly TranslationClient _translationClient;
        private readonly TextToSpeechClient _ttsClient;

        public GoogleClient(GoogleClientOptions options)
        {
            _options = options;
            var gc = GoogleCredential.FromJson(_options.Credentials);
            _translationClient = TranslationClient.Create(gc);

            _ttsClient = new TextToSpeechClientBuilder
            {
                GoogleCredential = gc
            }.Build();
        }

        public async Task<bool> TextToSpeechAsync(string text, string voiceName, string destination)
        {
            if (!SupportedTtsVoiceNames.Contains(voiceName)) return false;

            var destFolder = Path.GetDirectoryName(destination);
            if (destFolder == null) return false;

            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var input = new SynthesisInput
            {
                Text = text
            };
            // Build a language code from voiceName.
            // e.g., de-DE-Neural2-A > de-DE
            var vals = voiceName.Split('-');
            var langCode = $"{vals[0]}-{vals[1]}";
            var voiceSelection = new VoiceSelectionParams
            {
                LanguageCode = langCode,
                Name = voiceName
            };
            var audioConfig = new AudioConfig
            {
                AudioEncoding = AudioEncoding.Mp3
            };
            var response =
                await _ttsClient.SynthesizeSpeechAsync(input, voiceSelection, audioConfig);

            Directory.CreateDirectory(destFolder);
            using (var output = File.Create(destination))
            {
                response.AudioContent.WriteTo(output);
            }

            return true;
        }

        public async Task<string> TranslateAsync(string text, string from, string to)
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            var result = await _translationClient.TranslateTextAsync(text, to, from);
            return result.TranslatedText;
        }
    }
}