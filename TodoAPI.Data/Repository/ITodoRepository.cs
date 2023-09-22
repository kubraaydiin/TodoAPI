using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAPI.Data.Entities;

namespace TodoAPI.Data.Repository
{
    public interface ITodoRepository
    {
        List<TodoItem> GetAll();
        TodoItem GetById(int id);
        void Add(TodoItem todoItem);
        void Delete(int id);
        void Update(TodoItem todoItem);
    }
}
