using TodoAPI.Data.Entities;

namespace TodoAPI.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly TodoDbContext _todoDbContext;

        public BaseRepository(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }

        public List<T> GetAll()
        {
            return _todoDbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _todoDbContext.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            _todoDbContext.Set<T>().Add(entity);
            _todoDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _todoDbContext.Set<T>().Update(entity);
            _todoDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);

            _todoDbContext.Set<T>().Remove(entity);
            _todoDbContext.SaveChanges();
        }
    }
}
