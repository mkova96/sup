using System;
using System.Collections.Generic;

namespace Sup.Models

{
  public class Announcement
  {
    public int Id {get; set;}
    public string Title {get; set;}
    public string Message {get; set;}
    public DateTime Published {get; set;}
    public string RecieverType {get; set;}
    public string RecieverId {get; set;}

    public List<AnnouncementUser> AnnouncementUsers {get; set;}
    public User User {get; set;}
  }
}