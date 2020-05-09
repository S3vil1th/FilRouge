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

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var produit = produitsService.GetProduit(ID);
            return PartialView();
        }

        [HttpPost]
        public ActionResult Edit(Produit produit)
        {
            produitsService.UpdateProduit(produit);
            return RedirectToAction("ProduitTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            produitsService.DeleteProduit(ID);
            return RedirectToAction("ProduitTable");
        }
    }
}