using BierBuyFR.Database;
using BierBuyFR.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BierBuyFR.Services
{
   public class ProduitServices
    {
        public List<Produit> GetProduits()
        {
            using (var context = new BBFRContext())
            {
                return context.Produits.Include(x=>x.Type_Produit).ToList();
               
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
                context.Entry(produit.Type_Produit).State = EntityState.Unchanged;

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
