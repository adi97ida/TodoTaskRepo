using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Models
{
    public class Notification : BaseModel
    {
        public Notification()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTimeOffset.UtcNow;
            UpdatedAt = DateTimeOffset.UtcNow;
        }
        public string PhoneNo { get; set; }
        public string Content { get; set; }
    }
}
