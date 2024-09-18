namespace EcommerceWebApi.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public string Theme { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<Message> Messages { get; set; } = [];

        public List<Account> Accounts { get; set; } = [];
        public List<AccountChatRoom> AccountChatRooms { get; set; } = [];
    }
}
