namespace Sup.Models
{
    public class GroupUser
    {
        public int Id { get; set; }
        // public User owner { get; set; } 
        public User User { get; set; }
        public Group Group { get; set; }
        public bool Accepted = false;
    }
}