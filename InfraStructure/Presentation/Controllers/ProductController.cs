using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController(IServiceManager _serviceManager): ControllerBase
    {
        #region Get all products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProduct()
        {
            var products = await _serviceManager.ProductService.GetAllProductsAsync();
            return Ok(products);
        }
        #endregion

        #region Get Product by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var products=await _serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(products);
        }
        #endregion

        #region Get All Types
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes()
        {
            var Types = await _serviceManager.ProductService.GetAllTypesAsync();
            return Ok(Types);
        }
        #endregion

        #region Get All Brands
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands() {
            var Brands = await _serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(Brands);
            
        }
        #endregion
    }
}
