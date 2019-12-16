
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Translator.Client.Models
{
  public class MessageViewModel 
  {
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int MessageId{get; set;}
    [Required(ErrorMessage = "Please enter a message.")] 
    public string Content { get; set; }
  }
}