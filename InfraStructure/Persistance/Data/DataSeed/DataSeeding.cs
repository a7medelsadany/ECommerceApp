using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistance.Data.DataSeed
{
    public class DataSeeding(StoreDbContext _dbContext) : IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            var PendingMigration =await _dbContext.Database.GetPendingMigrationsAsync();
            if (PendingMigration.Any())
            {
                _dbContext.Database.Migrate();
            }
            #region Data seed
            #region product Brand
            if (!_dbContext.ProductBrands.Any())
            {
                var BrandsData = File.OpenRead(@"..\InfraStructure\Persistance\Data\DataSeed\brands.json");
                var Brands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(BrandsData);
                if(Brands is not null && Brands.Any())
                {
                   await _dbContext.ProductBrands.AddRangeAsync(Brands);
                }
            }
            #endregion

            #region Product Type
            if (!_dbContext.ProductTypes.Any())
            {
                var TypeData=File.OpenRead(@"..\InfraStructure\Persistance\Data\DataSeed\types.json");
                var Types = await JsonSerializer.DeserializeAsync<List<ProductType>>(TypeData);
                if(Types is not null && Types.Any())
                {
                    await  _dbContext.ProductTypes.AddRangeAsync(Types);
                }
            }
            #endregion

            #region Products
            if (!_dbContext.Products.Any())
            {
                var productsData=File.OpenRead(@"..\InfraStructure\Persistance\Data\DataSeed\products.json");
                var products = await JsonSerializer.DeserializeAsync<List<Product>>(productsData);
                if(products is not null && products.Any())
                {
                   await _dbContext.Products.AddRangeAsync(products);
                }
            }
            #endregion

            await _dbContext.SaveChangesAsync();
            #endregion
        }
    }
}
