using abp_ms_test.ProductService.Products;
using abp_ms_test.ProductService.Products.ObjectExtending;
using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.Threading;

namespace abp_ms_test.ProductService;

[DependsOn(
    typeof(ProductServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class ProductServiceApplicationContractsModule : AbpModule
{
    private readonly static OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }

    public override void PostConfigureServices(ServiceConfigurationContext context)
    {
        OneTimeRunner.Run(() =>
        {
            ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToApi(
                ProductServiceExtensionConsts.ModuleName,
                ProductServiceExtensionConsts.EntityNames.Product,
                getApiTypes: new[] { typeof(ProductDto) },
                createApiTypes: new[] { typeof(ProductCreateDto) },
                updateApiTypes: new[] { typeof(ProductUpdateDto) }
            );
        });
    }
}
