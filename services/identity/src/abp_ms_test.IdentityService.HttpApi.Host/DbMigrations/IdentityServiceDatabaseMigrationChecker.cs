using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using abp_ms_test.IdentityService.EntityFrameworkCore;
using abp_ms_test.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace abp_ms_test.IdentityService.DbMigrations;

public class IdentityServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<IdentityServiceDbContext>
{
    private readonly IdentityServiceDataSeeder _dataSeeder;

    public IdentityServiceDatabaseMigrationChecker(
        ILoggerFactory loggerFactory,
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus,
        IAbpDistributedLock abpDistributedLock,
        IdentityServiceDataSeeder dataSeeder) : base(
        loggerFactory,
        unitOfWorkManager,
        serviceProvider,
        currentTenant,
        distributedEventBus,
        abpDistributedLock,
        IdentityServiceDbProperties.ConnectionStringName)
    {
        _dataSeeder = dataSeeder;
    }

    public override async Task CheckAndApplyDatabaseMigrationsAsync()
    {
        await base.CheckAndApplyDatabaseMigrationsAsync();
        
        await TryAsync(async () => await _dataSeeder.SeedAsync());
    }
}