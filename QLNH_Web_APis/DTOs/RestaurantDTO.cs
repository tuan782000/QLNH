using QLNH_Web_APIs.Models;

namespace QLNH_Web_APIs.DTOs
{
    public class RestaurantDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        // public required string Password { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public UserDTO CreatedUser { get; set; } // người nào tạo ra restaurant
        public UserDTO UpdatedUser { get; set; }
    }

}