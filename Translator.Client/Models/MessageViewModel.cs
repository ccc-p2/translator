
using System.ComponentModel.DataAnnotations;

namespace Translator.Client.Models
{
  public class MessageViewModel 
  {
    [Required(ErrorMessage = "Please enter a message.")] 
    public string Content { get; set; }
  }
}