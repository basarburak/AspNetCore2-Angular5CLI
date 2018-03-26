using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Api.Contracts.Route;
using Backend.Domain.Data;
using NetCoreStack.Contracts;

namespace Backend.Api.Contracts.Abstract
{
    [ApiRoute("api/[controller]", regionKey: nameof(RegionKey.Main))]
    public interface IProductApi : IApiContract
    {
        Task<List<Product>> GetAllProduct();
    }
}