using BierBuyFR.Entitie;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BierBuyFR.Database
{
    public class BBFRContext : DbContext, IDisposable
    {
        public BBFRContext(): base("BierBuyFR") 
        {
        }
        //Création des tables de la bibliothéque Entitie
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Type_Produit> Type_Produits { get; set; }

        public DbSet<Commande> Commandes { get; set; }
        public DbSet<ProduitsCommande> ProduitsCommandes { get; set; }
    }
}
