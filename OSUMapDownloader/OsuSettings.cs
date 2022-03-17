using System.Configuration;

namespace OSUMapDownloader
{
    class OsuSettings : ApplicationSettingsBase
    {
        [UserScopedSetting(), DefaultSettingValue("")]
        public Token? token
        {
            get
            {
                try
                {
                    return this["token"] as Token;
                } catch (SettingsPropertyNotFoundException)
                {
                    return null;
                }
            }

            set
            {
                this["token"] = value;
            }
        }

        [UserScopedSetting(), DefaultSettingValue("")]
        public string? saveLocationPath {
            get 
            {
                if (String.IsNullOrEmpty((string)this["saveLocationPath"]))
                    return (string)Path.Combine(Application.StartupPath, "download").ToString();

                return (string)this["saveLocationPath"];
            }
            set {
                this["saveLocationPath"] = value;
            }
        }

        [UserScopedSetting(), DefaultSettingValue("3")]
        public int? workerCount
        {
            get
            {
                return (int)this["workerCount"];
            }
            set
            {
                this["workerCount"] = value;
            }
        }

        [UserScopedSetting(), DefaultSettingValue("true")]
        public bool enableFileWatch
        {
            get
            {
                return (bool)this["enableFileWatch"];
            }
            set
            {
                this["enableFileWatch"] = value;
            }
        }

        [UserScopedSetting(), DefaultSettingValue("true")]
        public bool hideDownloaded
        {
            get
            {
                return (bool)this["hideDownloaded"];
            }
            set
            {
                this["hideDownloaded"] = value;
            }
        }
    }
}
