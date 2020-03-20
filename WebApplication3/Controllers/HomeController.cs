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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]        
        public ContentResult saveObj(Radnik radnik)
        {

            //            Radnik radnik = new Radnik();
            //            Radnik radnik = JsonConvert.DeserializeObject<Radnik>(ime);
            //           Radnik radnik = new Radnik();
            //            radnik = JsonConvert.DeserializeObject<Radnik>(json);
            //          string izlaz = JsonConvert.SerializeObject(radnik);

            return Content(JsonConvert.SerializeObject(radnik));

            /*
                        string connectionString = "Server=DESKTOP-4CRF79E;Database=Gemini;Trusted_Connection=True;ConnectRetryCount=3;";

                        //
                        // In a using statement, acquire the SqlConnection as a resource.
                        //
                        List<myobjFilter> lstZaposleni = new List<myobjFilter>();


                                   using (SqlConnection con = new SqlConnection(connectionString))
                                   {
                                       //
                                       // Open the SqlConnection.
                                       //
                                       con.Open();
                                       //
                                       // This code uses an SqlCommand based on the SqlConnection.
                                       //
                                       using (SqlCommand command = new SqlCommand("SELECT TOP 2 * FROM Zaposleni", con))
                                       using (SqlDataReader reader = command.ExecuteReader())
                                       {
                                           while (reader.Read())
                                           {
                                               Console.WriteLine("{0} {1} {2}",
                                                   reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

                                           }
                                       }
                                   }

                                   var myobj = new myobjFilter();
                        lstZaposleni.Add(myobj);

                                   return Content(JsonConvert.SerializeObject(lstZaposleni));

            */
        }



    }
}