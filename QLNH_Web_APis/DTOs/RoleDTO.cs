using QLNH_Web_APIs.Models;

namespace QLNH_Web_APIs.DTOs
{

    public class RoleDTO
    {
        public int Id { get; set; } // Id ánh xạ từ Role.Id
        public string Name { get; set; } // Tên người dùng ánh xạ từ Role.UserName
        public string Description { get; set; } // Mô tả ánh xạ từ Role.Description
        public RestaurantDTO Restaurant { get; set; } // Nhà hàng ánh xạ từ Role.Restaurant
    }
}