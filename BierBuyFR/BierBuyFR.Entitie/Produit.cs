using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BierBuyFR.Entitie
{
    public class Produit
    {
        //Foreign key vers Type de produit
        public virtual Type_Produit Type_Produit { get; set; }
        public int Type_ProduitID { get; set; }
        public string ImageURL { get; set; }
        //Primary Key
        public int ProduitID { get; set; }
        //Propriétés de la classe Produit
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }

        
    }
}
