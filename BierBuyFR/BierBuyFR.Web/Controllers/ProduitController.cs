using BierBuyFR.Entitie;
using BierBuyFR.Services;
using BierBuyFR.Web.ViewModels;
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
            Type_ProduitsServices type_ProduitService = new Type_ProduitsServices();
            var type_produits = type_ProduitService.GetType_Produits();
            return PartialView(type_produits);
        }

        [HttpPost]
        public ActionResult Create(NewType_ProduitViewModel model)
        {
            Type_ProduitsServices type_ProduitService = new Type_ProduitsServices();

            var newProduit = new Produit();
            newProduit.Nom = model.Nom;
            newProduit.Description = model.Description;
            newProduit.Prix = model.Prix;
            //newProduit.Type_ProduitID = model.Type_ProduitID;
            newProduit.Type_Produit = type_ProduitService.GetType_Produit(model.Type_ProduitID);

            produitsService.SaveProduit(newProduit);
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