using BierBuyFR.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BierBuyFR.Web.ViewModels
{
    public class HomeViewModel
    {
        public List<Type_Produit> Type_Produits { get; set; }
        public List<Produit> Produits { get; set; }
    }
}