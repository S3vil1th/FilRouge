using BierBuyFR.Database;
using BierBuyFR.Entitie;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BierBuyFR.Services
{
    public class CommandeService
    {
        public int SearchCommandes(string userID, string statut)
        {
            using (var context = new BBFRContext())
            {
                var commandes = context.Commandes.ToList();

                if(!string.IsNullOrEmpty(userID))
                {
                    commandes = commandes.Where(x => x.UserID.ToLower().Contains(userID.ToLower())).ToList();
                }

                if(!string.IsNullOrEmpty(statut))
                {
                    commandes= commandes.Where(x => x.Statut.ToLower().Contains(statut.ToLower())).ToList();
                }
                return commandes.Count;
            }
        }

        public Commande GetCommandeByID(int ID)
        {
            using (var context = new BBFRContext())
            {
                return context.Commandes.Where(x => x.ID == ID).Include(x => x.ProduitsCommandes).Include("ProduitsCommandes.Produit").FirstOrDefault();
            }
        }

        public bool UpdateCommandeStatut(int ID, string statut)
        {
            using (var context = new BBFRContext())
            {
                var commande = context.Commandes.Find(ID);

                commande.Statut = statut;

                context.Entry(commande).State = EntityState.Modified;

                return context.SaveChanges() > 0;
            }
        }

    }
}
