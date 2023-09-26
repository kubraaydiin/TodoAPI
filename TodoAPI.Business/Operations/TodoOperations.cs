using TodoAPI.Data.Entities;
using TodoAPI.Data.Repository;


namespace TodoAPI.Business.Operations
{
    public class TodoOperations : ITodoOperations
    {
        private readonly IBaseRepository<TodoItem> _baseRepository;
        public TodoOperations(IBaseRepository<TodoItem> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public List<TodoItem> Todos()
        {
            var todos = _baseRepository.GetAll();
            return todos;
        }

        public TodoItem GetTodoItemById(int id)
        {
            var todoItem = _baseRepository.GetById(id);
            return todoItem;
        }

        public void CreateTodoItem(TodoItem todoItem)
        {
            _baseRepository.Add(todoItem);
        }

        public void DeleteTodoItem(int id)
        {
            _baseRepository.Delete(id);
        }

        public void UpdateTodoItem(TodoItem todoItem)
        {
            _baseRepository.Update(todoItem);
        } 

    }
}
