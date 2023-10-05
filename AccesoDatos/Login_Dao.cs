using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.SqlClient;
using System.Data;
using Entidad;

namespace AccesoDatos
{
    public class Login_Dao
    {



        public DataTable D_Login(Entidad.Login_Entidad obje)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                SqlCommand cmd = new SqlCommand("sp_login", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", obje.usuario);
                cmd.Parameters.AddWithValue("@contraseña", obje.contraseña);
                cmd.Parameters.AddWithValue("@cargo", obje.cargo);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dtable1 = new DataTable();
                da.Fill(dtable1);
                return dtable1;
            }
        }

      
    }
}
