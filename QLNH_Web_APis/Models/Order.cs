using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QLNH_Web_APIs.Models
{
    public class Order : Base { 
        public string OrderNumber { get; set; }
        public string Description { get; set; }
        public bool Voided { get; set; } // Order nhầm lẫn - bỏ
        public double TotalPrice { get; set; }
        public double PaidTotal { get; set; }
        public virtual IList<OrderItem> OrderItem { get; set; }
    }
}