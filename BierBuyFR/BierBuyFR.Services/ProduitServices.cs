using BierBuyFR.Database;
using BierBuyFR.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BierBuyFR.Services
{
   public class ProduitServices
    {
        public List<Produit> GetProduits()
        {
            using (var context = new BBFRContext())
            {
                return context.Produits.ToList();
            }
        }

        public Produit GetProduit(int ID)
        {
            using (var context = new BBFRContext())
            {
                return context.Produits.Find(ID);
            }
        }
        public void SaveProduit(Produit produit)
        {
            using (var context= new BBFRContext())
            {
                context.Produits.Add(produit);
                context.SaveChanges();
            }
        }

        public void UpdateProduit(Produit produit)
        {
            using (var context = new BBFRContext())
            {
                context.Entry(produit).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduit(int ID)
        {
            using (var context = new BBFRContext())
            {
                var produit = context.Produits.Find(ID);
                context.Produits.Remove(produit);
                context.SaveChanges();
            }
        }
    }
}
