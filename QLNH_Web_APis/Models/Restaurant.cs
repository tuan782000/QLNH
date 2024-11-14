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
    }
}