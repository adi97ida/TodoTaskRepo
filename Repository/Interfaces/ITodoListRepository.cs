using DataRepository.Models;
using DataRepository.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Interfaces
{
    public interface ITodoListRepository : IModelRepository<TodoList>
    {
        Task<string> SubscribeToList(string todoListId, string userId);
        // Task<TodoList> GetTodoList(string todoListId);
    }
}
