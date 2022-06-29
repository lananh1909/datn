using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using HospitalManagement.Business.Entities;
using HospitalManagement.Business.EyeHospital;

namespace HospitalManagement.Business
{
    [DependsOn(
        typeof(BusinessCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BusinessApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<PatientDto, PatientAddAndUpdateDto>();
                config.CreateMap<SurgeryUpdateDto, Surgery>().ForMember(x => x.AttackUrl, o => o.Ignore())
                .ForMember(x => x.SurgeryDoctors, o => o.Ignore());
                config.CreateMap<UpdateTestDto, Test>();
                config.CreateMap<PrescriptionAddAndUpdateDto, Prescription>().ForMember(x => x.PrescriptionMedicines, o => o.Ignore());
            });
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BusinessApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
