using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QLNH_Web_APIs.Data;
using QLNH_Web_APIs.DTOs;
using QLNH_Web_APIs.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace QLNH_Web_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        // constructor
        public UserController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // API GET - Trả về danh sách người dùng
        // IEnumerable<T>
        // [HttpGet]
        // public IEnumerable<User> Get()
        // {
        //     return _context.Users.ToList();
        // }

        /// <summary>
        /// Danh sách người dùng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            try
            {
                var data = await _context.Users.Select(d => new User
                {
                    Id = d.Id,
                    UserName = d.UserName,
                    Description = d.Description,
                    Created = d.Created,
                    Updated = d.Updated,
                    Deleted = d.Deleted,
                    OffDuty = d.OffDuty,
                    Role = d.Role,
                    CreatedUser = _context.Users
                        .Where(c => c.Id == d.CreatedUserId)
                        .Select(s => new User { Id = s.Id, UserName = s.UserName, Description = s.Description, Created = s.Created, Updated = s.Updated, Deleted = s.Deleted, OffDuty = s.OffDuty, Role = s.Role, CreatedUser = s.CreatedUser, UpdatedUser = s.UpdatedUser })
                        .ToList(),
                    UpdatedUser = _context.Users
                        .Where(c => c.Id == d.UpdatedUserId)
                        .Select(s => new User { Id = s.Id, UserName = s.UserName, Description = s.Description, Created = s.Created, Updated = s.Updated, Deleted = s.Deleted, OffDuty = s.OffDuty, Role = s.Role, CreatedUser = s.CreatedUser, UpdatedUser = s.UpdatedUser })
                        .ToList()
                }).ToArrayAsync();

                var model = _mapper.Map<IEnumerable<UserDTO>>(data);
                return new JsonResult(model);
            }
            catch (ArgumentException ex)
            {
                return BadRequest("Not Good");
            }
        }
    }
}