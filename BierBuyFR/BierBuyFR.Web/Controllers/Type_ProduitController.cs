using BierBuyFR.Entitie;
using BierBuyFR.Services;
using BierBuyFR.Web.ViewModel;
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
            return View();
        }

        public ActionResult CategoryTable(string search)
        {
            Type_ProduitSearchViewModel model = new Type_ProduitSearchViewModel();
            model.Search = search;

            var totalDeProduits = type_produitService.GetType_ProduitCount(search);
            model.Type_Produits = type_produitService.GetType_Produits();
            
            return PartialView("CategoryTable",model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            NewType_ProduitViewModel model = new NewType_ProduitViewModel();
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(NewType_ProduitViewModel model)
        {

            var newCategory = new Type_Produit();
            newCategory.Type = model.Type;
            newCategory.Description = model.Description;
            newCategory.ImageURL = model.ImageURL;
            

            type_produitService.SaveType_Produit(newCategory);

            return RedirectToAction("CategoryTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditType_ProduitViewModel model = new EditType_ProduitViewModel();
            var type_produits = type_produitService.GetType_Produit(ID);
            model.ID = type_produits.Type_ProduitID;
            model.Type = type_produits.Type;
            model.Description = type_produits.Description;
            model.ImageURL = type_produits.ImageURL;
            
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(EditType_ProduitViewModel model)
        {
            var existingCategory = type_produitService.GetType_Produit(model.ID);
            existingCategory.Type = model.Type;
            existingCategory.Description = model.Description;
            existingCategory.ImageURL = model.ImageURL;
            

            type_produitService.UpdateType_Produit(existingCategory);

            return RedirectToAction("CategoryTable");
        }


        
        [HttpPost]
        public ActionResult Delete(int ID)
        {
           
            type_produitService.DeleteType_Produit(ID);

            return RedirectToAction("CategoryTable");
        }
    }
}