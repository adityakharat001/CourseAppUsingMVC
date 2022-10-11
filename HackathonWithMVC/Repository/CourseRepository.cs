using HackathonWithMVC.Context;
using HackathonWithMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace HackathonWithMVC.Repository
{
    public class CourseRepository : ICourseRepository
    {
        readonly UserDbContext _userDbContext;
        public CourseRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public List<Course> GetAllCourses()
        {
            return _userDbContext.courses.ToList();
        }

        public List<Course> GetCoursesByCategory(int id)
        {
            if (id == 1)
            {
                return _userDbContext.courses.Where(c => c.Category == "Web Development").ToList();
            }
            else if (id == 2)
            {
                return _userDbContext.courses.Where(c => c.Category == "Investing and Trading").ToList();
            }
            else if (id == 3)
            {
                return _userDbContext.courses.Where(c => c.Category == "3D and Animation").ToList();
            }
            else if (id == 4)
            {
                return _userDbContext.courses.Where(c => c.Category == "Fitness").ToList();
            }
            else if (id == 5)
            {
                return _userDbContext.courses.Where(c => c.Category == "Musical Instruments").ToList();
            }
            return _userDbContext.courses.ToList();
        }


        public bool AddToCart(int id, User user)
        {

            Course course = _userDbContext.courses.Where(x => x.Id == id).FirstOrDefault();
            Cart courseExist = _userDbContext.carts.Where(x => x.CourseName == course.CourseName && x.UserId == user.Id).FirstOrDefault();
            if (courseExist == null)
            {
                Cart cart = new Cart();
                cart.CourseId = course.Id;
                cart.UserId = user.Id;
                cart.CourseName = course.CourseName;
                cart.Price = course.Price;
                cart.ImgPath = course.ImgPath;
                _userDbContext.carts.Add(cart);
                _userDbContext.SaveChanges();
                return true;
            }
            return false;
        }


        public bool RemoveFromCart(int id, User user)
        {
            Cart cartCourse = _userDbContext.carts.Where(x => x.Id == id && x.UserId == user.Id).FirstOrDefault();
            if (cartCourse != null)
            {
                _userDbContext.carts.Remove(cartCourse);
                _userDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Cart> ShowCart(int id)
        {
            return _userDbContext.carts.Where(u => u.UserId == id && u.IsBilled != true).ToList();
        }

        public Course CourseDetails(int id)
        {
            Course course = _userDbContext.courses.Where(c => c.Id == id).FirstOrDefault();
            return course;
        }

        public Course BuyCourse(int id)
        {
            Course course = _userDbContext.courses.Where(c => c.Id == id).FirstOrDefault();
            return course;
        }

        public bool IsBilled(int id, User user)
        {
            Cart cartExist = _userDbContext.carts.Where(c => c.CourseId == id && c.IsBilled == true && c.UserId == user.Id).FirstOrDefault();
            if (cartExist != null)
            {
            return true;
            }
            return false;
        }

        public bool AddCourseForAdmin(Course course)
        {
            Course courseInDb = _userDbContext.courses.Where(c => c.CourseName == course.CourseName).FirstOrDefault();
            if (courseInDb == null)
            {
                _userDbContext.courses.Add(course);
                return _userDbContext.SaveChanges() == 1 ? true : false;

            }
            return false;
        }

        public Course GetCourseById(int id)
        {
            Course course = _userDbContext.courses.Where(c => c.Id == id).FirstOrDefault();
            return course;
        }

        public bool UpdatedCourse(Course course)
        {
            _userDbContext.Entry<Course>(course).State = EntityState.Modified;
            _userDbContext.SaveChanges();
            return true;
        }

        public bool DeleteCourseDetails(Course course)
        {
            _userDbContext.courses.Remove(course);
            _userDbContext.SaveChanges();
            return true;
        }

        public bool Pay(int id)
        {
            List<Cart> userCart = _userDbContext.carts.Where(u => u.UserId == id).ToList();
            if (userCart != null)
            {
                foreach (Cart course in userCart)
                {
                    course.IsBilled = true;
                    _userDbContext.Entry<Cart>(course).State = EntityState.Modified;
                    _userDbContext.SaveChanges();
                }
            }
            return false;
        }

        public Cart BuyBill(int id, User? user)
        {
            Course course = _userDbContext.courses.Where(x => x.Id == id).FirstOrDefault();
            Cart courseExist = _userDbContext.carts.Where(x => x.CourseName == course.CourseName && x.UserId == user.Id && x.IsBilled == true).FirstOrDefault();
            if(courseExist == null)
            {
                Cart cart = new Cart();
                cart.CourseId = course.Id;
                cart.UserId = user.Id;
                cart.CourseName = course.CourseName;
                cart.Price = course.Price;
                cart.ImgPath = course.ImgPath;
                _userDbContext.carts.Add(cart);
                cart.IsBilled = true;
                _userDbContext.SaveChanges();
                return cart;
            }
            return courseExist;

        }

        public List<Cart> Orders(int id)
        {
            return _userDbContext.carts.Where(u => u.UserId == id && u.IsBilled == true).ToList();
        }
    }
}
