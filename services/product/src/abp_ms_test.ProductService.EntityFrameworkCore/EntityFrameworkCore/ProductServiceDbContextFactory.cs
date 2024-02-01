using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace abp_ms_test.ProductService.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands)
 *
 * It is also used in the DbMigrator application.
 * */
public class ProductServiceDbContextFactory : IDesignTimeDbContextFactory<ProductServiceDbContext>
{
    private readonly string _connectionString;

    /* This constructor is used when you use EF Core tooling (e.g. Update-Database) */
    public ProductServiceDbContextFactory()
    {
        _connectionString = GetConnectionStringFromConfiguration();
    }

    public ProductServiceDbContext CreateDbContext(string[] args)
    {
        ProductServiceEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<ProductServiceDbContext>()
            .UseNpgsql(_connectionString, b =>
            {
                b.MigrationsHistoryTable("__ProductService_Migrations");
            });

        return new ProductServiceDbContext(builder.Options);
    }

    private static string GetConnectionStringFromConfiguration()
    {
        return BuildConfiguration().GetConnectionString(ProductServiceDbProperties.ConnectionStringName)!;
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    $"..{Path.DirectorySeparatorChar}abp_ms_test.ProductService.HttpApi.Host"
                )
            )
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
