using HackathonWithMVC.Models;

namespace HackathonWithMVC.Services
{
    public interface IUserService
    {

        User LogIn(User user);
        bool RegisterUser(User user);
        
        List<User> GetAllUsers();
        User GetUsersById(int id);
        bool DeleteDetails(User userNew);
        bool BlockUser(int id);
        User LogOut(User? user);
    }
}
