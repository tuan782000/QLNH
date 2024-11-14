using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QLNH_Web_APIs.Models
{
    public class ItemImage : Base {
        public required string Name { get; set; }
        public string Data { get; set; }
        public string Description { get; set; }
    }
}