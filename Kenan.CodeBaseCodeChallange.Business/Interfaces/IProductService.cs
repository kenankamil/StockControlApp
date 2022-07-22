using Kenan.CodeBaseCodeChallange.Dtos.ProductDtos;
using Kenan.CodeBaseCodeChallange.Entities;

namespace Kenan.CodeBaseCodeChallange.Business.Interfaces
{
    public interface IProductService : IService<ProductCreateDto, ProductListDto, Product>
    {
        Task UpdateAsync(ProductUpdateDto productUpdateDto);
    }
}
