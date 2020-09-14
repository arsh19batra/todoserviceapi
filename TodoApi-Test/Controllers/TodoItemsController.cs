using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi_Test.Models;

namespace TodoApi_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : Controller
    {
        private readonly IService _service;
        //private readonly TodoContext _context;

        public TodoItemsController(IService service)
        {
            _service = service;
        }


        // GET: api/TodoItems
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAll()
        {
            var items = _service.GetAll();
            return Ok(items);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetById(long id)
        {
            var item = _service.GetById(id);
            return item;
        }
        //POST: api/TodoItems
        [HttpPost]
        public ActionResult<TodoItem> Create(TodoItem item)
        {
            _service.Create(item);
            _service.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = item.Id }, item);
        }
        // PUT: api/TodoItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public ActionResult PutTodoItem(long id, TodoItem todoItem)
        {
            var item = _service.GetById(id);
            if (item==null)
            {
                return BadRequest();
            }
            _service.Update(item);
            _service.SaveChanges();
            return NoContent();
        }
        

        // POST: api/TodoItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        

       /* private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }*/
    }
}
