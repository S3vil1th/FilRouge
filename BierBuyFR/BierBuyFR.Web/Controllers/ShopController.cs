using BierBuyFR.Entitie;
using BierBuyFR.Services;
using BierBuyFR.Web.MethodeEnum;
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
        //Instanciation des Services a utiliser

        ShopServices shopService = new ShopServices();
        Type_ProduitsServices type_produitService = new Type_ProduitsServices();
        ProduitServices produitsService = new ProduitServices();
        
        // Controleur de l'affichage de l'INDEX du MAGASIN, avec en paramétre une string recherche, et les ID des catégories
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
        //Instanciation de Identity pour l'utilisation et mise en place des roles
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
        // Controleur de VALIDATION du panier dans le but de créer une commande par un utilisateur
        [Authorize]
        public ActionResult Validation()
        {
            ValiderViewModel model = new ValiderViewModel();
            // récupération des cookies des produits sélectionnés par l'utilisateur
            var CookiePanierProduits = Request.Cookies["PanierProduits"];
            //
            if(CookiePanierProduits != null && !string.IsNullOrEmpty(CookiePanierProduits.Value))
            {
                model.PanierProduitIDs = CookiePanierProduits.Value.Split('-').Select(x => int.Parse(x)).ToList();
                model.PanierProduits = produitsService.GetProduits(model.PanierProduitIDs);
                model.User = UserManager.FindById(User.Identity.GetUserId());
            }

            return View(model);
        }
        //Controleur de transformation du PANIER en COMMANDE
        public JsonResult AjouterCommande(string produitsIDs)
        {
            
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            if (!string.IsNullOrEmpty(produitsIDs))
            {
                //récupération de la quantité de chaque produits ajoutés

                var quantitesProduits = produitsIDs.Split('-').Select(x => int.Parse(x)).ToList();

                //récupération des produits sélectionnés
                var produitsAchetes = produitsService.GetProduits(quantitesProduits.Distinct().ToList());

                //Instanciation et remplissage de la commande
                Commande nouvelleCommande = new Commande();
                nouvelleCommande.UserID = User.Identity.GetUserId();
                nouvelleCommande.DateCommande = DateTime.Now;
                nouvelleCommande.Statut = "En attente de traitement";
                nouvelleCommande.MontantTotal = produitsAchetes.Sum(x => x.Prix * quantitesProduits.Where(produitsID => produitsID == x.ProduitID).Count());

                nouvelleCommande.ProduitsCommandes = new List<ProduitsCommande>();
                nouvelleCommande.ProduitsCommandes.AddRange(produitsAchetes.Select(x => new ProduitsCommande() { ProduitID = x.ProduitID, Quantite = quantitesProduits.Where(produitID => produitID == x.ProduitID).Count() }));
                //Sauvegarde de la commande
                 var changements = shopService.SaveCommande(nouvelleCommande);

                result.Data = new { Success = true, Rows = changements };
            }
            else
            {
                result.Data = new { Success = false };
            }

            return result;
        }
        //Controleur pour filtrer les produits par recherche et par catégories (non effectif)
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