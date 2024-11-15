using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QLNH_Web_APIs.Models
{
    public class Guest : Base
    {
        public string Name { get; set; } // phân nhánh categories
        public string Phone { get; set; } // khác cho số phone - ăn nhiều lần bớt giá
        public string Description { get; set; }
        public string Address { get; set; }

        public virtual Restaurant Restaurant { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User UpdatedUser { get; set; }

    }
}