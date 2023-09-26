using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.Business.Operations;
using TodoAPI.Data.Entities;
using TodoAPI.Model;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoOperations _todoOperations;
        public TodosController(ITodoOperations todoOperations)
        {
            _todoOperations = todoOperations;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _todoOperations.Todos().Select(x => new TodoModel
            {
                CreatedDate = x.CreatedDate,
                IsCompleted = x.IsCompleted,
                Name = x.Name
            }).ToList();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _todoOperations.GetTodoItemById(id);

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(AddingTodoModel addingTodoModel)
        {
            var todoItem = new TodoItem
            {
                Name = addingTodoModel.Name,
                CreatedDate = DateTime.Now,
                IsCompleted = false
            };

            _todoOperations.CreateTodoItem(todoItem);

            return StatusCode(201);
        }

        [Authorize]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteById(int id)
        {
            _todoOperations.DeleteTodoItem(id);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateItem(int id, TodoModel todoModel)
        {
            var todoItem = new TodoItem
            {
                Id = id,
                Name = todoModel.Name,
                CreatedDate = todoModel.CreatedDate,
                IsCompleted = todoModel.IsCompleted
            };

            _todoOperations.UpdateTodoItem(todoItem);

            return Ok();
        }
    }
}