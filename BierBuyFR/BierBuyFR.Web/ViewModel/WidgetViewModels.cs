using BierBuyFR.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BierBuyFR.Web.ViewModel
{
    public class ProduitsWidgetViewModels
    {
        public List<Produit> Produits { get; set; }
        public bool DernierProduit { get; set; }
    }
}