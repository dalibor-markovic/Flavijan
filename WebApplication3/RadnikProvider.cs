using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApplication3.Models;

namespace WebApplication3
{
    public class RadnikProvider
    {
        public Radnik UpisiNovogRadnika(Radnik radnik)
        {
            radnik.BrutoPlata = (float)(radnik.NetoPlata + (radnik.NetoPlata * 36.55 / 100));

                using (SqlConnection konekcija = new SqlConnection(Radnik.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO Zaposleni VALUES(@Ime, @Prezime, @Adresa, @Neto_plata, @Bruto_plata)", konekcija))
                    {
                        command.Parameters.AddWithValue("@Ime", radnik.Ime);
                        command.Parameters.AddWithValue("@Prezime", radnik.Prezime);
                        command.Parameters.AddWithValue("@Adresa", radnik.Adresa);
                        command.Parameters.AddWithValue("@Neto_plata", radnik.NetoPlata);
                        command.Parameters.AddWithValue("@Bruto_plata", radnik.BrutoPlata);

                        konekcija.Open();
                        command.ExecuteNonQuery();
                    }
                }

            return radnik;
        }

        public Radnik PromeniRadnika(Radnik radnik)
        {
            radnik.BrutoPlata = (float)(radnik.NetoPlata + (radnik.NetoPlata * 36.55 / 100));

                using (SqlConnection konekcija = new SqlConnection(Radnik.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("UPDATE Zaposleni " +
                        "SET Ime = '" + radnik.Ime + "', Prezime = '" + radnik.Prezime +
                        "', Adresa = '" + radnik.Adresa + "', Neto_plata = '" + radnik.NetoPlata +
                        "', Bruto_plata = '" + radnik.BrutoPlata + "' WHERE ID = " + radnik.ID, konekcija))
                    {
                        konekcija.Open();
                        command.ExecuteNonQuery();
                    }

                }

            return radnik;
        }

        public Radnik ObrisiRadnika(Radnik radnik)
        {
            using (SqlConnection konekcija = new SqlConnection(Radnik.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Zaposleni WHERE ID=" + radnik.ID, konekcija))
                {
                    konekcija.Open();
                    command.ExecuteNonQuery();
                }
            }

            return radnik;
        }

        public List<Radnik> IzveziTabelu()
        {
            List<Radnik> listaRadnika = new List<Radnik>();

            using (SqlConnection konekcija = new SqlConnection(Radnik.ConnectionString))
            {
                konekcija.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Zaposleni", konekcija))
                using (SqlDataReader citac = command.ExecuteReader())
                {
                    while (citac.Read())
                    {
                        var radnik = new Radnik();
                        radnik.ID = citac.GetInt32(0);
                        radnik.Ime = citac.GetString(1);
                        radnik.Prezime = citac.GetString(2);
                        radnik.Adresa = citac.GetString(3);
                        radnik.NetoPlata = citac.GetFloat(4);
                        radnik.BrutoPlata = citac.GetFloat(5);
                        listaRadnika.Add(radnik);
                    }
                }
            }

           return listaRadnika;
        }
    }
}