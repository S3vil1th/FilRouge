using BierBuyFR.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BierBuyFR.Web.ViewModel
{
    //Modèle d'affichage des catégories selon une recherche
    public class Type_ProduitSearchViewModel
    {
        public List<Type_Produit> Type_Produits { get; set; }
        public string Search { get; set; }

        
    }
    //Modèle d'affichage de la CREATION d'une catégorie
    public class NewType_ProduitViewModel
    {
        public string Type { get; set; }
        public string Description { get; set; }
        
        public string ImageURL { get; set; }
       
    }
    // Modele d'affichage de la MODIFICATION d'une catégorie
    public class EditType_ProduitViewModel
    {
        public int ID { get; set; }

        public string Type { get; set; }
        public string Description { get; set; }

        public string ImageURL { get; set; }

        
    }
}