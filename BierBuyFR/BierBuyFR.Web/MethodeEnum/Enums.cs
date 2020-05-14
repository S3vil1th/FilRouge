using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BierBuyFR.Web.MethodeEnum
{
    //Methode d'ENUM dans le but de FILTRER les informations du magasin
    public enum SortByEnums
    {
        Default = 1,
        Populaire = 2,
        PrixFaibleAEleve = 3,
        PrixEleveAFaible = 4,
    }
}