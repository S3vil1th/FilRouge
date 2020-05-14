using BierBuyFR.Entitie;
using BierBuyFR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BierBuyFR.Web.ViewModels
{
    public class CommandeViewModels
    {
        public List<Commande> Commandes { get; set; }
        public string Statut { get; set; }
        public string UserID { get; set; }
    }

    public class CommandeDetailsViewModels
    {
        public List<string> StatutDisponible { get; set; }
        public Commande Commande { get; set; }

        public ApplicationUser Acheteur { get; set; }
    }
}