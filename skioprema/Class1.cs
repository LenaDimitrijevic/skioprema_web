using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace skioprema

{
    public class Class1
    {
        SqlConnection veza = new SqlConnection(ConfigurationManager.ConnectionStrings["home"].ConnectionString);
        SqlCommand komanda = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet set = new DataSet();
        DataSet pretraga = new DataSet();

        public DataSet Brendovi()
        {
            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "Brendovi";
            komanda.Parameters.Clear();
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            adapter.SelectCommand = komanda;
            adapter.Fill(set);
            return set;
        }

        public int Login(string email, string lozinka)
        {
            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "login_musterija";
            komanda.Parameters.Clear();
            komanda.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            komanda.Parameters.Add(new SqlParameter("@lozinka", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, lozinka));
            komanda.Parameters.Add(new SqlParameter("@return", SqlDbType.Int, 5, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            return (int)komanda.Parameters["@return"].Value;
        }

        public int Insert(string email, string lozinka)
        {
            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "insert_musterija";
            komanda.Parameters.Clear();
            komanda.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            komanda.Parameters.Add(new SqlParameter("@lozinka", SqlDbType.VarChar, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, lozinka));
            komanda.Parameters.Add(new SqlParameter("@return", SqlDbType.Int, 5, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            return (int)komanda.Parameters["@return"].Value;
        }

        public DataSet Iznajmljeno(DateTime datum)
        {
            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "iznajmljeno";
            komanda.Parameters.Clear();
            komanda.Parameters.Add(new SqlParameter("@datum", SqlDbType.Date, 30, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, datum));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            adapter.SelectCommand = komanda;
            adapter.Fill(set);
            return set;
        }

        public DataSet pretraga_skija(string trm)
        {
            trm = "%" + trm + "%";
            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "pretraga_skija";
            komanda.Parameters.Clear();
            komanda.Parameters.Add(new SqlParameter("@trm", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, trm));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            adapter.SelectCommand = komanda;
            adapter.Fill(pretraga);
            return pretraga;
        }

        public DataSet pretraga_stapova(string trm)
        {
            trm = "%" + trm + "%";
            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "pretraga_stapova";
            komanda.Parameters.Clear();
            komanda.Parameters.Add(new SqlParameter("@trm", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, trm));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            adapter.SelectCommand = komanda;
            adapter.Fill(pretraga);
            return pretraga;
        }

        public DataSet pretraga_pancerica(string trm)
        {
            trm = "%" + trm + "%";
            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "pretraga_pancerica";
            komanda.Parameters.Clear();
            komanda.Parameters.Add(new SqlParameter("@trm", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, trm));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            adapter.SelectCommand = komanda;
            adapter.Fill(pretraga);
            return pretraga;
        }

        public DataSet pretraga_kaciga(string trm)
        {
            trm = "%" + trm + "%";
            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "pretraga_kaciga";
            komanda.Parameters.Clear();
            komanda.Parameters.Add(new SqlParameter("@trm", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, trm));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            adapter.SelectCommand = komanda;
            adapter.Fill(pretraga);
            return pretraga;
        }

        public int iznajmljivanje(int musterija, int skije, int stapovi, int pancerice, int kacige, DateTime datum)
        {
            komanda.Connection = veza;
            komanda.CommandType = CommandType.StoredProcedure;
            komanda.CommandText = "upis_iznajmljivanja";
            komanda.Parameters.Clear();
            komanda.Parameters.Add(new SqlParameter("@musterija", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, musterija));
            komanda.Parameters.Add(new SqlParameter("@skije", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, skije));
            komanda.Parameters.Add(new SqlParameter("@stapovi", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, stapovi));
            komanda.Parameters.Add(new SqlParameter("@pancerice", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, pancerice));
            komanda.Parameters.Add(new SqlParameter("@kaciga", SqlDbType.Int, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, kacige));
            komanda.Parameters.Add(new SqlParameter("@datum", SqlDbType.Date, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, datum));
            komanda.Parameters.Add(new SqlParameter("@return", SqlDbType.Int, 5, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            return (int)komanda.Parameters["@return"].Value;
        }
    }
}