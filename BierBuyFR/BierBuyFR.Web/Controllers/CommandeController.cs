using BierBuyFR.Services;
using BierBuyFR.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace BierBuyFR.Web.Controllers
{
    public class CommandeController : Controller
    {
        CommandeService commandeService = new CommandeService();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
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

        
            
            // GET: Commande
            public ActionResult Index(string userID, string statut)
            {


                CommandeViewModels model = new CommandeViewModels();
                model.UserID = userID;
                model.Statut = statut;

                model.Commandes = commandeService.SearchCommandes(userID, statut);


                return View(model);
            }

            public ActionResult Details(int ID)
            {
                CommandeDetailsViewModels model = new CommandeDetailsViewModels();

                model.Commande = commandeService.GetCommandeByID(ID);

                if (model.Commande != null)
                {
                    model.Acheteur = UserManager.FindById(model.Commande.UserID);
                }
                model.StatutDisponible = new List<string>() { "En attente de traitement", "En cours de traitement", "Expédié" };
                return View(model);
            }

            public JsonResult ChangementStatut(string statut, int ID)
            {
                JsonResult result = new JsonResult();
                result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

                result.Data = new { Success = commandeService.UpdateCommandeStatut(ID, statut) };

                return result;
            }
        }
    }