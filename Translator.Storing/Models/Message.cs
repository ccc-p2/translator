using System;
using System.ComponentModel.DataAnnotations;
using Translate=Translator.Domain.Models.Translator;

namespace Translator.Storing.Models
{
  public class Message
  {
    private Message() {}
    public Message(string c)
    {
      MessageDateTime = DateTime.Now;
      Content = c;
    }
    public int Id { get; set; }
    [Required]
    public string Content { get; private set; }
    public DateTime MessageDateTime { get; private set; }
  }
}