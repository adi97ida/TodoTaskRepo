using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using DataRepository.Models;

namespace DataRepository.Models
{
    public class User : BaseModel
    {

        public User()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;
            //SubscribedLists = new HashSet<TodoList>();
        }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        public ICollection<SubscribedUsers> SubscribedLists { get; set; }
    }
}
