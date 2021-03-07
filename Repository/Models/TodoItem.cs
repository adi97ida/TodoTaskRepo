using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace DataRepository.Models
{
    public class TodoItem : BaseModel
    {
        public TodoItem()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
        [DefaultValue(false)]
        public bool Completed { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }
        [ForeignKey("User")]
        public string UserFK { get; set; }
        [ForeignKey("TodoList")]
        public string ParentTodoListFK { get; set; }
        public DateTimeOffset? CompletedAt { get; set; }
    }
}
