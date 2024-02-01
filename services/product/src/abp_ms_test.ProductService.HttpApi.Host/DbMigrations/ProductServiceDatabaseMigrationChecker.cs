using System;
using Microsoft.Extensions.Logging;
using abp_ms_test.ProductService.EntityFrameworkCore;
using abp_ms_test.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace abp_ms_test.ProductService.DbMigrations;

public class ProductServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<ProductServiceDbContext>
{
    public ProductServiceDatabaseMigrationChecker(
        ILoggerFactory loggerFactory,
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus,
        IAbpDistributedLock abpDistributedLock) : base(
        loggerFactory,
        unitOfWorkManager,
        serviceProvider,
        currentTenant,
        distributedEventBus,
        abpDistributedLock,
        ProductServiceDbProperties.ConnectionStringName)
    {
    }
}
