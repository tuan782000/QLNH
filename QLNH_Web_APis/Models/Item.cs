using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QLNH_Web_APIs.Models
{
    public class Item : Base {
        public required string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual Category Category { get; set; }
        public virtual IList<ItemImage> ItemImage { get; set; }
    }
}