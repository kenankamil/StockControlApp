using AutoMapper;
using FluentValidation;
using Kenan.CodeBaseCodeChallange.Business.Interfaces;
using Kenan.CodeBaseCodeChallange.DataAccess.UnitOfWork;
using Kenan.CodeBaseCodeChallange.Dtos.ProductDtos;
using Kenan.CodeBaseCodeChallange.Entities;

namespace Kenan.CodeBaseCodeChallange.Business.Services
{
    public class ProductService : Service<ProductCreateDto, ProductListDto, Product>, IProductService
    {
        private readonly IUoW _uoW;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IUoW uoW) : base(mapper, uoW)
        {
            _uoW = uoW;
            _mapper = mapper;
        }

        public async Task UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var entity = _mapper.Map<Product>(productUpdateDto);
            _uoW.GetRepository<Product>().Update(entity);
            await _uoW.SaveChangesAsync();
        }
    }
}
