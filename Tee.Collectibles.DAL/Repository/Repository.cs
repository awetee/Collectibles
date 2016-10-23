﻿namespace Tee.Collectibles.DAL.Repository
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Tee.Collectibles.Common.Entities;
    using Tee.Collectibles.Common.Repository;

    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly DbContext context;
        private readonly DbSet<T> dbSet;

        public Repository(DbContext ctx)
        {
            this.context = ctx;
            this.dbSet = this.context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return this.dbSet.ToList();
        }

        public T Get(int id)
        {
            return this.dbSet.Find(id);
        }

        public int Add(T entity)
        {
            this.dbSet.Add(entity);
            this.context.SaveChanges();
            return entity.Id;
        }

        public void Update(T entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            this.context.SaveChanges();
        }

        public void Delete(T entity)
        {
            this.context.Entry(entity).State = EntityState.Deleted;
            this.context.SaveChanges();
        }
    }
}