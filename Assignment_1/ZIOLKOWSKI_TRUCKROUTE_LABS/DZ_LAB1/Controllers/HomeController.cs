using DZ_LAB1.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Web;

namespace DZ_LAB1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //reference used for storing object upon login and for passing it to the next view.
        private static UserProfile SignedInUser;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }


        public IActionResult Index()
        {
            HttpContext.SignOutAsync();
            return View();
        
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount(UserProfile userProfile)
        {
            HttpContext.SignOutAsync();
            bool allowedToCreate = true;
            if (ModelState.IsValid)
            {
                UserProfile newProfile = userProfile;

                foreach (UserProfile profile in UserProfileRepository._UserProfiles)
                {
                    if (userProfile._EmailAddress == profile._EmailAddress)
                    {
                        var errormessage = "This email already seems to exist. Would you like to try to <a href='login'>login</a>";
                        ModelState.AddModelError("", errormessage);
                        allowedToCreate = false;
                        break;
                    }
                }

                if (userProfile._Password != userProfile._ConfirmationPassword)
                {
                    ModelState.AddModelError("_ConfirmationPassword", "The passwords do not match.");
                    allowedToCreate = false;
                }

                if (allowedToCreate)
                {
                    Console.WriteLine("Account sucessfully created.");

                    Console.WriteLine($"The user email is: {userProfile._EmailAddress}");
                    Console.WriteLine($"The user first name is: {userProfile._FirstName}");
                    Console.WriteLine($"The user last name is: {userProfile._LastName}");
                    Console.WriteLine($"The user password is: {userProfile._Password}");
                    Console.WriteLine($"The user phone number is: {userProfile._PhoneNumber}");

                    UserProfileRepository.AddUserProfile(userProfile);
                    return RedirectToAction("Login");
                }
                else
                {
                    return View("Index");
                }
            }
            return View("Index");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserProfile userProfile)
        {
            //if the login is sucessfull we go to dashboard with the signed in user info.

            bool allowedToLogin = false;
            foreach (UserProfile profile in UserProfileRepository._UserProfiles)
            {
                Console.WriteLine($"The user email is: {profile._EmailAddress}");
                Console.WriteLine($"The user password is: {profile._Password}");
                if (userProfile._EmailAddress == profile._EmailAddress && userProfile._Password == profile._Password)
                {
                    SignedInUser = new UserProfile();
                    SignedInUser._EmailAddress = profile._EmailAddress;
                    SignedInUser._Password = profile._Password;
                    SignedInUser._ConfirmationPassword = profile._ConfirmationPassword;
                    SignedInUser._FirstName = profile._FirstName;
                    SignedInUser._LastName = profile._LastName;
                    SignedInUser._PhoneNumber = profile._PhoneNumber;
                    allowedToLogin = true;
                    break;
                }
            }


            if (allowedToLogin)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, SignedInUser._EmailAddress), 
                    new Claim(ClaimTypes.Role, "User"),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


                // Create an authentication ticket for the user
                var principal = new ClaimsPrincipal(identity);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
                return RedirectToAction("DashBoard", SignedInUser);
            }
            else
            {
                ModelState.AddModelError("_Password", "The Email or Password does not match.");
                return View("Login");
            }
        }

        [Authorize]
        public IActionResult DashBoard(UserProfile ouruser)
        {
                Console.WriteLine($"The user email is: {SignedInUser._EmailAddress}");
                Console.WriteLine($"The user first name is: {SignedInUser._FirstName}");
                Console.WriteLine($"The user last name is: {SignedInUser._LastName}");
                Console.WriteLine($"The user password is: {SignedInUser._Password}");
                Console.WriteLine($"The user phone number is: {SignedInUser._PhoneNumber}");
            return View(SignedInUser);
         }

        public IActionResult Logout()
        {
            Console.WriteLine("I am now a logged out man.");
            HttpContext.SignOutAsync();
            return View("Login");
        }


        public IActionResult Truck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Truck(Truck truck)
        {
            TruckRepository.AddTruckProfile(truck);
            return View();
        }

        public IActionResult RoutePath()
        {
            return View();
        }


        [HttpPost]
        public IActionResult RoutePath(RoutePath route)
        {
            RouteRepository.AddRoutePath(route);
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}