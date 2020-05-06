using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BierBuyFR.Entitie
{
    public class Type_Produit
    {
        
        //Primary key
        public int Type_ProduitID { get; set; }
        //Propriétés de la classe Type_Produit
        public string Type { get; set; }
        public string Commentaire { get; set; }

        //Foreign Key vers Produit
        public List<Produit> Produits { get; set; }
    }
}
