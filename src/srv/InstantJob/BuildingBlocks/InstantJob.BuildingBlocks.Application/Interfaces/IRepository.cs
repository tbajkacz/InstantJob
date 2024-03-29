﻿using System.Collections.Generic;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.BuildingBlocks.Application.Interfaces
{
    public interface IRepository<TEntity, TId> where TEntity : BaseEntity<TId>
    {
        IEnumerable<TEntity> Get();

        TEntity GetById(TId id);

        TEntity GetByIdOrDefault(TId id);

        Task<TEntity> GetByIdAsync(TId id);

        Task<TEntity> GetByIdOrDefaultAsync(TId id);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TId id);
    }
}
