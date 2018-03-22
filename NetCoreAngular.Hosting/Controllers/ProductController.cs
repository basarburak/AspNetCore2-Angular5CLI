using System.Threading.Tasks;
using Backend.Api.Contracts.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngular.Hosting.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductApi _productApi;
        public ProductController(IProductApi productApi)
        {
            _productApi = productApi;
        }
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            return Json(await _productApi.GetAllProduct());
        }
    }
}