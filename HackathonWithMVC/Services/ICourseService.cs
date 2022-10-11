using HackathonWithMVC.Models;

namespace HackathonWithMVC.Services
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();
        List<Course> GetCoursesByCategory(int id);
        bool AddToCart(int id, User user);
        bool RemoveFromCart(int id, User user);
        List<Cart> ShowCart(int id);
        Course CourseDetails(int id);
        Course BuyCourse(int id);
        bool AddCourseForAdmin(Course course);
        Course GetCourseById(int id);
        bool UpdateCourse(int id, Course course);
        bool DeleteCourseDetails(Course course);
        bool Pay(int id);
        bool IsBilled(int id, User user);
        Cart BuyBill(int id, User? user);
        List<Cart> Orders(int id);
    }
}
