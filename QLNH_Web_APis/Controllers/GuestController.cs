using System.Collections.Generic;
using System.Threading.Tasks;
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
    public class GuestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GuestController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách GuestDTO</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestDTO>>> Get()
        {
            try
            {
                var data = await _context.Guests
                                .Include(g => g.CreatedUser)
                                .Include(g => g.UpdatedUser)
                                .Where(g => !g.Deleted)
                                .ToArrayAsync();
                var model = _mapper.Map<IEnumerable<GuestDTO>>(data);
                return new JsonResult(model);
            }
            catch
            {
                return BadRequest("Không thể lấy danh sách khách hàng.");
            }
        }

        /// <summary>
        /// Thêm khách hàng mới
        /// </summary>
        /// <param name="guest">Đối tượng Guest mới</param>
        /// <returns>Guest đã được thêm</returns>
        [HttpPost]
        public ActionResult<Guest> Post([FromBody] Guest guest)
        {
            var createdUser = _context.Users.Find(guest.CreatedUser.Id);
            guest.CreatedUser = createdUser;
            var updatedUser = _context.Users.Find(guest.UpdatedUser.Id);
            guest.UpdatedUser = updatedUser;
            guest.Created = DateTime.Now;
            guest.Updated = DateTime.Now;

            _context.Guests.Add(guest);
            _context.SaveChanges();
            return guest;
        }

        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="id">ID của khách hàng</param>
        /// <param name="guest">Thông tin khách hàng cần cập nhật</param>
        /// <returns>Guest đã cập nhật</returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Guest guest)
        {
            var existingGuest = _context.Guests.Find(id);
            if (existingGuest == null)
            {
                return NotFound("Guest không tồn tại.");
            }

            existingGuest.Updated = DateTime.Now;


            if (!string.IsNullOrEmpty(guest.Name))
                existingGuest.Name = guest.Name;

            if (!string.IsNullOrEmpty(guest.Phone))
                existingGuest.Phone = guest.Phone;

            if (!string.IsNullOrEmpty(guest.Description))
                existingGuest.Description = guest.Description;

            if (!string.IsNullOrEmpty(guest.Address))
                existingGuest.Address = guest.Address;

            var updatedUser = _context.Users.Find(guest.UpdatedUser?.Id ?? 1);
            existingGuest.UpdatedUser = updatedUser;

            _context.SaveChanges();
            return Ok(existingGuest);
        }

        /// <summary>
        /// Lấy thông tin khách hàng theo ID
        /// </summary>
        /// <param name="id">ID của khách hàng</param>
        /// <returns>Thông tin của khách hàng</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GuestDTO>> GetByIdAsync(int id)
        {
            try
            {
                var guest = await _context.Guests
                                    .Include(g => g.CreatedUser)
                                    .Include(g => g.UpdatedUser)
                                    .Where(g => g.Id == id && !g.Deleted)
                                    .FirstOrDefaultAsync();

                if (guest == null)
                {
                    return NotFound($"Không tìm thấy khách hàng với ID = {id}.");
                }

                var guestDto = _mapper.Map<GuestDTO>(guest);
                return Ok(guestDto);
            }
            catch
            {
                return StatusCode(500, "Đã xảy ra lỗi khi truy vấn dữ liệu.");
            }
        }

        /// <summary>
        /// Xóa mềm khách hàng
        /// </summary>
        /// <param name="id">ID của khách hàng</param>
        /// <returns>Kết quả xóa</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var guest = _context.Guests.FirstOrDefault(g => g.Id == id);
            if (guest == null)
            {
                return NotFound("Guest không tồn tại.");
            }

            guest.Deleted = true;
            _context.SaveChanges();
            return Ok("Guest đã được xóa mềm thành công.");
        }
    }
}