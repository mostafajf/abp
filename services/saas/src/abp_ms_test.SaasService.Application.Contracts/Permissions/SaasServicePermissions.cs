using Volo.Abp.Reflection;

namespace abp_ms_test.SaasService.Permissions;

public class SaasServicePermissions
{
    public const string GroupName = "SaasService";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(SaasServicePermissions));
    }
}
