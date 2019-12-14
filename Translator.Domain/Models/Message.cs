using System;

namespace Translator.Domain.Models
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
    public string Content { get; private set; }
    public string TranslatedContent {get; private set;}
    public DateTime MessageDateTime { get; private set; }
    public string TranslateTo(string Language)
    {
      Translator translateContent = new Translator();
      TranslatedContent = translateContent.Translate(Content, Language).Result;
      return TranslatedContent;
    }
  }
}