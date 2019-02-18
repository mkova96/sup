using System;
using System.Security.Claims;

namespace Sup.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        
        public  User Sender { get; set; }
        public  User Receiver { get; set; }

        public User GetOtherUser(string userId)
        {
            return Sender.Id != userId ? Sender : Receiver;
        }
    }
}