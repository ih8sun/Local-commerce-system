using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

using System.Data;

using Entidad;

namespace AccesoDatos
{
    public sealed class adCompras
    {
        public static bool Grabar(Entidad.Compras pEntidad)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"select * from compra  where id_compra=@id_compra;", cn))
                {
                    cmd.Parameters.AddWithValue("id_compra", pEntidad.iddocumento);



                    cmd.Parameters.AddWithValue("hora", pEntidad.hora);

                    cmd.Parameters.AddWithValue("fecha", pEntidad.fecha);


        

                    cmd.Parameters.AddWithValue("id_proveedor", pEntidad.codigo_cliente);

                    cmd.Parameters.AddWithValue("id_usuario", pEntidad.id_usuario);



                    cmd.Parameters.AddWithValue("subtotal", pEntidad.subtotal);

                    cmd.Parameters.AddWithValue("igv", pEntidad.igv);
                    cmd.Parameters.AddWithValue("total", pEntidad.total);


                    cn.Open();
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        cmd.CommandText = @"update from compra;";
                    }
                    else
                        cmd.CommandText = @"insert into compra (id_compra,hora,fecha,id_proveedor,id_usuario,subtotal,igv,total) values (@id_compra,@hora,@fecha,@id_proveedor,@id_usuario,@subtotal,@igv,@total);";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        public DataTable Listar_usuario()
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from usuario", cn);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public DataTable Listar_documento()
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from tipo_documento", cn);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public DataTable Listar_forma()
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from forma_pago", cn);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }



        public DataTable Buscar_cliente(String Nombres)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {

                SqlCommand cmd = new SqlCommand("consultar_proveedor_compra", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@proveedor", "%" + Nombres);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public DataTable Listar_porcentaje()
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from porcentaje", cn);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }




        public DataTable Buscar_forma(String Nombres)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {

                SqlCommand cmd = new SqlCommand("consultar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@", "%" + Nombres);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        
         public string contador;

         public List<Compras> UltimoCod()
         {
             using (var cn = new SqlConnection(Conexion.LeerCC))
             {



                 SqlCommand sqlcmd = new SqlCommand("select count(id_Compra),max (id_Compra) from Compra", cn);
                 sqlcmd.CommandType = CommandType.Text;
                 cn.Open();
                 SqlDataReader PaTable = sqlcmd.ExecuteReader();




                 List<Compras> Coleccion = new List<Compras>();




                 while (PaTable.Read())
                 {
                     this.contador = Convert.ToString(PaTable.GetInt32(0));
                     if (contador == "0")
                     {



                         Coleccion.Add(new Compras(PaTable.GetInt32(0).ToString()));



                     }
                     else
                     {



                         Coleccion.Add(new Compras(PaTable.GetString(1)));


                     }
                 }
                 return Coleccion;


             }
         }
    }
}
