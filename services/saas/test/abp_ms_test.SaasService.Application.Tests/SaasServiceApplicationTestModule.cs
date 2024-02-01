using abp_ms_test.SaasService.Application;
using Volo.Abp.Modularity;

namespace abp_ms_test.SaasService;

[DependsOn(
    typeof(SaasServiceApplicationModule),
    typeof(SaasServiceDomainTestModule)
    )]
public class SaasServiceApplicationTestModule : AbpModule
{

}
