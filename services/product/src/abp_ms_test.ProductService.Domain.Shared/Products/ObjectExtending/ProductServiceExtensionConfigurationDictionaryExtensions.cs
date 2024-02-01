using System;
using Volo.Abp.ObjectExtending.Modularity;

namespace abp_ms_test.ProductService.Products.ObjectExtending;

public static class ProductServiceExtensionConfigurationDictionaryExtensions
{
    public static ModuleExtensionConfigurationDictionary ConfigureProductService(
        this ModuleExtensionConfigurationDictionary modules,
        Action<ProductServiceExtensionConfiguration> configureAction)
    {
        return modules.ConfigureModule(
            ProductServiceExtensionConsts.ModuleName,
            configureAction
        );
    }
}