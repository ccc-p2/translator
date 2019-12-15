using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Translator.Storing.Models;

namespace Translator.Storing.Repositories
{
  public class UserRepository
  {
    private static readonly TranslatorDbContext _db = new TranslatorDbContext();

    public User GetUser(int userId)
    {
      return _db.User.Include(m => m.Messages).FirstOrDefault(u => u.UserId == userId);
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