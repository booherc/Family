using Family.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Family.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        private ApplicationUserManager _userManager;


        public ContactController()
        {
        }

        public ContactController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Contact
        public ActionResult Index()
        {
            var users = UserManager.Users.Where(x => x.Id != "").ToList();
            return View(users);
        }

        //
        // GET: /Contact/Edit
        public ActionResult Edit(string id)
        {
            var user = UserManager.Users.Where(x => x.Id == id).FirstOrDefault();
            return View(user);
        }

        //
        // GET: /Contact/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = UserManager.Users.Where(x => x.Id == user.Id).FirstOrDefault();
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Address = user.Address;
                existingUser.Address2 = user.Address2;
                existingUser.City = user.City;
                existingUser.State = user.State;
                existingUser.Zipcode = user.Zipcode;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.UserName = user.UserName;
                UserManager.Update(existingUser);
            }

            return RedirectToAction("Users");
        }

        //
        // GET: /Contact/Details
        public ActionResult Details(string id)
        {
            var user = UserManager.Users.Where(x => x.Id == id).FirstOrDefault();
            DetailsViewModel userDetails = new DetailsViewModel
            {
                Name = user.FullName,
                Address = user.Address + " " + user.Address2,
                City = user.City,
                State = user.State,
                Zipcode = user.Zipcode,
                Phone = user.PhoneNumber,
                Email = user.Email
            };

            return View(userDetails);
        }
    }
}