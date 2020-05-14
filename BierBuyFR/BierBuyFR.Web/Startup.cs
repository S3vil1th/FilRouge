using BierBuyFR.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BierBuyFR.Web.Startup))]
namespace BierBuyFR.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
        }
        public void CreateUserAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext(); //ajout du Dbcontext Identity

            //Déclaration varaible userManager
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //Déclaration varaible roleManager
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // - - - - - - Création des rôles - - - - - -

            if (!roleManager.RoleExists("Administrateur"))
            {
                //création du role Administrateur
                var role = new IdentityRole();
                role.Name = "Administrateur";
                roleManager.Create(role);


                //création du Administrateur par défaut
                var user = new ApplicationUser();
                user.UserName = "Administrateur@BierBuyFR.Web";
                user.Email = "Administrateur@BierBuyFR.Web";
                string pwd = "PasswordAdministrateur";
                user.Nom = "Admin";
                user.Prenom = "Admin";
                user.Ville = "Partout";


                var newuser = userManager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Administrateur");
                }
            }

            if (!roleManager.RoleExists("Commercial"))
            {
                //création du role Commercial
                var role = new IdentityRole();
                role.Name = "Commercial";
                roleManager.Create(role);


                //création du commercial par défaut
                var user = new ApplicationUser();
                user.UserName = "Commercial@BierBuyFR.Web";
                user.Email = "Comercial@BierBuyFR.Web";
                string pwd = "PasswordCommercial";

                var newuser = userManager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Commercial");
                }
            }
            if (!roleManager.RoleExists("Client"))
            {
                //création du role Client
                var role = new IdentityRole();
                role.Name = "Client";
                roleManager.Create(role);


                //création du Client par défaut
                var user = new ApplicationUser();
                user.UserName = "Client@BierBuyFR.Web";
                user.Email = "Client@BierBuyFR.Web";
                string pwd = "PasswordClient";

                var newuser = userManager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Client");
                }
            }

            if (!roleManager.RoleExists("Editeur"))
            {
                //création du role Editeur
                var role = new IdentityRole();
                role.Name = "Editeur";
                roleManager.Create(role);


                //création du Editeur par défaut
                var user = new ApplicationUser();
                user.UserName = "Editeur@BierBuyFR.Web";
                user.Email = "Editeur@BierBuyFR.Web";
                string pwd = "PasswordEditeur";

                var newuser = userManager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Editeur");
                }
            }

            if (!roleManager.RoleExists("Manager"))
            {
                //création du role Manager
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);


                //création du Manager par défaut
                var user = new ApplicationUser();
                user.UserName = "Manager@BierBuyFR.Web";
                user.Email = "Manager@BierBuyFR.Web";
                string pwd = "PasswordManager";

                var newuser = userManager.Create(user, pwd);
                if (newuser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }
            }

            // - - - - - - Création des rôles - - - - - -
        }
    }
}
