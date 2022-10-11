using HackathonWithMVC.Context;
using HackathonWithMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace HackathonWithMVC.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly UserDbContext _userDbContext;
        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }


        public bool RegisterUser(User user)
        {
            User userInDb = _userDbContext.users.Where(u => u.Email == user.Email).FirstOrDefault();
            if (userInDb == null)
            {
                _userDbContext.users.Add(user);
                return _userDbContext.SaveChanges() == 1 ? true : false;

            }
            return false;
        }

        public User LogIn(string userName, string password)
        {
            User user = _userDbContext.users.Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();
            if(user!=null && !user.IsBlocked)
            {
                user.IsLoggedIn = true;
                _userDbContext.Entry<User>(user).State = EntityState.Modified;
                _userDbContext.SaveChanges();
                return user;
            }
            return user;
        }

        

        public List<User> GetAllUsers()
        {
            return _userDbContext.users.Where(u => u.IsAdmin == false).ToList();
        }


        public User GetUsersById(int id)
        {
            User user = _userDbContext.users.Where(u => u.Id == id).FirstOrDefault();
            return user;
        }

        public bool DeleteDetails(User user)
        {
            _userDbContext.users.Remove(user);
            _userDbContext.SaveChanges();
            return true;
        }

        public bool BlockUser(int id)
        {
            User user = _userDbContext.users.Where(u => u.Id == id).FirstOrDefault();
            if (user!=null && !user.IsBlocked)
            {
                user.IsBlocked = true;
                _userDbContext.Entry<User>(user).State = EntityState.Modified;
                _userDbContext.SaveChanges();
                return false;
            }
            else
            {
                user.IsBlocked = false;
                _userDbContext.Entry<User>(user).State = EntityState.Modified;
                _userDbContext.SaveChanges();
                return true;
            }
        }

        

        public User LogOut(User? user)
        {
            User loggedUser = GetUsersById(user.Id);
            if (loggedUser.IsLoggedIn)
            {
                loggedUser.IsLoggedIn = false;
                _userDbContext.SaveChanges();
                return loggedUser;
            }
            return loggedUser;
        }
    }
}
