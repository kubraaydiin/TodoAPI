using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<TodoItem> GetAll()
        {
            var todos = _todoDbContext.TodoItems.ToList();
            return todos;
        }

        public TodoItem GetById(int id)
        {
            var todo = _todoDbContext.TodoItems.SingleOrDefault(x => x.Id == id);
            return todo;
        }

        public void Add(TodoItem todoItem)
        {
            _todoDbContext.TodoItems.Add(todoItem);
            _todoDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var todo = GetById(id);

            _todoDbContext.Remove(todo);
            _todoDbContext.SaveChanges();
        }

        public void Update(TodoItem todoItem)
        {
            _todoDbContext.TodoItems.Update(todoItem);
            _todoDbContext.SaveChanges();
        }
    }
}
