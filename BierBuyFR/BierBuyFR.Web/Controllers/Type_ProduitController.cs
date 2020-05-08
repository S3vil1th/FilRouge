using BierBuyFR.Entitie;
using BierBuyFR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BierBuyFR.Web.Controllers
{
    public class Type_ProduitController : Controller
    {
        Type_ProduitsServices type_produitService = new Type_ProduitsServices();
        // GET: Type_Produit
        [HttpGet]
        public ActionResult Index()
        {
            var type_produits = type_produitService.GetType_Produits();
           
            return View(type_produits);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Type_Produit type_Produit)
        {
            type_produitService.SaveType_Produit(type_Produit);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var type_produits = type_produitService.GetType_Produit(ID);
            return View(type_produits);
        }
        [HttpPost]
        public ActionResult Edit(Type_Produit type_produit)
        {
            type_produitService.UpdateType_Produit(type_produit);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var type_produit = type_produitService.GetType_Produit(ID);
            return View(type_produit);
        }
        [HttpPost]
        public ActionResult Delete(Type_Produit type_produit)
        {
           
            type_produitService.DeleteType_Produit(type_produit.Type_ProduitID);

            return RedirectToAction("Index");
        }
    }
}