using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QLNH_Web_APIs.Data;
using QLNH_Web_APIs.Models;

namespace QLNH_Web_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        // constructor
        public RestaurantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // API GET - Trả về danh sách người dùng
        // IEnumerable<T>
        /// <summary>
        /// Danh sách các nhà hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Restaurant> Get()
        {
            return _context.Restaurants.Where(r => r.Deleted == false).ToList();
        }

        /// <summary>
        /// Thêm restaurant mới
        /// </summary>
        /// <returns>Restaurant</returns>
        [HttpPost]
        public Restaurant Post([FromBody] Restaurant Restaurant)
        {
            // Gán thời gian tạo và cập nhật là thời gian hiện tại
            Restaurant.Created = DateTime.Now;
            Restaurant.Updated = DateTime.Now;

            // Nội dung gửi lên Role Role
            _context.Restaurants.Add(Restaurant); // sau gọi context tham chiếu đến Roles thực hiện Add Role 
            _context.SaveChanges(); // sau khi thành công lưu lại
            return Restaurant; // trả về thông tin người dùng
        }

        /// <summary>
        /// Update Restaurant
        /// </summary>
        /// <returns>Restaurant updated</returns>
        [HttpPut("Id")]
        public IActionResult Update([FromQuery] int id, [FromBody] Restaurant restaurant)
        {
            var existingRestaurant = _context.Restaurants.Find(id);
            if (existingRestaurant == null)
            {
                return NotFound();
            }

            // Giữ nguyên Created, chỉ cập nhật Updated
            existingRestaurant.Updated = DateTime.Now;

            // Chỉ cập nhật các trường có dữ liệu mới từ 'restaurant'
            if (!string.IsNullOrEmpty(restaurant.Name))
                existingRestaurant.Name = restaurant.Name;

            if (!string.IsNullOrEmpty(restaurant.Description))
                existingRestaurant.Description = restaurant.Description;

            if (!string.IsNullOrEmpty(restaurant.Phone))
                existingRestaurant.Phone = restaurant.Phone;

            if (!string.IsNullOrEmpty(restaurant.Address))
                existingRestaurant.Address = restaurant.Address;

            _context.SaveChanges();
            return Ok(existingRestaurant);
        }

        /// <summary>
        /// Lấy Restaurant với id
        /// </summary>
        /// <param name="id">Tham số id của Restaurant</param>
        /// <returns>1 Restaurant</returns>
        [HttpGet("Id")]
        public Restaurant GetById([FromQuery] int id)
        {
            return _context.Restaurants.Where(Restaurant => Restaurant.Id == id && Restaurant.Deleted == false).FirstOrDefault(); // tìm id = id truyền vào - trả về (1) thằng đầu tiên tìm được
        }

        /// <summary>
        /// Xoá mềm
        /// </summary>
        /// <param name="id">Cập nhật trạng thái xoá của nhà hàng</param>
        /// <returns></returns>

        [HttpDelete("Id")]
        public IActionResult Delete([FromQuery] int id)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant == null)
            {
                return NotFound("Restaurant not found");
            }

            restaurant.Deleted = true;
            _context.SaveChanges();
            return Ok("Restaurant soft deleted successfully");
        }
    }
}