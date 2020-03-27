using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using System.Data.SqlClient;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult TabelaGotova()
        {
            return View();
        }
        public ActionResult Greska()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Opis sajta";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakt stranica";

            return View();
        }

        public ActionResult Tabela()
        {
            ViewBag.Message = "Tabela zaposlenih";

            return View();
        }

        [HttpPost]        
        public ContentResult Upisi(Radnik radnik)
        {
            Radnik.ConnectionString = "Server=DESKTOP-4CRF79E;Database=Gemini;Trusted_Connection=True;ConnectRetryCount=3;";
            var radnikProvider = new RadnikProvider();

            return Content(JsonConvert.SerializeObject(radnikProvider.UpisiNovogRadnika(radnik)));

        }

        [HttpPost]
        public ContentResult Vrati()
        {
            Radnik.ConnectionString = "Server=DESKTOP-4CRF79E;Database=Gemini;Trusted_Connection=True;ConnectRetryCount=3;";

            var radnikProvider = new RadnikProvider();

            return Content(JsonConvert.SerializeObject(radnikProvider.IzveziTabelu()));
        }

        [HttpPost]
        public ContentResult Obrisi(Radnik radnik)
        {
            Radnik.ConnectionString = "Server=DESKTOP-4CRF79E;Database=Gemini;Trusted_Connection=True;ConnectRetryCount=3;";
            var radnikProvider = new RadnikProvider();
            radnikProvider.ObrisiRadnika(radnik);

            return Content(JsonConvert.SerializeObject(radnik));
        }

        [HttpPost]
        public ContentResult Izmeni(Radnik radnik)
        {
            Radnik.ConnectionString = "Server=DESKTOP-4CRF79E;Database=Gemini;Trusted_Connection=True;ConnectRetryCount=3;";
            var radnikProvider = new RadnikProvider();
            radnikProvider.PromeniRadnika(radnik);

            return Content(JsonConvert.SerializeObject(radnik));
        }


    }
}