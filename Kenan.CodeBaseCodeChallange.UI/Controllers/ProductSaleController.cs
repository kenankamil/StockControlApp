using Kenan.CodeBaseCodeChallange.Business.Interfaces;
using Kenan.CodeBaseCodeChallange.Dtos.ProductSaleDtos;
using Microsoft.AspNetCore.Mvc;

namespace Kenan.CodeBaseCodeChallange.UI.Controllers
{
    public class ProductSaleController : Controller
    {
        private readonly IProductSaleService _productSaleService;

        public ProductSaleController(IProductSaleService productSaleService)
        {
            _productSaleService = productSaleService;
        }

        public IActionResult ProductSaleList()
        {
            return View(new List<ProductSaleListDto>());
        }

        [HttpPost]
        public async Task<IActionResult> ProductSaleList(DateTime startDate, DateTime endDate)
        {
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            if (startDate >= endDate)
            {
                ViewBag.Error = "Başlangıç tarihi bitiş tarihine eşit yada büyük olamaz";
                return View(new List<ProductSaleListDto>());
            }
            var data = await _productSaleService.GetListBetweenTwoDates(startDate, endDate);
            return View(data);
        }
    }
}
