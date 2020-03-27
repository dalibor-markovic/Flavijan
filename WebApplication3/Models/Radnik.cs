using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace WebApplication3.Models
{
    public class Radnik
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public float NetoPlata { get; set; }
        public float BrutoPlata { get; set; }
        public static string ConnectionString { get; set; }     
    }
}