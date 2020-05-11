using BierBuyFR.Database;
using BierBuyFR.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BierBuyFR.Services
{
   public class Type_ProduitsServices
    {
        public List<Type_Produit> GetType_Produits()
        {
            using (var context = new BBFRContext())
            {
                return context.Type_Produits.ToList();
            }
        }
        public List<Type_Produit> GetAllType_Produits()
        {
            using (var context = new BBFRContext())
            {
                return context.Type_Produits
                        .ToList();
            }
        }
        public Type_Produit GetType_Produit(int ID)
        {
            using (var context = new BBFRContext())
            {
                return context.Type_Produits.Find(ID);
            }
        }
        public void SaveType_Produit(Type_Produit type_produit)
        {
            using (var context= new BBFRContext())
            {
                context.Type_Produits.Add(type_produit);
                context.SaveChanges();
            }
        }

        public void UpdateType_Produit(Type_Produit type_produit)
        {
            using (var context = new BBFRContext())
            {
                context.Entry(type_produit).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteType_Produit(int ID)
        {
            using (var context = new BBFRContext())
            {
                var type_produit = context.Type_Produits.Find(ID);
                context.Type_Produits.Remove(type_produit);
                context.SaveChanges();
            }
        }
    }
}
