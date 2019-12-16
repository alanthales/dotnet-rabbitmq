using Core;
using Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gateway.EF
{
    public abstract class EFRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : EntityBase
    {
        protected readonly EFGateway _gateway;
        protected DbSet<T> DataSet { get => _gateway.Instance.Set<T>(); }
        public EFRepository(EFGateway gateway) => _gateway = gateway;

        public Task<T> GetById(object id)
        {
            var entityId = Guid.Parse(id.ToString());
            return DataSet.AsNoTracking().SingleOrDefaultAsync(e => e.Id == entityId);
        }

        public Task<T[]> Get()
        {
            return DataSet.AsNoTracking().ToArrayAsync();
        }

        public Task<T[]> Where(Expression<Func<T,Boolean>> expression)
        {
            return DataSet.AsNoTracking().Where(expression).ToArrayAsync();
        }

        public void Insert(T entity)
        {
            DataSet.Add(entity);
        }

        public async ValueTask Update(T entity)
        {
            var existing = await DataSet.FindAsync(entity.Id);
            if (existing != null)
            {
                existing.Map(entity);
            }
        }

        public async ValueTask Delete(T entity)
        {
            var existing = await DataSet.FindAsync(entity.Id);
            if (existing != null)
            {
                DataSet.Remove(existing);
            }
        }

        public Task<int> Save()
        {
            return _gateway.Instance.SaveChangesAsync();
        }
    }
}