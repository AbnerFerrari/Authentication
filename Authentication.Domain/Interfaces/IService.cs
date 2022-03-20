using System.Linq.Expressions;

public interface IService<T> where T : class
{
    public Task Insert(T entity);
    public Task Update(T entity);
    public Task Delete(T entity);
    public Task<T> Get(long entityId);
    public Task<T> Get(Expression<Func<T, bool>> @filter);
    public Task<IList<T>> GetAll(Expression<Func<T, bool>> @filter);
}