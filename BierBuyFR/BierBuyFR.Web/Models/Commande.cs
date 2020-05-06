using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BierBuyFR.Web.Models
{
    public enum StatutCommande { Traitement, Valider, Echec }
    public enum TypePaiement { Cb, Cheque, Paypal, Virement}
    public class Commande
    {
        public string CommandID { get; set; }
        public string Commentaire { get; set; }
        public DateTime DateCommande { get; set; }
        public StatutCommande StatutCommande { get; set; }
        public TypePaiement TypePaiement { get; set; }
        public decimal? Remise { get; set; }
    }
}