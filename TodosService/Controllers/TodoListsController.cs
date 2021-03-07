using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataRepository.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataRepository.Interfaces;
using DataRepository.Models;

namespace TodosService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsController : ControllerBase
    {
        // private readonly TodosDbContext _context;
        private readonly ITodoListRepository dbContext;

        public TodoListsController(ITodoListRepository context)
        {
            dbContext = context;
        }


        // GET: api/TodoLists
        [HttpGet]
        public async Task<ActionResult<List<TodoList>>> GetTodoLists()
        {
            return await dbContext.GetAll();
        }

        // GET: api/TodoLists/5
        [HttpGet("{todoListId}")]
        public async Task<ActionResult<TodoList>> GetTodoList(string todoListId)
        {
            // var todoList = await _context.TodoLists.Include(p => p.Owner).FirstAsync(p => p.Id== todoListId);

            TodoList todoList = await dbContext.GetById(todoListId);
            if (todoList == null)
            {
                return NotFound(todoListId);
            }

            return todoList;
        }

        // PUT: api/TodoLists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoList(string listId, TodoList todoList)
        {
            if (listId != todoList.Id)
            {
                return BadRequest(todoList.Id);
            }

            try
            {
                await dbContext.Update(todoList);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dbContext.EntityExists(listId))
                {
                    return NotFound(listId);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoLists/SubscribeToList
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("SubscribeToList")]
        public async Task<ActionResult<bool>> SubscribeToList(string todoListId, string userId)
        {
            string subscription = await dbContext.SubscribeToList(todoListId, userId);
            if(subscription == "Subscription created")
            {
                return Ok(subscription);
            }
            return NotFound(subscription);
        }

        // POST: api/TodoLists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoList>> PostTodoList(string userId, TodoList todoList)
        {
            try
            {
                User user = dbContext.DB.Users.Find(userId);

                if(user != null)
                {
                    todoList.UserFK = user.Id;
                    todoList = await dbContext.Insert(todoList);
                }
                else
                {
                    return NotFound(userId);
                }
            }
            catch (DbUpdateException)
            {
                if (!dbContext.EntityExists(todoList.Id))
                {
                    return Conflict(todoList.Id);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTodoList", new { todoListId = todoList.Id }, todoList);
        }

        // DELETE: api/TodoLists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoList>> DeleteTodoList(string id)
        {
            var todoList = await dbContext.Delete(id);
            if (todoList == null)
            {
                return NotFound(id);
            }

            return todoList;
        }
    }
}
