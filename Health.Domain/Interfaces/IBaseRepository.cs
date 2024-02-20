﻿namespace Health.Domain.Interfaces;

public interface IBaseRepository<TEntity>
{
    Task<TEntity> Insert(TEntity obj);

    Task<IList<TEntity>> Select();

    Task<TEntity> Select(int id);

    Task<TEntity> Update(int id, TEntity obj);

    Task<TEntity> Delete(int id);

    Task<TEntity> SelectName(string name);
}