using DomainLayer.Contracts;
using DomainLayer.Models;
using Persistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _Repositories = [];
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            //1 get type Name
            var TypeName= typeof(TEntity).Name;

            if (_Repositories.TryGetValue(TypeName,out object? value))
            {
                return (IGenericRepository<TEntity, TKey>)value;
            }
            else
            {
                var Repo = new GenericRepository<TEntity, TKey>(_dbContext);
                //_Repositories["TypeName"] = Repo;
                _Repositories.Add(TypeName, Repo);
                return Repo;
            }
        }

        public async Task<int> SaveChangesAsync()
        
              => await _dbContext.SaveChangesAsync();
    }
}
