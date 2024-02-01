using System;
using Volo.Abp.Application.Dtos;

namespace abp_ms_test.ProductService.Products;

public class ProductDto : ExtensibleFullAuditedEntityDto<Guid>
{
    public string Name { get; set; } = default!;

    public float Price { get; set; }
}
