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
    }
}
