using AutoMapper;
using abp_ms_test.ProductService.Products;

namespace abp_ms_test.ProductService;

public class ProductServiceApplicationAutoMapperProfile : Profile
{
    public ProductServiceApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>().MapExtraProperties();
    }
}
