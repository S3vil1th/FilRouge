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
        public void SaveType_Produit(Type_Produit type_Produit)
        {
            using (var context= new BBFRContext())
            {
                context.Type_Produits.Add(type_Produit);
                context.SaveChanges();
            }
        }
    }
}
