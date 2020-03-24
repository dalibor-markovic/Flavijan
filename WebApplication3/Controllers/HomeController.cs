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
            Radnik.connectionString = "Server=DESKTOP-4CRF79E;Database=Gemini;Trusted_Connection=True;ConnectRetryCount=3;";

            return Content(JsonConvert.SerializeObject(Radnik.UpisiNovogRadnika(radnik)));

        }

        [HttpPost]
        public ContentResult Vrati(Radnik radnik)
        {
            Radnik.connectionString = "Server=DESKTOP-4CRF79E;Database=Gemini;Trusted_Connection=True;ConnectRetryCount=3;";

            return Content(JsonConvert.SerializeObject(Radnik.IzveziTabelu()));
        }

        [HttpPost]
        public ContentResult Obrisi(Radnik radnik)
        {
            Radnik.connectionString = "Server=DESKTOP-4CRF79E;Database=Gemini;Trusted_Connection=True;ConnectRetryCount=3;";

            Radnik.ObrisiRadnika(radnik.ID);

            return Content(JsonConvert.SerializeObject(radnik));
        }

        [HttpPost]
        public ContentResult Izmeni(Radnik radnik)
        {
            Radnik.connectionString = "Server=DESKTOP-4CRF79E;Database=Gemini;Trusted_Connection=True;ConnectRetryCount=3;";

            Radnik.PromeniRadnika(radnik);

            return Content(JsonConvert.SerializeObject(radnik));
        }


    }
}