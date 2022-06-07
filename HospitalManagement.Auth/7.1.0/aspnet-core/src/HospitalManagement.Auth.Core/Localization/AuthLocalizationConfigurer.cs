using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace HospitalManagement.Auth.Localization
{
    public static class AuthLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AuthConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AuthLocalizationConfigurer).GetAssembly(),
                        "HospitalManagement.Auth.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
