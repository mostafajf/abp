using Volo.Abp.Modularity;
using Volo.Saas;
using Volo.Payment;

namespace abp_ms_test.SaasService;

[DependsOn(
    typeof(SaasServiceDomainSharedModule),
    typeof(SaasDomainModule),
    typeof(AbpPaymentDomainModule)
)]
public class SaasServiceDomainModule : AbpModule
{
}
