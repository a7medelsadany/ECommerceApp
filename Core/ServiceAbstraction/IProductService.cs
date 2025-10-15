using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IProductService
    {
        //Get All products
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();

        //Get product by Id
        Task<ProductDto> GetProductByIdAsync(int id);

        //Get All Brands
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();

        //Get All Types
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();

    }
}
