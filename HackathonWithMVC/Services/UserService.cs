using HackathonWithMVC.Exceptions;
using HackathonWithMVC.Models;
using HackathonWithMVC.Repository;

namespace HackathonWithMVC.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        

        public User LogIn(User user)
        {
            User userExist = _userRepository.LogIn(user.UserName, user.Password);
            if(userExist != null)
            {
                return userExist;
            }
            else
            {
                throw new UserCredentialsInvalidException("Invalid Username Or Password");
            }
        }

        public bool RegisterUser(User user)
        {
            return _userRepository.RegisterUser(user);
            
        }

        public List<User> GetAllUsers()
        {
            List<User> users = _userRepository.GetAllUsers();
            return users;
        }

        public User UserDetails(int id)
        {
            User user = _userRepository.GetUsersById(id);
            return user;
        }

        public User GetUsersById(int id)
        {
            User user = _userRepository.GetUsersById(id);
            return user;
        }

        public bool DeleteDetails(User user)
        {
            return _userRepository.DeleteDetails(user);
            
        }

        public bool BlockUser(int id)
        {
            return _userRepository.BlockUser(id);
            
        }

        public User LogOut(User? user)
        {
            return _userRepository.LogOut(user);
        }
    }
}
