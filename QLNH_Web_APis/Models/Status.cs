using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QLNH_Web_APIs.Models
{
    public class Status : Base { // admin - người đứng bán (cashier)
        public required string Name { get; set; }
        public string Description { get; set; }
    }
}