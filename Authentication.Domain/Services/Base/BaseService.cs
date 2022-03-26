using System.Linq.Expressions;

public class BaseService<T> : IService<T> where T : Entity
    {
        private readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task Delete(T entity)
        {
            await _repository.Delete(entity);
        }

        public async Task<T> Get(long entityId)
        {
            var entity = await _repository.Get(entityId);
            return entity;
        }

        public async Task<T> Get(Expression<Func<T, bool>> @filter)
        {
            var entities = await GetAll(@filter);
            return entities.FirstOrDefault();
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            return await _repository.GetAll(@filter);
        }

        public async Task Insert(T entity)
        {
            await _repository.Insert(entity);
        }

        public async Task Update(T entity)
        {
            entity.UpdateDate = DateTime.Now.ToUniversalTime();
            await _repository.Update(entity);
        }
    }