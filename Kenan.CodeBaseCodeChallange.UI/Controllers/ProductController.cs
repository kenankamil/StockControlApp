using AutoMapper;
using Kenan.CodeBaseCodeChallange.Business.Interfaces;
using Kenan.CodeBaseCodeChallange.Dtos.ProductDtos;
using Kenan.CodeBaseCodeChallange.Dtos.ProductSaleDtos;
using Kenan.CodeBaseCodeChallange.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kenan.CodeBaseCodeChallange.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductSaleService _productSaleService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper, IProductSaleService productSaleService)
        {
            _productService = productService;
            _mapper = mapper;
            _productSaleService = productSaleService;
        }
        public async Task<IActionResult> ListProduct()
        {
            var data = await _productService.GetAllAsync();
            return View(data);
        }
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateModel productCreateModel)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<ProductCreateDto>(productCreateModel);
                var createResponse = await _productService.CreateAsync(dto);
                return RedirectToAction("ListProduct");
            }
            return View(productCreateModel);
        }
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var dto = await _productService.GetByIdAsync<ProductListDto>(id);
            var model = _mapper.Map<ProductUpdateModel>(dto);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(ProductUpdateModel productUpdateModel)
        {
            if (ModelState.IsValid)
            {
                var dto = _mapper.Map<ProductUpdateDto>(productUpdateModel);
                await _productService.UpdateAsync(dto);
                return RedirectToAction("ListProduct");
            }
            return View(productUpdateModel);
        }

        public async Task<IActionResult> SellProduct(int id)
        {
            var model = new ProductSaleCreateModel { ProductId = id };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SellProduct(ProductSaleCreateModel model)
        {
            var dto = _mapper.Map<ProductSaleCreateDto>(model);
            if (await _productSaleService.CheckStockAsync(dto))
            {
                var product = await _productService.GetByIdAsync<ProductListDto>(dto.ProductId);
                var updateDto = _mapper.Map<ProductUpdateDto>(product);
                updateDto.Stock -= dto.SaleCount;
                await _productService.UpdateAsync(updateDto);
                await _productSaleService.CreateAsync(dto);

                return RedirectToAction("ListProduct");
            }

            else
            {
                ViewBag.ErrorMessage = "Sales quantity cannot be greater than stock";
            }
            return View(model);
        }
        public async Task<IActionResult> RemoveProduct(int id)
        {
            await _productService.RemoveAsync(id);
            return RedirectToAction("ListProduct");
        }
    }
}
