using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace crud
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "fuunciones" en el código, en svc y en el archivo de configuración a la vez.

    public class fuunciones : Ifuunciones
    {

        public void Create(string id, string nombre, string apellidos, string direccion, string numero)
        {
            SqlConnection con;
            SqlCommand cmd;
        string cadena = "";

           
       con = new SqlConnection(" Data Source=Victoria-PC;Initial Catalog=SITIO;Integrated Security=True");
       con.Open();
       cadena = string.Format("Insert into biblioteki values ('"+ id +"','"+ nombre +"','"+ apellidos +"','"+ direccion +"','"+ numero + "')");
        cmd = new SqlCommand(cadena, con);
        cmd.ExecuteNonQuery();
         con.Close();
   
            
        }
         
        public string[] Read(string id)
        {

            SqlDataReader most;
            SqlConnection con;
            SqlCommand cmd;
            string cadena = "";
            string[] arreglo = new string[5];
            List<DataTable> lista = new List<DataTable>(1);
            con = new SqlConnection("Data Source=Victoria-PC;Initial Catalog=SITIO;Integrated Security=True");
            con.Open();
            cadena = string.Format("Select id, nombre, apellidos, direccion, numero  from biblioteki where id='" + id + "'");
            cmd = new SqlCommand(cadena, con);
            most = cmd.ExecuteReader();
            if (most.Read())
            {
                arreglo[0] = most.GetInt32(0).ToString();
                arreglo[1] = most.GetString(1);
                arreglo[2] = most.GetString(2);
                arreglo[3] = most.GetString(3);
                arreglo[4] = most.GetInt32(4).ToString();
               
            }
            con.Close();
            return arreglo;
        }

        public bool update(string id, string nombre, string apellidos, string direccion, string numero)
         {
             StringBuilder res = new StringBuilder();
             SqlConnection con;
             SqlCommand cmd;
             string cadena = "";
             con = new SqlConnection("Data Source=Victoria-PC;Initial Catalog=SITIO;Integrated Security=True");
             con.Open();
             cadena = "UPDATE biblioteki SET id = ( '" + id + "'), nombre = ( '" + nombre + "'), apellidos = ( '" + apellidos + "'), direccion = ( '" + direccion + "'), numero = ( '" + numero + "') where id = ('" +id+   "') ";
             cmd = new SqlCommand(cadena, con);
             cmd.ExecuteNonQuery();
            if (    cmd.ExecuteNonQuery()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
             con.Close();
            
         }

        public bool delete(string id)
        {
            StringBuilder res = new StringBuilder();
            
            SqlConnection con;
            SqlCommand cmd;
            string cadena = "";
            con = new SqlConnection(" Data Source=Victoria-PC;Initial Catalog=SITIO;Integrated Security=True");
            con.Open();
            
         
            cadena = "delete from biblioteki where id = ('" + id + "')";
            cmd = new SqlCommand(cadena, con);
            cmd.ExecuteNonQuery();
          
            if(   cmd.ExecuteNonQuery()>0)
            {
                return true;
            }
            else
            {
                return false;
            }

            con.Close();
        }
    }
}
