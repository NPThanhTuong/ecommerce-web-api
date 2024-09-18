using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWebApi.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
        public string VerifyToken { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? VerifiedAt { get; set; }

        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; } = null!;

        public Customer Customer { get; set; } = null!;
        public Shop Shop { get; set; } = null!;

        public List<Message> Messages { get; set; } = [];

        public List<ChatRoom> ChatRooms { get; set; } = [];
        public List<AccountChatRoom> AccountChatRooms { get; set; } = [];
    }
}
