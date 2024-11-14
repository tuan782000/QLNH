using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QLNH_Web_APIs.Data;
using QLNH_Web_APIs.Models;

namespace QLNH_Web_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        // constructor
        public GuestController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // API GET - Trả về danh sách người dùng
        // IEnumerable<T>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.ToList();
        }
    }
}