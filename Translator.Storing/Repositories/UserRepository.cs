using System.Collections.Generic;
using System.Linq;
using Translator.Storing.Models;

namespace Translator.Storing.Repositories
{
  public class UserRepository
  {
    private static readonly TranslatorDbContext dbContext = new TranslatorDbContext();
    private const string _path = @"./Translator.Client/users.xml";
    private List<User> _userLibrary;
    public List<User> UserLibrary 
    { 
        get
        {
            return _userLibrary;
        }
    }
    public UserRepository()
    {
      //Initialize();
      if(_userLibrary == null)
      {
        try
        {
          //_userLibrary = FileAdapter.ReadFromXml<List<User>>(_path);
        }
        catch
        {
          _userLibrary = new List<User>();
          Save();
        }
      }
    }

    public List<User> GetAllUsers()
    {
      return dbContext.User.ToList();
    } 

    public void Create()
    {

    }
    public List<User> Read(User user)
    {
      if(user == null)
      {
        return _userLibrary;
      }

      return _userLibrary.Where(u => u.Username == user.Username && u.Password == user.Password).ToList();
    }
    public List<User> Initialize()
    {
      if (_userLibrary == null)
        {
            
            _userLibrary = new List<User>();

            User userInfo = new User();
            // userInfo.UserId = 456454334;
            userInfo.Username = "John";
            userInfo.Password = "12345678";
            userInfo.Language = "English";
            _userLibrary.Add(userInfo);

            _userLibrary.AddRange(new User[] 
            {
                
            });
        }

        return _userLibrary;
    }
    public User CheckForUser(string username, string password)
    {
      User checkedUser = _userLibrary.FirstOrDefault(u => u.Username == username && u.Password == password);
      return checkedUser;
    }
    public void Add(User user)
    {
      _userLibrary.Add(user);
    }
    private void Save()
    {

    }
    public void Update(User user)
    {
      var ordd = _userLibrary.FirstOrDefault(u => u.Username == user.Username);
      //doing something to update
      Save();
    }
    public void Delete(User user)
    {
      var ordd = _userLibrary.FirstOrDefault(u => u.Username == user.Username);
      _userLibrary.Remove(ordd);
      Save();
    }
  }
}