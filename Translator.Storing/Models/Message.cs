using System;
using System.ComponentModel.DataAnnotations;
using Translate=Translator.Domain.Models.Translator;

namespace Translator.Storing.Models
{
  public class Message
  {
    public Message() {}
    public Message(string c)
    {
      MessageDateTime = DateTime.Now;
      Content = c;
    }
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime MessageDateTime { get; private set; }
  }
}