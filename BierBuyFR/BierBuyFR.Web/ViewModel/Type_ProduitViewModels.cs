using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BierBuyFR.Web.ViewModels
{
    public class NewType_ProduitViewModel
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }

        public int Type_ProduitID { get; set; }
    }
}