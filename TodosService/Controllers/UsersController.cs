using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataRepository.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataRepository.Models;

namespace todosTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // private readonly TodosDbContext _context;
        private readonly IModelRepository<User> dbContext;

        public UsersController(IModelRepository<User> context)
        {
            dbContext = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await dbContext.GetAll();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await dbContext.GetById(id);

            if (user == null)
            {
                return NotFound(id);
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string userId, User user)
        {
            if (userId != user.Id.ToString())
            {
                return BadRequest(userId);
            }

            try
            {
                await dbContext.Update(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dbContext.EntityExists(userId))
                {
                    return NotFound(userId);
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            try
            {
                user = await dbContext.Insert(user);
            }
            catch (DbUpdateException)
            {
                if (!dbContext.EntityExists(user.Id))
                {
                    return Conflict(user.Id);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(string id)
        {
            var user = await dbContext.Delete(id);
            if (user == null)
            {
                return NotFound(id);
            }

            return user;
        }
    }
}
