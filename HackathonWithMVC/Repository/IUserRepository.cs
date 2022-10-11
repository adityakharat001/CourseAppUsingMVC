using HackathonWithMVC.Models;

namespace HackathonWithMVC.Repository
{
    public interface IUserRepository
    {
        User LogIn(string userName, string password);
        bool RegisterUser(User user);
        List<User> GetAllUsers();
        User GetUsersById(int id);
        bool DeleteDetails(User user);
        bool BlockUser(int id);
        User LogOut(User? user);
    }
}
