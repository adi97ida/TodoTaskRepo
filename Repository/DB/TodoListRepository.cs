using DataRepository.Interfaces;
using DataRepository.Models;
using DataRepository.Models.DB;
using DataRepository.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.DB
{
    public class TodoListRepository : ModelRepository<TodoList>, ITodoListRepository
    {
        public TodoListRepository(TodosDbContext context) : base(context) { }

        public async Task<string> SubscribeToList(string todoListId, string userId)
        {
            var todoList = await context.TodoLists.Include("SubscribedUsers").SingleAsync(c => c.Id == todoListId);
            var user = await context.Users.FindAsync(userId);

            if (user == null)
            {
                return "User not found";
            }
            if(todoList == null)
            {
                return "TodoList not found";
            }
            if(todoList.SubscribedUsers.Select(s => s.UserId == user.Id).Any())
            {
                return "User is already subscribed to the list";
            }

            SubscribedUsers newSub = new SubscribedUsers
            {
                UserId = user.Id,
                TodoListId = todoList.Id,
            };

            todoList.SubscribedUsers.Add(newSub);

            try
            {
                await context.SaveChangesAsync();
            } catch(Exception ex)
            {
                throw ex;
            }

            return "Subscription created";
        }

        public async Task<TodoList> InsertWithOwner(string userId, TodoList todoList)
        {
            User user = await context.Users.FindAsync(userId);
            todoList.UserFK = user.Id ?? throw new ArgumentNullException("entity");

            var newEntity = context.Add(todoList);
            await context.SaveChangesAsync();

            return newEntity.Entity;
        }
    }
}
