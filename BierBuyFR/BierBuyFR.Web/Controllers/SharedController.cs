using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace BierBuyFR.Web.Controllers
{
    public class SharedController : Controller
    {
        // Controleur Json permettrant l'upload d'image dans le dossier image du projet
        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            try
            {
                //récupération du fichier
                var file = Request.Files[0];
                //Formatage du Nom pour l'upload
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                //Création du CHEMIN d'ENREGISTREMENT pour la BDD
                var path = Path.Combine(Server.MapPath("~/content/images/"), fileName);

                file.SaveAs(path);

                result.Data = new { Success = true,  ImageURL = string.Format("/content/images/{0}", fileName) };

               
            }
            catch (Exception ex)
            {
                result.Data = new { success = false, Message = ex.Message };
            }

            return result;
        }
    }
}
