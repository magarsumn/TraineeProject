
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HRApp.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HRApp.Server.Repository
{
    public class RepositoryWithTypedId<T, TId> : IRepositoryWithTypedId<T, TId> where T : class, IEntityWithTypedId<TId>
    {
        public RepositoryWithTypedId(ApplicationDbContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();
        }

        protected DbContext Context { get; }

        protected DbSet<T> DbSet { get; }

        public void Add(T entity)
        {
            if (entity != null)
                DbSet.Add(entity);
        }

        public void AddRange(IList<T> entities)
        {
            if (entities != null && entities.Count > 0) DbSet.AddRange(entities);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Context.Database.BeginTransaction();
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public IQueryable<T> Query()
        {
            return DbSet;
        }

        public void Remove(T entity)
        {
            if (entity != null)
                DbSet.Remove(entity);
        }


        public virtual IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] propertySelectors)
        {
            return DbSet.AsQueryable();
        }

        public virtual List<T> GetAllList()
        {
            return DbSet.ToList();
        }

        public virtual Task<List<T>> GetAllListAsync()
        {
            return Task.FromResult(GetAllList());
        }

        public virtual List<T> GetAllList(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public virtual Task<List<T>> GetAllListAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(GetAllList(predicate));
        }


        public virtual T Get(TId id)
        {
            var entity = FirstOrDefault(id);
            if (entity == null)
                throw new Exception($"There is no such an entity. Entity type: {typeof(T).FullName}, id: {id}");

            return entity;
        }

        public virtual async Task<T> GetAsync(TId id)
        {
            var entity = await FirstOrDefaultAsync(id);
            if (entity == null)
                throw new Exception($"There is no such an entity. Entity type: {typeof(T).FullName}, id: {id}");

            return entity;
        }

        public virtual T Single(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Single(predicate);
        }

        public virtual Task<T> SingleAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(Single(predicate));
        }

        public virtual T FirstOrDefault(TId id)
        {
            return DbSet.FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        public virtual Task<T> FirstOrDefaultAsync(TId id)
        {
            return Task.FromResult(FirstOrDefault(id));
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public virtual Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(FirstOrDefault(predicate));
        }

        public virtual T Load(TId id)
        {
            return Get(id);
        }


        public virtual Task<T> InsertAsync(T entity)
        {
            DbSet.Add(entity);
            Context.SaveChangesAsync();
            return Task.FromResult(entity);
        }

        public virtual TId InsertAndGetId(T entity)
        {
            DbSet.Add(entity);
           
            return Task.FromResult(entity).Result.Id;
        }

        public virtual async Task<TId> InsertAndGetIdAsync(T entity)
        {
            var insertedEntity = await InsertAsync(entity);
            return insertedEntity.Id;
        }


        public virtual Task<T> UpdateAsync(T entity)
        {
            if (entity != null)
                DbSet.Update(entity);
            Context.SaveChangesAsync();
            return Task.FromResult(entity);
        }

        public virtual T Update(TId id, Action<T> updateAction)
        {
            var entity = Get(id);
            updateAction(entity);
            return entity;
        }

        public virtual async Task<T> UpdateAsync(TId id, Func<T, Task> updateAction)
        {
            var entity = await GetAsync(id);
            await updateAction(entity);
            return entity;
        }


        public virtual Task DeleteAsync(T entity)
        {
            if (entity != null)
                DbSet.Remove(entity);
            return Task.CompletedTask;
        }


        public virtual Task DeleteAsync(TId id)
        {
            var entity = Get(id);
            if (entity != null)
                DbSet.Remove(entity);
            Context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            foreach (var entity in GetAllList(predicate))
                if (entity != null)
                    DbSet.Remove(entity);
        }

        public virtual async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = await GetAllListAsync(predicate);

            foreach (var entity in entities) await DeleteAsync(entity);
        }

        public virtual int Count()
        {
            return DbSet.Count();
        }

        public virtual Task<int> CountAsync()
        {
            return Task.FromResult(Count());
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Count(predicate);
        }

        public virtual Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(Count(predicate));
        }

        public virtual long LongCount()
        {
            return DbSet.LongCount();
        }

        public virtual Task<long> LongCountAsync()
        {
            return Task.FromResult(LongCount());
        }

        public virtual long LongCount(Expression<Func<T, bool>> predicate)
        {
            return DbSet.LongCount(predicate);
        }

        public virtual Task<long> LongCountAsync(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(LongCount(predicate));
        }

       
        public virtual IQueryable<T> Query(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable();
        }


        public T Insert(T entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            if (entity != null)
                DbSet.Remove(entity);
        }

        public void Delete(TId id)
        {
            var entity = Get(id);
            if (entity != null)
                DbSet.Remove(entity);
        }


        protected virtual Expression<Func<T, bool>> CreateEqualityExpressionForId(TId id)
        {
            var lambdaParam = Expression.Parameter(typeof(T));

            var leftExpression = Expression.PropertyOrField(lambdaParam, "Id");

            var idValue = Convert.ChangeType(id, typeof(TId));

            Expression<Func<object>> closure = () => idValue;
            var rightExpression = Expression.Convert(closure.Body, leftExpression.Type);

            var lambdaBody = Expression.Equal(leftExpression, rightExpression);

            return Expression.Lambda<Func<T, bool>>(lambdaBody, lambdaParam);
        }
    }
}