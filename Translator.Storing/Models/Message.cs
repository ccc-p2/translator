using System;
using System.Threading.Tasks;
using TR=Translator.Domain.Models.Translator;

namespace Translator.Storing.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    public string Content { get; set; }
    public DateTime MessageDateTime { get; set; }
    // public int UserId { get; set; }
    // public User User { get; set; }
    // public async Task<string> TranslateTo(string ToLanguage)
    // {
    //   TR tr = new TR();
    //   return await tr.Translate(Content, ToLanguage);
    // }
  }
}