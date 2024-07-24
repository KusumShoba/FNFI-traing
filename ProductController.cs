using Microsoft.AspNetCore.Mvc;
using SampleMvcApp.Models;

namespace SampleMvcApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _productDbContext;

        public ProductController(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public IActionResult AllProducts()
        {
            var products = _productDbContext.Products.ToList();
            return View(products);
        }
    }
}
