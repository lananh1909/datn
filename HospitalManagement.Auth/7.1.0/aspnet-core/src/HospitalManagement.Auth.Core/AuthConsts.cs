using HospitalManagement.Auth.Debugging;

namespace HospitalManagement.Auth
{
    public class AuthConsts
    {
        public const string LocalizationSourceName = "Auth";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "68d32688dbda4fb49e7acf1aff194cfe";
    }
}
