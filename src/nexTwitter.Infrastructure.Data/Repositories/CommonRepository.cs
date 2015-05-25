using nexTwitter.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nexTwitter.Domain;
using nexTwitter.Infrastructure.Enums;
using System.Linq.Expressions;
using Microsoft.Data.Entity;

namespace nexTwitter.Infrastructure.Data.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly DataContext _db;
        public CommonRepository(DataContext db)
        {
            _db = db;
        }
        public void Delete<TEntity>(TEntity instance) where TEntity : BaseEntity
        {
            instance.IsDeleted = false;
            _db.Entry<TEntity>(instance).State = EntityState.Modified;

            _db.SaveChanges();
        }

        public IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity
        {
            return GetAllAsQueryable<TEntity>().Where(predicate).Where(x => x.IsDeleted == false);
        }

        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : BaseEntity
        {
            return _db.Set<TEntity>().ToList();
        }

        public IQueryable<TEntity> GetAllAsQueryable<TEntity>() where TEntity : BaseEntity
        {
            return _db.Set<TEntity>().AsQueryable();
        }

        public TEntity GetById<TEntity>(int id) where TEntity : BaseEntity
        {
            return _db.Set<TEntity>().Where(x => x.Id == id && !x.IsDeleted).SingleOrDefault();
        }

        public PagedResult<TEntity> GetPaged<TEntity>(int page, int pageSize, OrderBy orderBy = OrderBy.Ascending, Expression<Func<TEntity, bool>> expr = null) where TEntity : BaseEntity
        {
            var result = new PagedResult<TEntity>();

            var query = GetAllAsQueryable<TEntity>();

            query = query.Where(expr);

            var total = query.Count();

                if (orderBy == OrderBy.Ascending)
                    query = query.OrderBy(x=>x.DateCreated);
                else
                    query = query.OrderByDescending(x=>x.DateCreated);



            int pageIndex = page - 1;
            int skip = pageIndex * pageSize;
            result.Result = query.Skip(skip).Take(pageSize).ToList();
            result.Page = page;
            result.PageSize = pageSize;
            result.TotalCount = total;

            return result;
        }

        public T MaxBy<T, TEntity>(Expression<Func<TEntity, T>> expr = null) where TEntity : BaseEntity
        {
            return _db.Set<TEntity>().Max(expr);
        }

        public void Save<TEntity>(TEntity instance) where TEntity : BaseEntity
        {
            if (instance.Id == 0)
            {
                instance.IsActive = true;
                _db.Set<TEntity>().Add(instance);
            }
            else
            {
                _db.Entry<TEntity>(instance).State = EntityState.Modified;
            }

            _db.SaveChanges();
        }
    }
}
