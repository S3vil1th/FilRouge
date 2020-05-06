using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BierBuyFR.Web.Models
{
    public enum Civilite { M, Mme }

    public class User
    {
        public string UserID { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Civilite Civilite { get; set; }
        public int Role { get; set; }
        public DateTime DateCreation { get; set; }
        public int NumRue { get; set; }
        public string Rue { get; set; }
        public int TelPort { get; set; }
        public int TelFix { get; set; }
        public int Cp { get; set; }
        public string Ville { get; set; }
        public string Autre { get; set; }

    }
}