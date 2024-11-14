using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace QLNH_Web_APIs.Models
{
    public class User {
        [Key]
        public int Id { get; set;}
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}