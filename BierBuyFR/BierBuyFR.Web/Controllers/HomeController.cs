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
        Type_ProduitsServices type_produitsServices = new Type_ProduitsServices();
        ProduitServices produitServices = new ProduitServices();
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.Type_Produits = type_produitsServices.GetType_Produits();
            model.Produits = produitServices.GetProduits();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}