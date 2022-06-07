using HospitalManagement.Business.Debugging;

namespace HospitalManagement.Business
{
    public class BusinessConsts
    {
        public const string LocalizationSourceName = "Business";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "5dacc573d4264578b1193a76a1fae72e";
    }
}
