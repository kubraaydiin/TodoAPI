using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Data.Entities;

namespace TodoAPI.Business.Operations
{
    public interface ITodoOperations
    {
        List<TodoItem> Todos();
        TodoItem GetTodoItemById(int id);
        void CreateTodoItem(TodoItem todoItem);
        void DeleteTodoItem(int id);
        void UpdateTodoItem(TodoItem todoItem);
    }
}
