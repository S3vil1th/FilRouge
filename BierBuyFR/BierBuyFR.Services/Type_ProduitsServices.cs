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
        //Methode permettant de récupérer une Liste de toutes les catégories (Pour la création d'un produit)
        public List<Type_Produit> GetType_Produits()
        {
            using (var context = new BBFRContext())
            {
                return context.Type_Produits.ToList();
            }
        }
        //Non utilisé
        public int GetType_ProduitCount(string search)
        {
            using (var context = new BBFRContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Type_Produits.Where(type_produit => type_produit.Type != null &&
                    type_produit.Type.ToLower().Contains(search.ToLower())).Count();
                }
                else
                {
                    return context.Type_Produits.Count();
                }
            }
        }
        //Permet de récupérer une Liste de toute les catégories 
        public List<Type_Produit> GetAllType_Produits()
        {
            using (var context = new BBFRContext())
            {
                return context.Type_Produits
                        .ToList();
            }
        }
        //Permet de récupérer  UNE catégorie par son ID
        public Type_Produit GetType_Produit(int ID)
        {
            using (var context = new BBFRContext())
            {
                return context.Type_Produits.Find(ID);
            }
        }

        //Permet de sauvegarder une catégorie dans la BDD
        public void SaveType_Produit(Type_Produit type_produit)
        {
            using (var context= new BBFRContext())
            {
                context.Type_Produits.Add(type_produit);
                context.SaveChanges();
            }
        }
        //Permet de mettre a jour une catégorie dans la BDD
        public void UpdateType_Produit(Type_Produit type_produit)
        {
            using (var context = new BBFRContext())
            {
                context.Entry(type_produit).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        //Permet de supprimer une catégorie de la BDD
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
