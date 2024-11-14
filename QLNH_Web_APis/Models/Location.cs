using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QLNH_Web_APIs.Models
{
    public class Location : Base { 
        public string Name { get; set; }
        public string Description { get; set; }
    }
}