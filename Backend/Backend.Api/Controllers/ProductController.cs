using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Api.Contracts.Abstract;
using Backend.Domain.Data;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller, IProductApi
    {
        [HttpGet(nameof(GetAllProduct))]
        public async Task<List<Product>> GetAllProduct()
        {
            await Task.CompletedTask;
            return new List<Product>(){
                new Product(){ Id = 1 ,Name = "Ürün 1" },
                new Product(){ Id = 2 ,Name = "Ürün 2" },
                new Product(){ Id = 3 ,Name = "Ürün 3" },
                new Product(){ Id = 4 ,Name = "Ürün 4" },
                new Product(){ Id = 5 ,Name = "Ürün 5" }
           };
        }
    }
}