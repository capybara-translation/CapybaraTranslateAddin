using System;
using System.Deployment.Application;
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

        public static string GetAddinVersion()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            }

            return "development mode";
        }
    }
}