using HackathonWithMVC.Exceptions;
using HackathonWithMVC.Models;
using HackathonWithMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HackathonWithMVC.Controllers
{
    public class UserController : Controller
    {

        readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(User user)
        {
            try
            {
                User userLogin = _userService.LogIn(user);
                HttpContext.Session.SetString("Id", JsonSerializer.Serialize(userLogin));


                if (userLogin != null && !userLogin.IsBlocked)
                {
                    if (userLogin.IsAdmin)
                    {
                        return RedirectToAction("GetAllUsers");
                    }
                    else
                    {
                        userLogin.IsLoggedIn = true;
                        TempData["Username"] = userLogin.UserName;
                        return RedirectToAction("GetAllCourses", "Course");
                    }
                }
                else if (userLogin != null && userLogin.IsBlocked)
                {
                    TempData["UserBlockInfo"] = "User is Blocked By Admin";
                    return RedirectToAction("LogIn");
                }
                return RedirectToAction("LogIn");
            }
            catch (UserCredentialsInvalidException ucie)
            {
                return StatusCode(500, ucie.Message);
            }
        }


        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(User user)
        {

            if (_userService.RegisterUser(user))
            {
                return RedirectToAction("LogIn");

            }
            else
            {
                TempData["RegUserInfo"] = "User Is Not Registered. The Email already exists.";
                return RedirectToAction("RegisterUser");
            }
            return RedirectToAction("RegisterUser");
        }


        public ActionResult GetAllUsers()
        {
            List<User> users = _userService.GetAllUsers();
            return View(users);
        }


        public ActionResult UserDetails(int id)
        {
            User user = _userService.GetUsersById(id);
            return View(user);
        }


        public ActionResult Delete(int id)
        {
            User userNew = _userService.GetUsersById(id);
            _userService.DeleteDetails(userNew);
            return RedirectToAction("GetAllUsers");
        }

        public ActionResult ToggleBlock(int id)
        {
            if (_userService.BlockUser(id))
            {
                TempData["BlockInfo"] = "User is Unblocked";
                return RedirectToAction("GetAllUsers");
            }
            else
            {
                TempData["BlockInfo"] = "User is Blocked";
                return RedirectToAction("GetAllUsers");
            }
        }

        public ActionResult SignOut()
        {
            User user = JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("Id"));
            _userService.LogOut(user);
            if (user.IsLoggedIn)
            {
                user.IsLoggedIn = false;
                HttpContext.Session.Clear();
                TempData["LogoutAlert"] = "Logout Successful";
                return RedirectToAction("LogIn");
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }



    }


    //public IActionResult Index()
    //{
    //    return View();
    //}
}

