using TodoAPI.Data.Entities;

namespace TodoAPI.Data.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoDbContext _todoDbContext;
        public TodoRepository(TodoDbContext todoDbContext)
        {
            _todoDbContext = todoDbContext;
        }
    }
}
