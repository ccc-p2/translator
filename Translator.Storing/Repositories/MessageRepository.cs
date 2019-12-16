using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Translator.Storing.Models;
using M=Translator.Domain.Models.Message;
using TR=Translator.Domain.Models.Translator;

namespace Translator.Storing.Repositories
{
  public class MessageRepository
  {
    private static readonly TranslatorDbContext _db = new TranslatorDbContext();
    public List<Message> GetAllMessages()
    {
      return _db.Message.Include(u => u.User).ToList();
    }
    public async Task<List<Message>> GetAllMessages(string language)
    {
      List<Message> messages = _db.Message.Include(u => u.User).ToList();
      TR tr = new TR();
      foreach(Message m in messages)
      {
        m.Content = await tr.Translate(m.Content, language);
      }
      return messages;
    }
    public Message GetMessage(int id)
    {
      return _db.Message.Where(m => m.MessageId == id).Include(u => u.User).FirstOrDefault();
    }
    public void Create(Message m)
    {
      _db.Message.Add(m);
      _db.SaveChanges();
    }

    // deprecated
    public List<M> Read()
    {
      M newMessage = new M("First Message");
      newMessage.Id = 1;
      List<M> MessageList = new List<M>();
      MessageList.Add(newMessage);
      newMessage = new M("Seccond Message");
      MessageList.Add(newMessage);
      return MessageList;
    }

  }
}