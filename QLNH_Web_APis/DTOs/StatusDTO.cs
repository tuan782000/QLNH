using QLNH_Web_APIs.Models;

namespace QLNH_Web_APIs.DTOs
{
    public class StatusDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        // public required string Password { get; set; }
        public string Description { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public UserDTO CreatedUser { get; set; } // người nào tạo ra restaurant // vitural đổi thành UserDTO
        public UserDTO UpdatedUser { get; set; }
    }

}