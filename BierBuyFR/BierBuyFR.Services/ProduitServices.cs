﻿using BierBuyFR.Database;
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
        //Methode récupérant PLUSIEURS produits, grace a une liste
        public List<Produit> GetProduits()
        {
            using (var context = new BBFRContext())
            {
                return context.Produits.Include(x=>x.Type_Produit).ToList();
               
            }
        }
        //Methode récupérant PLUSIEURS produits, grace a une liste, mais depuis une liste d'IDs (par exemple utiliser les IDs présent dans une catégorie)
        public List<Produit> GetProduits(List<int> IDs)
        {
            using (var context = new BBFRContext())
            {
                return context.Produits.Where(produit => IDs.Contains(produit.ProduitID)).ToList();

            }
        }

        //Methode récupérant UN produit grace a son ID
        public Produit GetProduit(int ID)
        {
            using (var context = new BBFRContext())
            {
                return context.Produits.Find(ID);
            }
        }

        //Methode pour sauvegarder un produit
        public void SaveProduit(Produit produit)
        {
            using (var context= new BBFRContext())
            {
                context.Entry(produit.Type_Produit).State = EntityState.Unchanged;

                context.Produits.Add(produit);
                context.SaveChanges();
            }
        }
        //Methode pour mettre a jour dans la BDD un produit aprés modification de celui-ci
        public void UpdateProduit(Produit produit)
        {
            using (var context = new BBFRContext())
            {
                context.Entry(produit).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        //Methode de Suppression d'un produit de la BDD
        public void DeleteProduit(int ID)
        {
            using (var context = new BBFRContext())
            {
                var produit = context.Produits.Find(ID);
                context.Produits.Remove(produit);
                context.SaveChanges();
            }
        }
        //Methode pour récupérer PLUSIEURS produit dans une liste, grace a une recherche de type string (Non utilisé)
        public List<Produit> SearchProduits (string search, int? type_produitID, int? sortBy)
        {
            using (var context = new BBFRContext())
            {
                var produits = context.Produits.ToList();

                if(type_produitID.HasValue)
                {
                    produits = produits.Where(x => x.Type_Produit.Type_ProduitID == type_produitID.Value).ToList();
                }

                if(!string.IsNullOrEmpty(search))
                {
                    produits = produits.Where(x => x.Nom.ToLower().Contains(search.ToLower())).ToList();
                }
                if (sortBy.HasValue)
                {
                    switch (sortBy.Value)
                    {
                        case 2:
                            produits = produits.OrderByDescending(x => x.ProduitID).ToList();
                            break;
                        case 3:
                            produits = produits.OrderBy(x => x.Prix).ToList();
                            break;
                        default:
                            produits = produits.OrderByDescending(x => x.Prix).ToList();
                            break;
                    }
                }

                return produits.ToList();
            }
            
        }

        //Permet de récupérer le dernier produit enregistré (Pour le widget de Nouveaux produits sur le Home)
        public List<Produit> GetDernierProduit(int nombreProduits)
        {
            using (var context = new BBFRContext())
            {
                return context.Produits.OrderByDescending(x => x.ProduitID).Take(nombreProduits).Include(x => x.Type_Produit).ToList();
            }
        }

        //Methode pour récupérer des produits grace a l'ID d'une catégorie
        public List<Produit> GetProduitParCategorie(int type_produitID)
        {
            using (var context = new BBFRContext())
            {
                return context.Produits.Where(x => x.Type_Produit.Type_ProduitID == type_produitID).OrderByDescending(x => x.Type_ProduitID).Include(x => x.Type_Produit).ToList();
            }

        }
        //Methode pour récupérer une liste de produits depuis une recherche en String
        public List<Produit> GetProduits(string search)
        {
            using (var context = new BBFRContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.Produits.Where(produit => produit.Nom != null &&
                         produit.Nom.ToLower().Contains(search.ToLower()))
                         .OrderBy(x => x.ProduitID)                        
                         .Include(x => x.Type_Produit)
                         .ToList();
                }
                else
                {
                    return context.Produits
                        .OrderBy(x => x.ProduitID)                       
                        .Include(x => x.Type_Produit)
                        .ToList();
                }
            }
        }
    }
}
