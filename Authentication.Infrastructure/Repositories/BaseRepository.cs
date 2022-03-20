using System.Linq.Expressions;

public class BaseRepository<T> : IRepository<T> where T : Entity
    {
        private readonly AuthenticationContext _context;
        public BaseRepository(AuthenticationContext context)
        {
            _context = context;
        }
        public async Task Delete(T entity)
        {
            _context.Remove<T>(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(long entityId)
        {
            var entity = await _context.FindAsync<T>(entityId);
            return entity;
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter)
        {
            var entities = await GetAll(@filter);
            return entities.FirstOrDefault();
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> @filter)
        {
            await Task.CompletedTask;
            var entities = _context.Set<T>().Where(filter);
            return entities.ToList();
        }

        public async Task Insert(T entity)
        {
            await _context.AddAsync<T>(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Update<T>(entity);
            await _context.SaveChangesAsync();
        }
    }