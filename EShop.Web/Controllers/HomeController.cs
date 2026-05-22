using EShop.DataLayer.EfCode;
using EShop.ServiceLayer.ProductServices;
using EShop.ServiceLayer.ProductServices.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShop.Web.Controllers
{
    public class HomeController : BaseTraceController
    {
        private readonly EfDbContext _context;

        public HomeController(EfDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(SortFilterPageOptions options)
        {
            var listService = new ListProductsService(_context);
            var productsList = await listService.SortFilterPage(options).ToArrayAsync();

            SetupTraceInfo();

            return View(new ProductListCombinedDto(options, productsList));
        }

        [HttpGet]
        public JsonResult GetFilterSearchContent (SortFilterPageOptions options)
        {
            var service = new ProductFilterDropdownService(_context);
            return Json(new { result = service.GetFilterDropDownValues(options.FilterBy) });
        }
    }
}