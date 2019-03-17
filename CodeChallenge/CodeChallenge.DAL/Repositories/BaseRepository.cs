using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.DAL.Repositories
{
    public class BaseRepository<TEntity, T> where TEntity : BaseEntity<T> where T :
        struct, IComparable, IFormattable, IComparable<T>, IEquatable<T>
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> Get()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(T id)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? entity : null;
        }

        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entityList)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entityList);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0 ? entityList : null;
        }

        public async Task DeleteAsync(T id)
        {
            var entity = await GetByIdAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
