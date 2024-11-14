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
            return _context.Roles.Where(r => r.Deleted == false).ToList();
        }

        /// <summary>
        /// Lấy role với di
        /// </summary>
        /// <param name="id">Tham số id của role</param>
        /// <returns>1 Role</returns>
        [HttpGet("Id")]
        public Role GetById([FromQuery] int id)
        {
            return _context.Roles.Where(role => role.Id == id && role.Deleted == false).FirstOrDefault(); // tìm id = id truyền vào - trả về (1) thằng đầu tiên tìm được
        }

        /// <summary>
        /// Thêm 1 Role mới
        /// </summary>
        /// <param name="Role">Thông tin của Role mới</param>
        /// <returns>Nếu thành công trả về Role mới</returns>
        [HttpPost]
        public Role Post([FromBody] Role Role)
        {
            // Gán thời gian tạo và cập nhật là thời gian hiện tại
            Role.Created = DateTime.Now;
            Role.Updated = DateTime.Now;
            // Nội dung gửi lên Role Role
            _context.Roles.Add(Role); // sau gọi context tham chiếu đến Roles thực hiện Add Role 
            _context.SaveChanges(); // sau khi thành công lưu lại
            return Role; // trả về thông tin người dùng
        }

        /// <summary>
        /// Update Role
        /// </summary>
        /// <returns>Role updated</returns>
        [HttpPut("Id")]
        public IActionResult Update([FromQuery] int id, [FromBody] Role Role)
        {
            var existingRole = _context.Roles.Find(id);
            if (existingRole == null)
            {
                return NotFound();
            }

            // Giữ nguyên Created, chỉ cập nhật Updated
            existingRole.Updated = DateTime.Now;

            // Chỉ cập nhật các trường có dữ liệu mới từ 'Role'
            if (!string.IsNullOrEmpty(Role.Name))
                existingRole.Name = Role.Name;

            if (!string.IsNullOrEmpty(Role.Description))
                existingRole.Description = Role.Description;

            _context.SaveChanges();
            return Ok(existingRole);
        }

        /// <summary>
        /// Xoá mềm
        /// </summary>
        /// <param name="id">Cập nhật trạng thái xoá của role</param>
        /// <returns></returns>

        [HttpDelete("Id")]
        public IActionResult Delete([FromQuery] int id)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == id);
            if (role == null)
            {
                return NotFound("Role not found");
            }

            role.Deleted = true;
            _context.SaveChanges();
            return Ok("Role soft deleted successfully");
        }

    }
}

// FromQuery giống như url rồi thêm dấu hỏi và tham số = giá trị. Kiểu abc?name=Tuan