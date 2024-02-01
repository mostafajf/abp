using abp_ms_test.ProductService.Localization;
using Volo.Abp.Application.Services;

namespace abp_ms_test.ProductService;

public abstract class ProductServiceAppService : ApplicationService
{
    protected ProductServiceAppService()
    {
        LocalizationResource = typeof(ProductServiceResource);
        ObjectMapperContext = typeof(ProductServiceApplicationModule);
    }
}
