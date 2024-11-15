using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QLNH_Web_APIs.Models
{
    public class Restaurant : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; } // Order nhầm lẫn - bỏ
        public string Address { get; set; }

        // Bổ sung - virtual này giống nhu là biến - cần thì lấy ra không null - thường linq include: bao gồm (lúc này biết nó cần)
        public virtual User CreatedUser { get; set; } // người nào tạo ra restaurant
        public virtual User UpdatedUser { get; set; }

    }
}