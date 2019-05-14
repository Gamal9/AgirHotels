using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AgirHotels.Helper
{
    public static class AppSettings
    {
        private static ISettings Settings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        private const string LastUserKey = "last_User_key";
        private static readonly int UserSettings = 0;
        public static int LastUserID
        {
            get
            =>
                 Settings.GetValueOrDefault(LastUserKey, UserSettings);


            set
            =>
                Settings.AddOrUpdateValue(LastUserKey, value);

        }
    }

}
