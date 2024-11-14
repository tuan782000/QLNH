using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QLNH_Web_APIs.Models
{
    public class OrderItem : Base { 
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Voided { get; set; }
        public double SalePrice { get; set; }
        public virtual Item Item { get; set; }
    }
}