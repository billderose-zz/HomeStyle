using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HomeStyle.Models;

namespace HomeStyle.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        public ITodoRepository TodoItems { get; set; }
        
        public TodoController(ITodoRepository todoItems)
        {
            TodoItems = todoItems;
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems.GetAll();
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = TodoItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
