using BierBuyFR.Database;
using BierBuyFR.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BierBuyFR.Services
{
    public class ShopServices
    {
        public int SaveCommande(Commande commande)
        {
            using (var context = new BBFRContext())
            {
                context.Commandes.Add(commande);
                return context.SaveChanges();
            }
        }
    }
}
