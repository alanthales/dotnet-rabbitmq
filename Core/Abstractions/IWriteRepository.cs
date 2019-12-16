using System.Threading.Tasks;

namespace Core.Abstractions
{
    public interface IWriteRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        ValueTask Update(TEntity entity);
        ValueTask Delete(TEntity entity);
        Task<int> Save();
    }
}