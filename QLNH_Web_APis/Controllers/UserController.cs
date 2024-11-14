using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace QLNH_Web_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Trả về chuỗi "Hello"
        [HttpGet]
        public string Index()
        {
            return "Hello"; // Trả về chuỗi Hello
        }
    }
}