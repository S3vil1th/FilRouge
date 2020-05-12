using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BierBuyFR.Entitie
{
    public class ProduitsCommande
    {
        public int ID { get; set; }
        public int Quantite { get; set; }

        public int CommandeID { get; set; }
        public virtual Commande Commande { get; set; }
        public int ProduitID { get; set; }
        public virtual Produit Produit { get; set; }
    }
}
