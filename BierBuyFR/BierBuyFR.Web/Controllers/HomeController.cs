using BierBuyFR.Services;
using BierBuyFR.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BierBuyFR.Web.Controllers
{
    public class HomeController : Controller
    {
        //Instanciation des services a utiliser dans le controleur HOME

        Type_ProduitsServices type_produitsServices = new Type_ProduitsServices();
        ProduitServices produitServices = new ProduitServices();

        //Controleur de l'INDEX de la page HOME, utilisant le modéle de la vue HOME pour y intégrer les produits et catégories
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.Type_Produits = type_produitsServices.GetType_Produits();
            model.Produits = produitServices.GetProduits();

            return View(model);
        }
        //About par défaut
        public ActionResult About()
        {
            ViewBag.Message = "A propos de l'application";

            return View();
        }
        //Controleur d'affichage de la page Contact liée au Home
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}