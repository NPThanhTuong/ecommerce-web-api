﻿namespace EcommerceWebApi.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<Customer> Customers { get; set; } = [];
        public List<CustomerNotification> CustomerNotifications { get; set; } = [];
    }
}
