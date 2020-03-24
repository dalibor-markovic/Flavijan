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
        public string ime { get; set; }
        public string prezime { get; set; }
        public string adresa { get; set; }
        public float netoPlata { get; set; }

        public float brutoPlata { get; set; }

        public static string connectionString { get; set; }
        
        public static Radnik UpisiNovogRadnika(Radnik radnik)
        {
            radnik.brutoPlata = (float)(radnik.netoPlata + (radnik.netoPlata * 36.55 / 100));

                using (SqlConnection konekcija = new SqlConnection(Radnik.connectionString))
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO Zaposleni VALUES(@Ime, @Prezime, @Adresa, @Neto_plata, @Bruto_plata)", konekcija))
                    {
                        command.Parameters.AddWithValue("@Ime", radnik.ime);
                        command.Parameters.AddWithValue("@Prezime", radnik.prezime);
                        command.Parameters.AddWithValue("@Adresa", radnik.adresa);
                        command.Parameters.AddWithValue("@Neto_plata", radnik.netoPlata);
                        command.Parameters.AddWithValue("@Bruto_plata", radnik.brutoPlata);

                        konekcija.Open();
                        command.ExecuteNonQuery();
                    }
                }

            return radnik;
        }

        public static Boolean PromeniRadnika(Radnik radnik) {

            radnik.brutoPlata = (float)(radnik.netoPlata + (radnik.netoPlata * 36.55 / 100));

            using (SqlConnection konekcija = new SqlConnection(Radnik.connectionString))
            {
                using (SqlCommand command = new SqlCommand("UPDATE Zaposleni "+
                    "SET Ime = '"+radnik.ime+"', Prezime = '"+radnik.prezime+
                    "', Adresa = '"+radnik.adresa+"', Neto_plata = '"+radnik.netoPlata+
                    "', Bruto_plata = '"+radnik.brutoPlata+"' WHERE ID = "+radnik.ID, konekcija))
                {
                    konekcija.Open();
                    command.ExecuteNonQuery();
                }

            }

            return true;
        }

        public static Boolean ObrisiRadnika(int id) {
            using (SqlConnection konekcija = new SqlConnection(Radnik.connectionString))
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Zaposleni WHERE ID="+id, konekcija))
                {
                    konekcija.Open();
                    command.ExecuteNonQuery();
                }
            }

            return true;
        }

        public static List<Radnik> IzveziTabelu() {
            List<Radnik> listaRadnika = new List<Radnik>();
            using (SqlConnection konekcija = new SqlConnection(Radnik.connectionString)) {
                konekcija.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Zaposleni", konekcija))
                using (SqlDataReader citac = command.ExecuteReader())
                {
                    while (citac.Read())
                    {
                        Radnik radnik = new Radnik();
                        radnik.ID = citac.GetInt32(0);
                        radnik.ime = citac.GetString(1);
                        radnik.prezime = citac.GetString(2);
                        radnik.adresa = citac.GetString(3);
                        radnik.netoPlata = citac.GetFloat(4); 
                        radnik.brutoPlata = citac.GetFloat(5);
                        listaRadnika.Add(radnik);
                    }
                }
            }

            return listaRadnika;
        }
    }
}