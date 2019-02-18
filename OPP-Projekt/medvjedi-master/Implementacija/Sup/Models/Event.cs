using System;
using System.Collections.Generic;

namespace Sup.Models

{
  public class Event
  {
    public int Id {get; set;}
    public string Title {get; set;}
    public string Description {get; set;}
    public DateTime Date {get; set;}
    public TimeSpan Time {get; set;}
    public DateTime Published {get; set;}

    public List<EventUser> EventUser {get; set;}
    public User User {get; set;}
  }
}