using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Domain.Data;
using NetCoreStack.Contracts;

namespace Backend.Api.Contracts.Abstract
{
    [ApiRoute("api/[controller]", regionKey: "Main")]
    public interface IProductApi : IApiContract
    {
        Task<List<Product>> GetAllProduct();
    }
}