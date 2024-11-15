using System.Collections.Generic;
using System.Linq;
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
    public class StatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        // Constructor
        public StatusController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Lấy danh sách trạng thái.
        /// </summary>
        /// <returns>Danh sách StatusDTO</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusDTO>>> Get()
        {
            try
            {
                var data = await _context.Statuses
                    .Include(s => s.CreatedUser)
                    .Include(s => s.UpdatedUser)
                    .ToListAsync();

                var model = _mapper.Map<IEnumerable<StatusDTO>>(data);
                return Ok(model);
            }
            catch
            {
                return StatusCode(500, "Đã xảy ra lỗi khi lấy dữ liệu.");
            }
        }

        /// <summary>
        /// Lấy trạng thái theo ID.
        /// </summary>
        /// <param name="id">ID của trạng thái cần tìm.</param>
        /// <returns>StatusDTO</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusDTO>> GetById(int id)
        {
            var status = await _context.Statuses
                .Include(s => s.CreatedUser)
                .Include(s => s.UpdatedUser)
                .FirstOrDefaultAsync(s => s.Id == id && !s.Deleted);

            if (status == null)
            {
                return NotFound($"Không tìm thấy trạng thái với ID = {id}.");
            }

            var statusDto = _mapper.Map<StatusDTO>(status);
            return Ok(statusDto);
        }

        /// <summary>
        /// Thêm trạng thái mới.
        /// </summary>
        /// <param name="statusDto">Dữ liệu của trạng thái.</param>
        /// <returns>Status mới tạo</returns>
        [HttpPost]
        public async Task<ActionResult<StatusDTO>> Post([FromBody] StatusDTO statusDto)
        {
            var status = _mapper.Map<Status>(statusDto);

            status.Created = DateTime.Now;
            status.Updated = DateTime.Now;
            status.CreatedUser = await _context.Users.FindAsync(statusDto.CreatedUser.Id);
            status.UpdatedUser = status.CreatedUser;

            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<StatusDTO>(status);
            return CreatedAtAction(nameof(GetById), new { id = status.Id }, result);
        }

        /// <summary>
        /// Cập nhật trạng thái.
        /// </summary>
        /// <param name="id">ID của trạng thái cần cập nhật.</param>
        /// <param name="statusDto">Dữ liệu cập nhật của trạng thái.</param>
        /// <returns>Status đã cập nhật</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] StatusDTO statusDto)
        {
            var existingStatus = await _context.Statuses.FindAsync(id);
            if (existingStatus == null)
            {
                return NotFound();
            }

            existingStatus.Updated = DateTime.Now;
            existingStatus.Name = statusDto.Name ?? existingStatus.Name;
            existingStatus.Description = statusDto.Description ?? existingStatus.Description;
            existingStatus.UpdatedUser = await _context.Users.FindAsync(statusDto.UpdatedUser.Id);

            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<StatusDTO>(existingStatus));
        }

        /// <summary>
        /// Xoá mềm trạng thái.
        /// </summary>
        /// <param name="id">ID của trạng thái cần xoá.</param>
        /// <returns>Xác nhận xoá mềm</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _context.Statuses.FindAsync(id);
            if (status == null)
            {
                return NotFound("Không tìm thấy trạng thái cần xoá.");
            }

            status.Deleted = true;
            await _context.SaveChangesAsync();
            return Ok("Xoá mềm trạng thái thành công.");
        }
    }
}