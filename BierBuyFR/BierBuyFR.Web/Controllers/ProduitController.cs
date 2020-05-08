using BierBuyFR.Entitie;
using BierBuyFR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BierBuyFR.Web.Controllers
{
    public class ProduitController : Controller
    {
        ProduitServices produitsService = new ProduitServices();
        // GET: Produit
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProduitTable(string search)
        {

            var produits = produitsService.GetProduits();

            if (string.IsNullOrEmpty(search) == false)
            {
                produits = produits.Where(p => p.Nom !=null && p.Nom.ToLower().Contains(search.ToLower())).ToList();
            }
            return PartialView(produits);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Produit produit)
        {
            produitsService.SaveProduit(produit);
            return RedirectToAction("ProduitTable");
        }
    }
}