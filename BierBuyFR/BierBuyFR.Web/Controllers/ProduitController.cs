using BierBuyFR.Entitie;
using BierBuyFR.Services;
using BierBuyFR.Web.ViewModel;
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
            NewProduitsViewModels model = new NewProduitsViewModels();
            model.type_produit = type_ProduitService.GetAllType_Produits();

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(NewProduitsViewModels model)
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

        [HttpPost]
        public ActionResult Edit(EditProduitViewModel model)
        {
            ProduitServices produitService = new ProduitServices();

            var existingProduct = produitService.GetProduit(model.ID);
            existingProduct.Nom = model.Nom;
            existingProduct.Description = model.Description;
            existingProduct.Prix = model.Prix;

            existingProduct.Type_Produit = null; 
            existingProduct.Type_ProduitID = model.Type_ProduitID;




            produitsService.UpdateProduit(existingProduct);

            return RedirectToAction("ProduitTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            EditProduitViewModel model = new EditProduitViewModel();
            Type_ProduitsServices type_ProduitService = new Type_ProduitsServices();
            ProduitServices produitService = new ProduitServices();

            var produit = produitService.GetProduit(ID);

            model.ID = produit.ProduitID;
            model.Nom = produit.Nom;
            model.Description = produit.Description;
            model.Prix = produit.Prix;
            model.Type_ProduitID = produit.Type_ProduitID;
            

            model.type_produit = type_ProduitService.GetType_Produits();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            produitsService.DeleteProduit(ID);
            return RedirectToAction("ProduitTable");
        }
    }
}