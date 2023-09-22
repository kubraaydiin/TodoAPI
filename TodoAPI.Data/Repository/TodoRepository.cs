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
        private readonly TodoContext _todoContext;
        public TodoRepository(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public List<TodoItem> GetAll()
        {
            var todos = _todoContext.TodoItems.ToList();
            return todos;
        }

        public TodoItem GetById(int id)
        {
            var todo = _todoContext.TodoItems.SingleOrDefault(x => x.Id == id);
            return todo;
        }

        public void Add(TodoItem todoItem)
        {
            _todoContext.TodoItems.Add(todoItem);
            _todoContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var todo = GetById(id);

            _todoContext.Remove(todo);
            _todoContext.SaveChanges();
        }

        public void Update(TodoItem todoItem)
        {
            _todoContext.TodoItems.Update(todoItem);
            _todoContext.SaveChanges();
        }
    }
}
