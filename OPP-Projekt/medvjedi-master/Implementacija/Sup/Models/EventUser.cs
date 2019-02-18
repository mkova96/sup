namespace Sup.Models

{
    public class EventUser
    {
        public int Id { get; set; }
        
        public User Users { get; set; }
        public Event Events { get; set; }

        public bool Attending { get; set; }
    }
}