using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.Models.Interfaces
{
    public interface IBaseModel
    {
        public string Id { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
