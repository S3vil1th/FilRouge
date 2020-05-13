using BierBuyFR.Entitie;
using BierBuyFR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BierBuyFR.Web.ViewModel
{
    
        public class ValiderViewModel
        {
            public List <Produit> PanierProduits { get; set; }
            public List<int> PanierProduitID { get; set; }

            public ApplicationUser User { get; set; }
        }

        public class ShopViewModels
        {
           
            public List<Type_Produit> DifferentesCategories { get; set; }
            public List<Produit> Produits { get; set; }
            public int? SortBy { get; set; }
            public int? Type_ProduitID { get; set; }
            public string Search { get; set; }
        }

        public class FiltreProduitsViewModel
        {
            public List<Produit> Produits { get; set; }
            public int? Type_ProduitID { get; set; }
            public string Search { get; set; }
            public int? SortBy { get; set; }
        }
    
}