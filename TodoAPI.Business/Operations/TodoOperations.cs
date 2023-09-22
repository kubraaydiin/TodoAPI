using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Data.Entities;
using TodoAPI.Data.Repository;


namespace TodoAPI.Business.Operations
{
    public class TodoOperations : ITodoOperations
    {
        private readonly ITodoRepository _todoRepository;
        public TodoOperations(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public List<TodoItem> Todos()
        {
            var todos = _todoRepository.GetAll();
            return todos;
        }

        public TodoItem GetTodoItemById(int id)
        {
            var todoItem = _todoRepository.GetById(id);
            return todoItem;
        }

        public void CreateTodoItem(TodoItem todoItem)
        {
            _todoRepository.Add(todoItem);
        }

        public void DeleteTodoItem(int id)
        {
            _todoRepository.Delete(id);
        }

        public void UpdateTodoItem(TodoItem todoItem)
        {
            _todoRepository.Update(todoItem);
        } 

    }
}
