using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Authentication.Test.Mocks
{
    public class BaseServiceMock<T> : IService<T> where T : Entity
    {
        private readonly IRepository<T> _repository;

        public BaseServiceMock(IRepository<T> repository)
        {
            _repository = repository;
        }

        public Task Delete(T entity)
        {
            return _repository.Delete(entity);
        }

        public Task<T> Get(long entityId)
        {
            return _repository.Get(entityId);
        }

        public Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return _repository.Get(filter);
        }

        public Task<IList<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            return _repository.GetAll(filter);
        }

        public Task Insert(T entity)
        {
            return _repository.Insert(entity);
        }

        public Task Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}
