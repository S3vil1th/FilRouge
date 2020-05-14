using BierBuyFR.Entitie;
using BierBuyFR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BierBuyFR.Web.ViewModel
{
    //Modèle d'affichage de Validation d'un panier
        public class ValiderViewModel
        {
            public List <Produit> PanierProduits { get; set; }
            public List<int> PanierProduitIDs { get; set; }
            public ApplicationUser User { get; set; }
        }
    //Modèle d'affichage du MAGASIN
        public class ShopViewModels
        {
           
            public List<Type_Produit> DifferentesCategories { get; set; }
            public List<Produit> Produits { get; set; }
            public int? SortBy { get; set; }
            public int? Type_ProduitID { get; set; }
            public string Search { get; set; }
        }
    //Modèle d'affichage des produits avec Filtrage
        public class FiltreProduitsViewModel
        {
            public List<Produit> Produits { get; set; }
            public int? Type_ProduitID { get; set; }
            public string Search { get; set; }
            public int? SortBy { get; set; }
        }
    
}