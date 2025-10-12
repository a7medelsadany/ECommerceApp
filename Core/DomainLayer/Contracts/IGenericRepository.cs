﻿using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracts
{
    public interface IGenericRepository<TEntity,TKey> where TEntity:BaseEntity<TKey>
    {
        //GetAll
        Task<IEnumerable<TEntity>> GetAllASync();

        //GetById
        Task<TEntity?> GetByIdAsync(TKey id);

        //Add
        Task AddAsync(TEntity entity);

        //update
        void Update(TEntity entity);

        //Delete
        void Remove(TEntity entity);

    }
}
