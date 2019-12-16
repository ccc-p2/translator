using System;

namespace Translator.Storing.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Content { get; set; }
    public DateTime MessageDateTime { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    
  }
}