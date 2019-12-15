using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Translator.Storing.Models;
using M=Translator.Domain.Models.Message;

namespace Translator.Storing.Repositories
{
  public class MessageRepository
  {
    private static readonly TranslatorDbContext _db = new TranslatorDbContext();
    public List<Message> GetAllMessages()
    {
      return _db.Message.Include(u => u.User).ToList();
    }
    public Message GetMessage(int id)
    {
      return _db.Message.Where(m => m.MessageId == id).Include(u => u.User).FirstOrDefault();
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