using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace HospitalManagement.Business.Localization
{
    public static class BusinessLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BusinessConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BusinessLocalizationConfigurer).GetAssembly(),
                        "HospitalManagement.Business.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
