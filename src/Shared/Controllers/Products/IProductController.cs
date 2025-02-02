﻿using Bit.TemplatePlayground.Shared.Dtos.Products;

namespace Bit.TemplatePlayground.Shared.Controllers.Products;

[Route("api/[controller]/[action]/"), AuthorizedApi]
public interface IProductController : IAppController
{
    [HttpGet("{id}")]
    Task<ProductDto> Get(Guid id, CancellationToken cancellationToken);

    [HttpPost]
    Task<ProductDto> Create(ProductDto dto, CancellationToken cancellationToken);

    [HttpPut]
    Task<ProductDto> Update(ProductDto dto, CancellationToken cancellationToken);

    [HttpDelete("{id}/{concurrencyStamp}")]
    Task Delete(Guid id, string concurrencyStamp, CancellationToken cancellationToken);

    [HttpGet]
    Task<PagedResult<ProductDto>> GetProducts(CancellationToken cancellationToken) => default!;

    [HttpGet]
    Task<List<ProductDto>> Get(CancellationToken cancellationToken) => default!;
}
