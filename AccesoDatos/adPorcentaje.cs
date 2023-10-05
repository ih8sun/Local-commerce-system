using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

using System.Data;


namespace AccesoDatos
{
    public sealed class adPorcentaje
    {
        public static bool Grabar(Entidad.Porcentaje pEntidad)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"select * from Porcentaje  where id_Porcentaje=@id_Porcentaje;", cn))
                {
                    cmd.Parameters.AddWithValue("id_Porcentaje", pEntidad.idcodigo);

                    cmd.Parameters.AddWithValue("descripcion", pEntidad.nombres);


                    cn.Open();
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        cmd.CommandText = @"update Porcentaje set descripcion=@descripcion where id_Porcentaje=@id_Porcentaje;";
                    }
                    else
                        cmd.CommandText = @"insert into Porcentaje(descripcion) values (@descripcion);";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }



        public DataTable Buscar(String Nombres)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {

                SqlCommand cmd = new SqlCommand("buscar_Porcentaje", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@porcentaje", "%" + Nombres);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public static bool Eliminar(Entidad.Porcentaje pEntidad)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"select * from Porcentaje where id_Porcentaje=@id_Porcentaje;", cn))
                {
                    cmd.Parameters.AddWithValue("id_Porcentaje", pEntidad.idcodigo);
                    cn.Open();
                    cmd.CommandText = "delete from Porcentaje where id_Porcentaje=@id_Porcentaje;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }



        }
    }
}
