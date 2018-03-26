using System;
using System.Threading.Tasks;
using Backend.Api.Contracts.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NetCoreAngular.Hosting.Controllers
{
    public class ProductController : BaseController
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