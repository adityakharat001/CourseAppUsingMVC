using HackathonWithMVC.Models;
using HackathonWithMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HackathonWithMVC.Controllers
{
    public class CourseController : Controller
    {
        readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public ActionResult GetAllCourses()
        {
            List<Course> courses = _courseService.GetAllCourses();
            return View(courses);
        }

        public ActionResult GetCoursesByCategory(int id)
        {
            List<Course> courses = _courseService.GetCoursesByCategory(id);
            return View(courses);
        }

        public ActionResult AddToCart(int id)
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("Id"));
            if (_courseService.AddToCart(id,user))
            {   
                TempData["CourseAddInfo"] = "Course Added To Cart Successfully";
                return RedirectToAction("GetAllCourses");
            }
            else
            {
                TempData["CourseAddAlert"] = "Course Already Exists OR Course Is Already Billed";
                return RedirectToAction("GetAllCourses");

            }
        }

        public ActionResult CourseDetails(int id)
        {
            Course course = _courseService.CourseDetails(id);
            return View(course);
        }

        public ActionResult ShowCart()
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("Id"));
            List<Cart> carts = _courseService.ShowCart(user.Id);
            if(carts.Count>0)
            {
            return View(carts);

            }
            else
            {
                TempData["CartEmptyAlert"] = "Cart Is Empty";
                return RedirectToAction("GetAllCourses");
            }
        }

        public ActionResult RemoveFromCart(int id)
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("Id"));
            _courseService.RemoveFromCart(id,user);
            TempData["CourseRemovedInfo"] = "Course Removed From Cart";
            return RedirectToAction("ShowCart");
        }

        public ActionResult BuyCourse(int id)
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("Id"));
            Course course = _courseService.BuyCourse(id);
            if (_courseService.IsBilled(id, user))
            {
                TempData["CourseBilledAlert"] = "Course Is Already Billed";
                return RedirectToAction("GetAllCourses");
            }
            else
            {
                return View(course);
            }
        }

        public ActionResult GenerateBill()
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("Id"));
            List<Cart> carts = _courseService.ShowCart(user.Id);
            return View(carts);
        }

        public ActionResult GetAllCoursesForAdmin()
        {
            List<Course> courses = _courseService.GetAllCourses();
            return View(courses);
        }

        [HttpGet]
        public ActionResult AddCourseForAdmin()
        {
            ViewBag.options = new List<string>()
            {
                "Web Development", "Investing and Trading", "3D and Animation", "Fitness", "Musical Instruments"
            };
            return View();
        }
        [HttpPost]
        public ActionResult AddCourseForAdmin(Course course)
        {
            ViewBag.options = new List<string>()
            {
                "Web Development", "Investing and Trading", "3D and Animation", "Fitness", "Musical Instruments"
            };

            if (_courseService.AddCourseForAdmin(course))
            {
                TempData["AddCourseInfo"] = "Course added successfully.";
                return RedirectToAction("GetAllCoursesForAdmin");

            }
            else
            {
                TempData["AddCourseInfo"] = "Course already exists.";
                return RedirectToAction("AddCourseForAdmin");
            }
            return RedirectToAction("AddCourseForAdmin");
        }


        [HttpGet]
        public ActionResult EditCourseForAdmin(int id)
        {
            ViewBag.options = new List<string>()
            {
                "Web Development", "Investing and Trading", "3D and Animation", "Fitness", "Musical Instruments"
            };
            Course course = _courseService.GetCourseById(id);
            return View(course);
        }
        [HttpPost]
        public ActionResult EditCourseForAdmin(int id, Course course)
        {
            ViewBag.options = new List<string>()
            {
                "Web Development", "Investing and Trading", "3D and Animation", "Fitness", "Musical Instruments"
            };
            _courseService.UpdateCourse(id, course);
            return RedirectToAction("GetAllCoursesForAdmin");
        }

        public ActionResult DeleteCourse(int id)
        {
            Course courseNew = _courseService.GetCourseById(id);
            _courseService.DeleteCourseDetails(courseNew);
            TempData["CourseDelInfo"] = "Course Deleted Successfully.";
            return RedirectToAction("GetAllCoursesForAdmin");
        }

        public ActionResult PayBill()
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("Id"));
            List<Cart> carts = _courseService.ShowCart(user.Id);
            _courseService.Pay(user.Id);
            return View(carts);
        }

        public ActionResult BuyBill(int id)
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("Id"));
            Cart cartExist = _courseService.BuyBill(id,user);
            if (cartExist != null)
            {
                return View(cartExist);
            }
            else
            {
                TempData["CourseBuyAlert"] = "Course Is Already Billed";
                return RedirectToAction("GetAllCourses");

            }

        }

        public ActionResult Orders()
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("Id"));
            List<Cart> carts = _courseService.Orders(user.Id);
            if (carts.Count > 0)
            {
                return View(carts);

            }
            else
            {
                TempData["OrdersAlert"] = "No Previous Orders";
                return RedirectToAction("GetAllCourses");
            }
        }
       

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
