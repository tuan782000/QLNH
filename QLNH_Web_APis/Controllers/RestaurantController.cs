using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLNH_Web_APIs.Data;
using QLNH_Web_APIs.DTOs;
using QLNH_Web_APIs.Models;
using AutoMapper;


namespace QLNH_Web_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        // constructor
        public RestaurantController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // API GET - Trả về danh sách người dùng
        // IEnumerable<T>
        /// <summary>
        /// Danh sách các nhà hàng
        /// </summary>
        /// <returns></returns>
        // [HttpGet]
        // public IEnumerable<Restaurant> Get()
        // {
        //     return _context.Restaurants
        //                     .Where(c => !c.Deleted) // c.Deleted - lấy ra các cái có Deleted là true - nghịch đảo true là false thì - ẩn các restaurant có Deleted là true
        //                     .Include(r => r.CreatedUser) // 2 cái này làm được nhờ vitural
        //                     .Include(r => r.UpdatedUser)
        //                     .ToList();
        // }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDTO>>> Get()
        {
            try
            {
                var data = await _context.Restaurants
                                .Include(r => r.CreatedUser)
                                .Include(r => r.UpdatedUser)
                                .ToArrayAsync();
                var model = _mapper.Map<IEnumerable<RestaurantDTO>>(data);
                return new JsonResult(model);
            }
            catch (AggregateException ex)
            {
                return BadRequest("Not good");
            }
        }

        /*
            Mình bổ sung using Mapper và sử dụng mapper 17, 20, 23 mới dùng _mapper
            Hàm Get này áp dụng async và await và bỏ sung them Task<ActionResult<>>
            Thay vì dùng cái ruột IEnumerable<Restaurant> thay bằng ruột <IEnumerable<RestaurantDTO> để người khác chỉ xem được <IEnumerable<RestaurantDTO>
            giấu các thông tin IEnumerable<Restaurant> 
        */

        /// <summary>
        /// Thêm restaurant mới
        /// </summary>
        /// <returns>Restaurant</returns>
        [HttpPost]
        public Restaurant Post([FromBody] Restaurant Restaurant)
        {
            // Restaurant client gủi lên 
            // và các cái mà mình thực hiện query - những thứ user không được biết
            var createdUser = _context.Users.Find(Restaurant.CreatedUser.Id);
            Restaurant.CreatedUser = createdUser;
            var updatedUser = _context.Users.Find(Restaurant.UpdatedUser.Id);
            Restaurant.UpdatedUser = updatedUser;
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

            var updatedUser = _context.Users.Find((restaurant.UpdatedUser != null) ? restaurant.UpdatedUser.Id : 1);
            restaurant.UpdatedUser = updatedUser;

            _context.SaveChanges();
            return Ok(existingRestaurant);
        }

        // /// <summary>
        // /// Lấy Restaurant với id
        // /// </summary>
        // /// <param name="id">Tham số id của Restaurant</param>
        // /// <returns>1 Restaurant</returns>
        // [HttpGet("Id")]
        // public Restaurant GetById([FromQuery] int id)
        // {
        //     return _context.Restaurants.Where(Restaurant => Restaurant.Id == id && Restaurant.Deleted == false).FirstOrDefault(); // tìm id = id truyền vào - trả về (1) thằng đầu tiên tìm được
        // }
        /// <summary>
        /// Lấy thông tin nhà hàng theo ID.
        /// </summary>
        /// <param name="id">ID của nhà hàng cần tìm.</param>
        /// <returns>Thông tin nhà hàng hoặc mã lỗi nếu không tìm thấy.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RestaurantDTO>>> GetByIdAsync(int id)
        {
            try
            {
                var restaurant = await _context.Restaurants
                                    .Include(r => r.CreatedUser)
                                    .Include(r => r.UpdatedUser)
                                    .Where(r => r.Id == id && r.Deleted == false)
                                    .FirstOrDefaultAsync();

                if (restaurant == null)
                {
                    return NotFound($"Không tìm thấy nhà hàng với ID = {id}.");
                }

                // Ánh xạ sang DTO
                var restaurantDto = _mapper.Map<RestaurantDTO>(restaurant);
                return Ok(restaurantDto);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần thiết
                return StatusCode(500, "Đã xảy ra lỗi khi truy vấn dữ liệu.");
            }
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