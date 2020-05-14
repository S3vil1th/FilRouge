using BierBuyFR.Services;
using BierBuyFR.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace BierBuyFR.Web.Controllers
{
    public class ContactController : Controller
    {
        ProduitServices produitServices = new ProduitServices();
        // GET: Contact
        public ActionResult Index()
        {
            ContactViewModel model = new ContactViewModel();
            model.Produits = produitServices.GetProduits();
            return View(model);
        }

        public ActionResult SendMail(int ID, string mailClient, string commentaire)
        {
            ProduitServices produitServices = new ProduitServices();
            var produitDefectueux = produitServices.GetProduit(ID);
            
            SmtpClient Email = new SmtpClient();
            MailMessage mail = new MailMessage();
            //Expéditeur
            mail.From = new MailAddress(mailClient);
            mail.Body = commentaire;
            //Destinataire
            mail.To.Add(new MailAddress("micke_57@gmail.com"));
            //Copie
            mail.CC.Add(new MailAddress("toto@gmail.com"));

            Email.Send(mail);

            return View("Index");
        }
    }
}