using nexTwitter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using nexTwitter.Infrastructure.Enums;

namespace nexTwitter.Domain.IRepositories
{
		public interface ICommonRepository
		{
			IEnumerable<TEntity> GetAll<TEntity>() where TEntity : BaseEntity;
			IQueryable<TEntity> GetAllAsQueryable<TEntity>() where TEntity : BaseEntity;
			TEntity GetById<TEntity>(int id) where TEntity : BaseEntity;
			T MaxBy<T, TEntity>(Expression<Func<TEntity, T>> expr = null) where TEntity : BaseEntity;
			void Save<TEntity>(TEntity instance) where TEntity : BaseEntity;
			void Delete<TEntity>(TEntity instance) where TEntity : BaseEntity;
			PagedResult<TEntity> GetPaged<TEntity>(int page, int pageSize, OrderBy orderBy = OrderBy.Ascending, Expression<Func<TEntity, bool>> expr = null) where TEntity : BaseEntity;
			IQueryable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseEntity;
		}
}