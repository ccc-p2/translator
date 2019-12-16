using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Translator.Storing.Models;
using TR = Translator.Domain.Models.Translator;

namespace Translator.Storing.Repositories
{
  public class UserRepository
  {
    private static readonly TranslatorDbContext _db = new TranslatorDbContext();

    public async Task<List<Message>> GetAllMessagesTranslated(int userId)
    {
      List<Message> allMessages = _db.Message.ToList();
      var user = GetUser(userId);
      TR miniTranslator = new TR();
      foreach(Message m in allMessages)
      {
        m.Content = await miniTranslator.Translate(m.Content, user.Language);
      }
      return await Task.FromResult(allMessages);
    }
    

    public User GetUser(int userId)
    {
      return _db.User.FirstOrDefault(u => u.UserId == userId);
    }
    public List<User> GetAllUsers()
    {
      return _db.User.Include(m => m.Messages).ToList();
    }
    public bool AddNewUser(User newUser)
    {
      _db.User.Add(newUser);
      return _db.SaveChanges() == 1;      
    } 

    public User CheckForUser(string username, string password)
    {
      return _db.User.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
  }
}