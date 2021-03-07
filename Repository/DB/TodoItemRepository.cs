using DataRepository.Interfaces;
using DataRepository.Models;
using DataRepository.Models.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.DB
{
    public class TodoItemRepository : ModelRepository<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(TodosDbContext context) : base(context) { }

    }
}
