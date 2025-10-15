using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServiceAbstraction;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService(IUnitOfWork _unitOfWork,IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var Repo=_unitOfWork.GetRepository<ProductBrand,int>();
            var Brands = await Repo.GetAllASync();
            var brandsDto=_mapper.Map<IEnumerable<ProductBrand>,IEnumerable<BrandDto>> (Brands);
            return brandsDto; 
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllASync();
            return _mapper.Map<IEnumerable<Product>,IEnumerable<ProductDto>> (products);
        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var Types =await _unitOfWork.GetRepository<ProductType, int>().GetAllASync();
            return _mapper.Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(Types);
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product =await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(id);
            return _mapper.Map<Product, ProductDto>(product);

        }
    }
}
