using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Translator.Storing.Models
{
  public class User
  {
    public User()
    {
      Messages = new List<Message>();
    }  
    public int Id {get; set;}
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Language { get; set; }
    public List<Message> Messages { get; set; }   

  }
}