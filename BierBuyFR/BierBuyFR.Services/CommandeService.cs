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

        //Service de recherche de commandes pour l'affichage, avec l'ID de l'user et le statut en paramétre
        public List<Commande> SearchCommandes(string userID, string statut)
        {
            using (var context = new BBFRContext())
            {
                var commandes = context.Commandes.ToList();

                //recherche de l'ID en mettant les paramétres et la recherche en minuscule
                if(!string.IsNullOrEmpty(userID))
                {
                    commandes = commandes.Where(x => x.UserID.ToLower().Contains(userID.ToLower())).ToList();
                }
                //recherche du statut en mettant les paramétres et la recherche en minuscule
                if (!string.IsNullOrEmpty(statut))
                {
                    commandes= commandes.Where(x => x.Statut.ToLower().Contains(statut.ToLower())).ToList();
                }
                return commandes.ToList();
            }
        }

        //récupération d'une commande par ID avec les produits commandés
        public Commande GetCommandeByID(int ID)
        {
            using (var context = new BBFRContext())
            {
                return context.Commandes.Where(x => x.ID == ID).Include(x => x.ProduitsCommandes).Include("ProduitsCommandes.Produit").FirstOrDefault();
            }
        }
        //methode pour mettre a jour le statut de commande depuis le bouton de validation des commande/Détails
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
