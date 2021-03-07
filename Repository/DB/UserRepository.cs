using DataRepository.Interfaces;
using DataRepository.Models;
using DataRepository.Models.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.DB
{
    public class UserRepository : ModelRepository<User>, IUserRepository
    {
        public UserRepository(TodosDbContext context) : base(context) { }

    }
}
