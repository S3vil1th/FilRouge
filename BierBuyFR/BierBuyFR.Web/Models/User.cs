using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BierBuyFR.Web.Models
{
    public enum Civilite { M, Mme }
    public class User
    {
        public string UserID { get; set; }
        [Required]
        [Display(Name = "Nom : ")]
        public string Nom { get; set; }
        [Required]
        [Display(Name = "Prénom : ")]
        public string Prenom { get; set; }
        [Required]
        [Display(Name = "Civilité : ")]
        public Civilite Civilite { get; set; }
        public int Role { get; set; }
        public DateTime DateCreation { get; set; }
        [Required]
        [Display(Name = "Numéro de la rue : ")]
        public int NumRue { get; set; }
        [Required]
        [Display(Name = "Nom de la rue : ")]
        public string Rue { get; set; }
        [Required]
        [Display(Name = "Numéro de téléphone Portable : ")]
        public int TelPort { get; set; }
        [Display(Name = "Numéro de téléphone fixe : ")]
        public int TelFix { get; set; }
        [Required]
        [Display(Name = "Code postal : ")]
        public int Cp { get; set; }
        [Required]
        [Display(Name = "Nom de la ville : ")]
        public string Ville { get; set; }
        [Display(Name = "Autres : ")]
        public string Autre { get; set; }
    }
}