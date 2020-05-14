using BierBuyFR.Services;
using BierBuyFR.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BierBuyFR.Web.Controllers
{
    public class WidgetsController : Controller
    {
        //TEST: Widget permettant un tri et retour des derniers produits enregistrés
        public ActionResult Produits(bool dernierProduit, int? type_produitID = 0)
        {
            ProduitServices produitServices = new ProduitServices();
            ProduitsWidgetViewModels model = new ProduitsWidgetViewModels();
            model.DernierProduit = dernierProduit;

            if (dernierProduit)
            {
                model.Produits = produitServices.GetDernierProduit(4);
            }
            else if (type_produitID.HasValue && type_produitID.Value > 0)
            {
                model.Produits = produitServices.GetProduitParCategorie(type_produitID.Value);
            }
            else
            {
                model.Produits = produitServices.GetProduits();
            }

            return PartialView(model);
        }
    }
}