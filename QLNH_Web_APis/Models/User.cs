using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace QLNH_Web_APIs.Models
{
    public class User : Base
    {
        public required string UserName { get; set; }
        public string Description { get; set; }
        public string Password { get; set; }
        public bool OffDuty { get; set; }
        public virtual Role Role { get; set; }

        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set; }

        [NotMapped] // các trường có NotMapped sẽ không có trong DB - báo cho entity không bỏ trong DB
        public IEnumerable<User> CreatedUser { get; set; }
        [NotMapped]
        public IEnumerable<User> UpdatedUser { get; set; }
    }
}