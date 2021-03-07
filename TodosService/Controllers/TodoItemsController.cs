using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataRepository.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataRepository.Models;
using TodosService.Interfaces;
using Serilog;

namespace TodosService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        // private readonly TodosDbContext _context;
        private readonly IModelRepository<TodoItem> dbContext;
        private readonly INotificationsHandler notificationsHandler;

        public TodoItemsController(IModelRepository<TodoItem> context, INotificationsHandler notifHandler)
        {
            dbContext = context;
            notificationsHandler = notifHandler;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<List<TodoItem>>> GetTodoItems()
        {
            return await dbContext.GetAll();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(string todoItemId)
        {
            var todoItem = await dbContext.GetById(todoItemId);

            if (todoItem == null)
            {
                return NotFound(todoItemId);
            }

            return todoItem;
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(string todoItemId, TodoItem todoItem)
        {
            if (todoItemId != todoItem.Id)
            {
                return BadRequest(todoItemId);
            }

            try
            {
                await dbContext.Update(todoItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dbContext.EntityExists(todoItemId))
                {
                    return NotFound(todoItemId);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(string userId, string listId, TodoItem todoItem)
        {
            try
            {
                User user = dbContext.DB.Users.Find(userId);
                TodoList list = dbContext.DB.TodoLists.Find(listId);

                if(list is null)
                {
                    return NotFound(listId);
                }

                if (user is null)
                {
                    return NotFound(userId);
                }

                todoItem.ParentTodoListFK = list.Id;
                todoItem.UserFK = user.Id;
                todoItem = await dbContext.Insert(todoItem);

                var notifStatus = await notificationsHandler.DoNotifyUsers(listId, todoItem.Id);
                Log.Information(notifStatus);
            }
            catch (DbUpdateException)
            {
                if (!dbContext.EntityExists(todoItem.Id))
                {
                    return Conflict(todoItem.Id);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(string todoItemId)
        {
            var todoItem = await dbContext.Delete(todoItemId);
            if (todoItem == null)
            {
                return NotFound(todoItemId);
            }

            return todoItem;
        }
    }
}
