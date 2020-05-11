using BierBuyFR.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BierBuyFR.Web.ViewModels
{
    public class Type_ProduitSearchViewModel
    {
        public List<Type_Produit> Type_Produits { get; set; }
        public string Search { get; set; }

        
    }
    public class NewType_ProduitViewModel
    {
        public string Type { get; set; }
        public string Description { get; set; }
        
        public string ImageURL { get; set; }
       
    }

    public class EditType_ProduitViewModel
    {
        public int ID { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }

        public string ImageURL { get; set; }

        
    }
}