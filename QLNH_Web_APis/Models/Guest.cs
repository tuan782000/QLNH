using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QLNH_Web_APIs.Models
{
    public class Guest: Base 
    {
        public int Name { get; set; } // phân nhánh categories
        public string Phone { get; set; } // khác cho số phone - ăn nhiều lần bớt giá
        public string Description { get; set; }

    }
}