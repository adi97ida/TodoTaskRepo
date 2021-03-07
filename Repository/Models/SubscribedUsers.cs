using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Models
{
    public class SubscribedUsers : BaseModel
    {
        public SubscribedUsers()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
        public string UserId { get; set; }
        public string TodoListId { get; set; }

        public virtual User User { get; set; }
        public virtual TodoList TodoList { get; set; }

    }
}
