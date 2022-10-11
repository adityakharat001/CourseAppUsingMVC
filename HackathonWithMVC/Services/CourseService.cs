using HackathonWithMVC.Models;
using HackathonWithMVC.Repository;

namespace HackathonWithMVC.Services
{
    public class CourseService: ICourseService
    {
        readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = _courseRepository.GetAllCourses();
            return courses;
        }

        public List<Course> GetCoursesByCategory(int id)
        {
            List<Course> courses = _courseRepository.GetCoursesByCategory(id);
            return courses;
        }

        public bool AddToCart(int id, User user)
        {
            return _courseRepository.AddToCart(id, user);
            
        }

        public bool RemoveFromCart(int id, User user)
        {
            _courseRepository.RemoveFromCart(id,user);
            return true;
        }

        public List<Cart> ShowCart(int id)
        {
            List<Cart> carts = _courseRepository.ShowCart(id);
            return carts;
        }

        public Course CourseDetails(int id)
        {
            Course course = _courseRepository.CourseDetails(id);
            return course;
        }

        public Course BuyCourse(int id)
        {
            Course course = _courseRepository.BuyCourse(id);
            return course;
        }

        public bool AddCourseForAdmin(Course course)
        {
            return _courseRepository.AddCourseForAdmin(course);
        }

        public Course GetCourseById(int id)
        {
            Course course = _courseRepository.GetCourseById(id);
            return course;
        }

        public Course UpdateCourse(int id)
        {
            Course course = _courseRepository.GetCourseById(id);
            return course;
        }

        public bool UpdateCourse(int id, Course course)
        {
            _courseRepository.UpdatedCourse(course);
            return true;
        }

        public bool DeleteCourseDetails(Course course)
        {
            _courseRepository.DeleteCourseDetails(course);
            return true;
        }

        public bool Pay(int id)
        {
            return _courseRepository.Pay(id);
        }

        public bool IsBilled(int id,User user)
        {
            return _courseRepository.IsBilled(id,user);
        }

        public Cart BuyBill(int id, User? user)
        {
            return _courseRepository.BuyBill(id, user);
        }

        public List<Cart> Orders(int id)
        {
            List<Cart> carts = _courseRepository.Orders(id);
            return carts;
        }
    }
}
