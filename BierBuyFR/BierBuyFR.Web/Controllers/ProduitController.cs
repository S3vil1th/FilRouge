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
        //Instanciation des services a utiliser
        ProduitServices produitsService = new ProduitServices();
        // Controleur d'affichage de l'INDEX de la page produit
        public ActionResult Index()
        {
            return View();
        }

        //Controleur de liaison a la Vue PRODUITTABLE, avec en paramétre une string de recherche pour une retour des produits voulus
        public ActionResult ProduitTable(string search)
        {

            var produits = produitsService.GetProduits();

            if (string.IsNullOrEmpty(search) == false)
            {
                produits = produits.Where(p => p.Nom !=null && p.Nom.ToLower().Contains(search.ToLower())).ToList();
            }
            return PartialView(produits);
        }

        //Controleur de la page de CREATION d'un produit, au niveau du RETOUR d'une vue a sa demande
        [HttpGet]
        public ActionResult Create()
        {
            Type_ProduitsServices type_ProduitService = new Type_ProduitsServices();
            NewProduitsViewModels model = new NewProduitsViewModels();
            model.type_produit = type_ProduitService.GetAllType_Produits();

            return PartialView(model);
        }
        //Controleur de la page de CREATION d'un produit, au niveau de l'ENVOI desinformations entrées dans sa vue
        [HttpPost]
        public ActionResult Create(NewProduitsViewModels model)
        {
            Type_ProduitsServices type_ProduitService = new Type_ProduitsServices();

            //Enregistrement des paramétres du nouveau produit

            var newProduit = new Produit();
            newProduit.Nom = model.Nom;
            newProduit.Description = model.Description;
            newProduit.Prix = model.Prix;
            
            newProduit.Type_Produit = type_ProduitService.GetType_Produit(model.Type_ProduitID);

            produitsService.SaveProduit(newProduit);
            return RedirectToAction("ProduitTable");
        }
        //Controleur de la page de MODIFICATION d'un produit, au niveau de l'ENVOI des informations entrées dans sa vue
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
        //Controleur de la page de CREATION d'un produit, au niveau du RETOUR d'une vue a sa demande
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
        //Controleur de la page de SUPPRESSION d'un produit, au niveau de l'ENVOI des informations entrées dans sa vue (Validation de la suppression)
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            produitsService.DeleteProduit(ID);
            return RedirectToAction("ProduitTable");
        }
    }
}