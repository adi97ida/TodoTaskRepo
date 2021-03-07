using DataRepository.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataRepository.Models
{
    public class TodoList : BaseModel
    {
        public TodoList()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;
            // SubscribedUsers = new HashSet<User>();
        }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [ForeignKey("User")]
        public string UserFK { get; set; }
        public DateTimeOffset CompletedAt { get; set; }
        public ICollection<SubscribedUsers> SubscribedUsers { get; set; }
    }
}
