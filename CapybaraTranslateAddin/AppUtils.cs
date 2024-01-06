using System;
using System.IO;

namespace CapybaraTranslateAddin
{
    public static class AppUtils
    {
        public static string GetAddinFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "CapybaraTranslateAddin");
        }

        public static string GetAddinConfigJsonPath()
        {
            return Path.Combine(GetAddinFolder(), "config.json");
        }

        public static string GetDefaultSoundFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                "sound");
        }

    }
}