using BierBuyFR.Entitie;
using BierBuyFR.Services;
using BierBuyFR.Web.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;


namespace BierBuyFR.Web.Controllers
{
    public class ShopController : Controller
    {
        ShopServices shopService = new ShopServices();
        Type_ProduitsServices type_produitService = new Type_ProduitsServices();
        ProduitServices produitsService = new ProduitServices();
        
        // GET: Shop
        public ActionResult Index( string search, int? type_produitID, int? sortBy)
        {
            ShopViewModels model = new ShopViewModels();

            model.Search = search;
            model.DifferentesCategories = type_produitService.GetAllType_Produits();
            model.SortBy = sortBy;
            model.Type_ProduitID = type_produitID;
            model.Produits = produitsService.SearchProduits(search, type_produitID, sortBy);

            return View(model);
        }

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

        [Authorize]
        public ActionResult Validation()
        {
            ValiderViewModel model = new ValiderViewModel();

            var CookiePanierProduits = Request.Cookies["PanierProduits"];

            if(CookiePanierProduits != null && !string.IsNullOrEmpty(CookiePanierProduits.Value))
            {
                model.PanierProduitID = CookiePanierProduits.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.PanierProduits = produitsService.GetProduits(model.PanierProduitID);
                model.User = UserManager.FindById(User.Identity.GetUserId());
            }

            return View(model);
        }

        public JsonResult AjouterCommande(string produitsIDs)
        {
            
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            if (!string.IsNullOrEmpty(produitsIDs))
            {
                var quantitesProduits = produitsIDs.Split('-').Select(x => int.Parse(x)).ToList();

                var produitsAchetes = produitsService.GetProduits(quantitesProduits.Distinct().ToList());

                Commande nouvelleCommande = new Commande();
                nouvelleCommande.UserID = User.Identity.GetUserId();
                nouvelleCommande.DateCommande = DateTime.Now;
                nouvelleCommande.Statut = "En attente de traitement";
                nouvelleCommande.MontantTotal = produitsAchetes.Sum(x => x.Prix * quantitesProduits.Where(produitsID => produitsID == x.ProduitID).Count());

                nouvelleCommande.ProduitsCommandes = new List<ProduitsCommande>();
                nouvelleCommande.ProduitsCommandes.AddRange(produitsAchetes.Select(x => new ProduitsCommande() { ProduitID = x.ProduitID, Quantite = quantitesProduits.Where(produitID => produitID == x.ProduitID).Count() }));

                 var changements = shopService.SaveCommande(nouvelleCommande);

                result.Data = new { Success = true, Rows = changements };
            }
            else
            {
                result.Data = new { Success = false };
            }

            return result;
        }

        public ActionResult FiltreProduit(string search, int? type_produitID, int? sortBy)
        {
            FiltreProduitsViewModel model = new FiltreProduitsViewModel();

            model.Search = search;
            model.SortBy = sortBy;
            model.Type_ProduitID = type_produitID;
            model.Produits = produitsService.SearchProduits(search, type_produitID, sortBy);

            return PartialView(model);
        }
    }
}