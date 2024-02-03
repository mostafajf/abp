using abp_ms_test.AdministrationService;
using abp_ms_test.AdministrationService.EntityFrameworkCore;
using abp_ms_test.IdentityService;
using abp_ms_test.IdentityService.EntityFrameworkCore;
using abp_ms_test.ProductService;
using abp_ms_test.ProductService.EntityFrameworkCore;
using abp_ms_test.SaasService;
using abp_ms_test.SaasService.EntityFrameworkCore;
using abp_ms_test.Shared.Hosting;
using Volo.Abp.Modularity;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Timing;
using System;

namespace abp_ms_test.DbMigrator;

[DependsOn(
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(abp_ms_testSharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(ProductServiceEntityFrameworkCoreModule)
)]
public class abp_ms_testDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "abp_ms_test:"; });
        Configure<AbpClockOptions>(options =>
       {
           options.Kind = DateTimeKind.Utc;
       });
    }
}
