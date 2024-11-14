using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QLNH_Web_APIs.Data;
using QLNH_Web_APIs.Models;

namespace QLNH_Web_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        // constructor
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // API GET - Trả về danh sách người dùng
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }
    }
}