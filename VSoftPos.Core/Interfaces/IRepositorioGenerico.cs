using Pos.Core.Enumerables;
using Pos.Core.Modelos;
using System.Linq.Expressions;

namespace Pos.Core.Interfaces
{
    public interface IRepositorioGenerico<TEntity, TKey> where TEntity : class
    {
        Task<ResponseResult> GetAllAsync(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);

        Task<ResponseResult> GetAllAsync(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            params Expression<Func<TEntity, object>>[] includes);

        Task<ResponseResult> FindAsync(
           Expression<Func<TEntity, bool>> filter,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);

        Task<ResponseResult> FindAsync(
           Expression<Func<TEntity, bool>> filter,
           params Expression<Func<TEntity, object>>[] includes);

        Task<ResponseResult> FindAsync(
           Expression<Func<TEntity, bool>> filter,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
           params Expression<Func<TEntity, object>>[] includes);

        Task<ResponseResult> FindAndPagingAsync(
           RequestFilter requestFilter,
           Expression<Func<TEntity, bool>> filter,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderByl);

        Task<ResponseResult> FindAndPagingAsync(
           RequestFilter requestFilter,
           Expression<Func<TEntity, bool>> filter,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
           params Expression<Func<TEntity, object>>[] includes);

        Task<ResponseResult> GetByIdAsync(TKey id);

        Task<ResponseResult> PostAsync(TEntity item);

        Task<ResponseResult> PostRangeAsync(TEntity[] items);

        Task<ResponseResult> PutAsync(TEntity item);

        Task<ResponseResult> PutRangeAsync(TEntity[] items);

        Task<ResponseResult> DeleteAsync(TEntity item);

        Task<ResponseResult> DeleteRangeAsync(TEntity[] items);

        Task<ResponseResult> CreateOrUpdateLogAsync(
            DbStoredProcedure storedProcedure, long entityId, string? usuarioCodigo, bool updated);
    }
}
