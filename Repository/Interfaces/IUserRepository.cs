using DataRepository.Models;
using DataRepository.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Interfaces
{
    public interface IUserRepository : IModelRepository<User>
    {
    }
}
