using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QLNH_Web_APIs.Models
{
    public class Unit : Base { // admin - người đứng bán (cashier)
        public required string Name { get; set; }
        public string Description { get; set; }
        public UnitType UnitType { get; set; } // đơn vị chứa (lon, chai, tô, khẩu phần của loại đó trên 1 đơn vị)
    }
}