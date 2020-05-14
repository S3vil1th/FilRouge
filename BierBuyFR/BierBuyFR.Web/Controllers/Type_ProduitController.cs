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
        //Instanciation des services a utiliser
        Type_ProduitsServices type_produitService = new Type_ProduitsServices();
        //Controleur d'affichage de l'INDEX des catégories
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //Controleur d'affichage de la table des catégories, les regroupants toutes pour un affichage dynamique
        public ActionResult CategoryTable(string search)
        {
            Type_ProduitSearchViewModel model = new Type_ProduitSearchViewModel();
            model.Search = search;

            var totalDeProduits = type_produitService.GetType_ProduitCount(search);
            model.Type_Produits = type_produitService.GetType_Produits();
            
            return PartialView("CategoryTable",model);
        }
        //Controleur d'affichage de la CREATION d'une catégorie, partie DEMANDE des informations
        [HttpGet]
        public ActionResult Create()
        {
            NewType_ProduitViewModel model = new NewType_ProduitViewModel();
            return PartialView(model);
        }

        //Controleur d'ENVOI des informations saisies dans la CREATION d'une catégorie
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
        //Controleur d'affichage de la MODIFICATION d'une catégorie, partie DEMANDE des informations
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
        //Controleur d'ENVOI des informations saisies dans la MODIFICATION d'une catégorie
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


        //Controleur de suppression d'une catégorie
        [HttpPost]
        public ActionResult Delete(int ID)
        {
           
            type_produitService.DeleteType_Produit(ID);

            return RedirectToAction("CategoryTable");
        }
    }
}