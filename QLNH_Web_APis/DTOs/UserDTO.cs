using QLNH_Web_APIs.Models;

namespace QLNH_Web_APIs.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        // public string Password { get; set; }
        public string Description { get; set; }
        public int CreatedUserId { get; set; }
        public int UpdatedUserId { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public bool OffDuty { get; set; }
        public virtual Role Role { get; set; }
        public IEnumerable<UserDTO> CreatedUser { get; set; }
        public IEnumerable<UserDTO> UpdatedUser { get; set; }
    }

}