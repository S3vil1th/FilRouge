using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BierBuyFR.Entitie
{
    class Commande
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public DateTime DateCommande { get; set; }
        public string statut { get; set; }

        public decimal MontantTotal { get; set; }

        public virtual List<ProduitsCommande> ProduitsCommandes { get; set; }
    }
}
