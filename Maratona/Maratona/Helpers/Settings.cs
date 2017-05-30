using Maratona.Models;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Maratona.Helpers
{
    public static class Settings
    {
        private static ISettings AppCurrent => CrossSettings.Current;

        private const string UserIdKey = "userid";
        private static readonly string UserIdDefault = string.Empty;

        private const string AuthTokenKey = "authtoken";
        private static readonly string AuthTokenDefault = string.Empty;

        public static string UserId
        {
            get => AppCurrent.GetValueOrDefault<string>(UserIdKey, UserIdDefault);
            set => AppCurrent.AddOrUpdateValue<string>(UserIdKey, value);
        }

        public static string AuthToken
        {
            get => AppCurrent.GetValueOrDefault<string>(AuthTokenKey, AuthTokenDefault);
            set => AppCurrent.AddOrUpdateValue<string>(AuthTokenKey, value);
        }

        public static bool IsLoggedIn = !string.IsNullOrWhiteSpace(UserId);

        public static FacebookUser FacebookUser { get; set; }
    }
}