using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BierBuyFR.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BierBuyFR.Web.Controllers
{
    [Authorize(Roles = "Administrateur")]
    public class AdminController : Controller
    {
        //ajout du context qui servira lors des ajouts user/role
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            string UserName = form["txtMail"];
            string email = form["txtMail"];
            string pwd = form["txtPassword"];

            var user = new ApplicationUser();
            user.UserName = UserName;
            user.Email = email;


            var newuser = userManager.Create(user, pwd);

            return View();
        }
        public ActionResult AssignRole()
        {
            ViewBag.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AssignRole(FormCollection form)
        {
            string addusrname = form["txtUserName"];
            string addrolname = form["RoleName"];
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(addusrname, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.AddToRole(user.Id, addrolname);
            return View("index");
        }



        public ActionResult DeleteRole()
        {
            ViewBag.Roles = context.Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult DeleteRole(FormCollection form)
        {
            string supusrname = form["txtUserName"];
            string suprolname = form["RoleName"];
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(supusrname, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            userManager.RemoveFromRole(user.Id, suprolname);
            return View("index");
        }
    }
}