using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.Abstractions
{
    public interface IReadRepository<TEntity> where TEntity : class
    {
         Task<TEntity> GetById(object id);
         Task<TEntity[]> Get();
         Task<TEntity[]> Where(Expression<Func<TEntity,Boolean>> expression);
    }
}