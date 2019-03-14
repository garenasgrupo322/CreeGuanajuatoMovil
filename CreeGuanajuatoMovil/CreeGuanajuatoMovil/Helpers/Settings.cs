using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CreeGuanajuatoMovil.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants
        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        private const string IsLoggedInTokenKey = "isloggedid_key";
        private static readonly bool IsLoggedInTokenDefault = false;

        private const string idUserCurrentLogin = "idUserCurrentLogin";
        private static readonly int IdUserCurrentLoginToken = 0;

        private const string NameUserCurrentLogin = "NameUserCurrentLogin_key";
        private static readonly string NameUserCurrentLoginToken = string.Empty;

        private const string AccessTokenCurrentUser = "AccessTokenCurrentUser_key";
        private static readonly string AccessTokenCurrentUserToken = string.Empty;

        private const string AccessTokenTypeCurrentUser = "AccessTokenTypeCurrentUser_key";
        private static readonly string AccessTokenCurrentUserTokenType = string.Empty;

        private const string DateLogin = "DateLogin";
        private static readonly DateTime DateLoginDefault = DateTime.Now;

        private const string UserImageProfilerKey = "UserImageProfilerKey";
        private static readonly string UserImageProfilerDefault = string.Empty;
        #endregion


        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        public static bool IsLoggedIn
        {
            get { return AppSettings.GetValueOrDefault(IsLoggedInTokenKey, IsLoggedInTokenDefault); }
            set { AppSettings.AddOrUpdateValue(IsLoggedInTokenKey, value); }
        }

        public static string UserImageProfiler
        {
            get { return AppSettings.GetValueOrDefault(UserImageProfilerKey, UserImageProfilerDefault); }
            set { AppSettings.AddOrUpdateValue(UserImageProfilerKey, value); }
        }

        public static DateTime IsDateLogin
        {
            get { return AppSettings.GetValueOrDefault(DateLogin, DateLoginDefault); }
            set { AppSettings.AddOrUpdateValue(DateLogin, value); }
        }

        public static int IdUserLogin
        {
            get { return AppSettings.GetValueOrDefault(idUserCurrentLogin, IdUserCurrentLoginToken); }
            set { AppSettings.AddOrUpdateValue(idUserCurrentLogin, value); }
        }

        public static string NameUserLogin
        {
            get { return AppSettings.GetValueOrDefault(NameUserCurrentLogin, NameUserCurrentLoginToken); }
            set { AppSettings.AddOrUpdateValue(NameUserCurrentLogin, value); }
        }

        public static string AccessToken
        {
            get { return AppSettings.GetValueOrDefault(AccessTokenCurrentUser, AccessTokenCurrentUserToken); }
            set { AppSettings.AddOrUpdateValue(AccessTokenCurrentUser, value); }
        }

        public static string AccessTokenType
        {
            get { return AppSettings.GetValueOrDefault(AccessTokenTypeCurrentUser, AccessTokenCurrentUserTokenType); }
            set { AppSettings.AddOrUpdateValue(AccessTokenTypeCurrentUser, value); }
        }
    }
}
