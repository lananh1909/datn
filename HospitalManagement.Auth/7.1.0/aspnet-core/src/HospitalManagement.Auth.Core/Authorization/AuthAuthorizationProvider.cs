using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace HospitalManagement.Auth.Authorization
{
    public class AuthAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            context.CreatePermission(PermissionNames.Pages_Employees, L("Employees"))
                .CreateChildPermission(PermissionNames.Pages_Employees_Create, L("Employees"))
                .CreateChildPermission(PermissionNames.Pages_Employees_Update, L("Employees"))
                .CreateChildPermission(PermissionNames.Pages_Employees_Delete, L("Employees"));
            context.CreatePermission(PermissionNames.Pages_MedicalRecords, L("MedicalRecords"))
                .CreateChildPermission(PermissionNames.Pages_MedicalRecords_Create, L("MedicalRecords"))
                .CreateChildPermission(PermissionNames.Pages_MedicalRecords_Update, L("MedicalRecords"))
                .CreateChildPermission(PermissionNames.Pages_MedicalRecords_Delete, L("MedicalRecords"));
            context.CreatePermission(PermissionNames.Pages_Patient, L("Patients"))
                .CreateChildPermission(PermissionNames.Pages_Patient_Create, L("Patients"))
                .CreateChildPermission(PermissionNames.Pages_Patient_Update, L("Patients"))
                .CreateChildPermission(PermissionNames.Pages_Patient_Delete, L("Patients"));
            context.CreatePermission(PermissionNames.Pages_Presciptions, L("Prescriptions"))
                .CreateChildPermission(PermissionNames.Pages_Presciptions_Create, L("Prescriptions"))
                .CreateChildPermission(PermissionNames.Pages_Presciptions_Update, L("Prescriptions"))
                .CreateChildPermission(PermissionNames.Pages_Presciptions_Delete, L("Prescriptions"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AuthConsts.LocalizationSourceName);
        }
    }
}
