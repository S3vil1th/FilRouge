using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BierBuyFR.Web.Models
{
    public class UserService
    {
        
            public List<ApplicationUser> GetUsers()
            {
                using (var context = new ApplicationDbContext())
                {
                    return context.Users.ToList();

                }
            }

        public void DeleteUser(int ID)
        {
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.Find(ID);
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }



    }
}