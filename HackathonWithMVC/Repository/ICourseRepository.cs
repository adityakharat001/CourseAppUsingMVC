using HackathonWithMVC.Models;

namespace HackathonWithMVC.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAllCourses();
        List<Course> GetCoursesByCategory(int id);
        bool AddToCart(int id,User user);
        List<Cart> ShowCart(int id);
        bool RemoveFromCart(int id, User user);
        Course CourseDetails(int id);
        Course BuyCourse(int id);
        bool AddCourseForAdmin(Course course);
        Course GetCourseById(int id);
        bool UpdatedCourse(Course course);
        bool DeleteCourseDetails(Course course);
        bool Pay(int id);
        bool IsBilled(int id,User user);
        Cart BuyBill(int id, User? user);
        List<Cart> Orders(int id);
    }
}
