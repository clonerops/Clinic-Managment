using System.Linq.Expressions;

namespace _0_Framework.Infrastructure
{
    public interface IRepository<TKey, T> where T : class
    {
        T Get(TKey id);
        List<T> Get();
        void Create(T entity);
        void SaveChanges();
        bool Exist(Expression<Func<T, bool>> expression);

    }
}
