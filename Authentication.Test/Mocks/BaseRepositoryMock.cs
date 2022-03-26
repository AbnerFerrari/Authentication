using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Authentication.Test.Mocks
{
    internal class BaseRepositoryMock<T> : IRepository<T> where T : Entity
    {
        public static List<T> Database = new();

        public Task Delete(T entity)
        {
            Database.Remove(entity);
            return Task.CompletedTask;
        }

        public Task<T> Get(long entityId)
        {
            return Task.FromResult(Database.Find(x => x.Id == entityId));
        }

        public Task<T> Get(Expression<Func<T, bool>> filter)
        {
            return Task.FromResult(Database.FirstOrDefault(filter.Compile()));
        }

        public Task<IList<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            IList<T> results = Database.Where(filter.Compile()).ToList();
            return Task.FromResult(results);
        }

        public Task Insert(T entity)
        {
            var lastEntity = Database.LastOrDefault();
            entity.Id = lastEntity?.Id + 1 ?? 1;
            Database.Add(entity);
            return Task.CompletedTask;
        }

        public Task Update(T entity)
        {
            var oldEntity = Database.First(x => x.Id == entity.Id);
            oldEntity = entity;
            return Task.CompletedTask;
        }
    }
}
