namespace Sup.Models

{
    public class AnnouncementUser
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Announcement Announcement { get; set; }
        
    }
}