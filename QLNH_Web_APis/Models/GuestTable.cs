using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QLNH_Web_APIs.Models
{
    public class GuestTable: Base 
    {
        public int Name { get; set; } // phân nhánh categories
        public string Description { get; set; }
        // virtual - lazy loading - cần thì mới lấy data - không thì thôi
        public virtual Status Status{ get; set; } // Bàn trống, mới vô, chờ ra món, - thằng nhiều chứa id thằng 1 (1 bàn nhiều status)
        public virtual Guest Guest{ get; set; } // khách hàng tên gì

    }
}