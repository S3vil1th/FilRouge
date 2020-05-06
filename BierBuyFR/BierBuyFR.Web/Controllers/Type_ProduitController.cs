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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Type_Produit type_Produit)
        {
            type_produitService.SaveType_Produit(type_Produit);
            return View();
        }
    }
}