using System.Collections.Generic;
using Translator.Domain.Models;

namespace Translator.Storing.Repositories
{
  public class MessageRepository
  {
    public MessageRepository() {}

    public void Create()
    {

    }
    public List<Message> Read()
    {
      Message newMessage = new Message("First Message");
      newMessage.Id = 1;
      List<Message> MessageList = new List<Message>();
      MessageList.Add(newMessage);
      newMessage = new Message("Seccond Message");
      MessageList.Add(newMessage);
      return MessageList;
    }
    public void Update()
    {

    }
    public void Delete()
    {

    }
      
  }
}