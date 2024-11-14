using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QLNH_Web_APIs.Data;
using QLNH_Web_APIs.Models;

namespace QLNH_Web_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        // constructor
        public RoleController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // API GET - Trả về danh sách người dùng
        // IEnumerable<T>
        /// <summary>
        /// Lấy danh sách các Roles
        /// </summary>
        /// <returns>Danh sách role</returns>
        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return _context.Roles.ToList();
        }

        /// <summary>
        /// Lấy role với di
        /// </summary>
        /// <param name="id">Tham số id của role</param>
        /// <returns>1 Role</returns>
        [HttpGet("Id")]
        public Role Get([FromQuery]int id)
        {
            return _context.Roles.Where(role => role.Id == id).FirstOrDefault(); // tìm id = id truyền vào - trả về (1) thằng đầu tiên tìm được
        }

        /// <summary>
        /// Thêm 1 Role mới
        /// </summary>
        /// <param name="Role">Thông tin của Role mới</param>
        /// <returns>Nếu thành công trả về Role mới</returns>
        [HttpPost]
        public Role Post([FromQuery] Role Role){
            // Nội dung gửi lên Role Role
            _context.Roles.Add(Role); // sau gọi context tham chiếu đến Roles thực hiện Add Role 
            _context.SaveChanges(); // sau khi thành công lưu lại
            return Role; // trả về thông tin người dùng
        }


    }
}

// FromQuery giống như url rồi thêm dấu hỏi và tham số = giá trị. Kiểu abc?name=Tuan