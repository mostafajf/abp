using abp_ms_test.ProductService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace abp_ms_test.ProductService;

public abstract class ProductServiceController : AbpController
{
    protected ProductServiceController()
    {
        LocalizationResource = typeof(ProductServiceResource);
    }
}
