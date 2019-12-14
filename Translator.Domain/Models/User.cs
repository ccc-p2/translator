using System.Collections.Generic;

namespace Translator.Domain.Models
{
  public class User
  {
    public int UserId {get; set;}
    public string Username { get; set; }
    public string Password { get; set; }
    public string Language { get; set; }
    public List<Message> Messages { get; set; }   

    public User()
    {
      Messages = new List<Message>();
      // dummy data
      Message newMessage = new Message("this is a messsage.");
      Messages.Add(newMessage);
      newMessage = new Message("this is a second messsage.");
      Messages.Add(newMessage);

    }   
  }
}