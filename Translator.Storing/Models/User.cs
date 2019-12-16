using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Translator.Storing.Models
{
  public class User
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int UserId {get; set;}
    public string Username { get; set; }
    public string Password { get; set; }
    public string Language { get; set; }
    public List<Message> Messages { get; set; }   

  }
}