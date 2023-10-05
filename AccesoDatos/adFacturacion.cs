using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;

using System.Data.SqlClient;

using System.Data;
using Entidad;

namespace AccesoDatos
{
    public sealed class adFacturacion
    {
       


        public static bool Grabar(Entidad.Facturacion pEntidad)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"select * from documento where id_documento=@id_documento;", cn))//@"select * from cliente where id_cliente=@id_cliente;"
                {
                    cmd.Parameters.AddWithValue("id_documento", pEntidad.iddocumento);
                    cmd.Parameters.AddWithValue("serie", pEntidad.serie);
                    cmd.Parameters.AddWithValue("fecha", pEntidad.fecha);

                    cmd.Parameters.AddWithValue("hora", pEntidad.hora);

                    cmd.Parameters.AddWithValue("id_tipo", pEntidad.id_tipo_documento);

                    cmd.Parameters.AddWithValue("codigo_cliente", pEntidad.codigo_cliente);
                    cmd.Parameters.AddWithValue("id_usuario", pEntidad.id_usuario);

                    cmd.Parameters.AddWithValue("id_forma", pEntidad.id_forma);

                    cmd.Parameters.AddWithValue("observacion", pEntidad.observacion);


                    cmd.Parameters.AddWithValue("subtotal", pEntidad.subtotal);

                    cmd.Parameters.AddWithValue("igv", pEntidad.igv);
                    cmd.Parameters.AddWithValue("total", pEntidad.total);


                    cn.Open();
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        cmd.CommandText = @"update  documento set id_documento=@id_documento,serie=@serie,fecha=@fecha,hora=@hora,id_tipo=@id_tipo,codigo_cliente=@codigo_cliente,id_usuario=@id_usuario,id_forma=@id_forma,observacion=@observacion,id_forma=@id_forma,subtotal=@subtotal,igv=@igv,total=@total  where id_documento=@id_documento;";
                    }
                    else
                        cmd.CommandText = @"insert into documento (id_documento,serie,fecha,hora,id_tipo,codigo_cliente,id_usuario,id_forma,observacion,subtotal,igv,total) values (@id_documento,@serie,@fecha,@hora,@id_tipo,@codigo_cliente,@id_usuario,@id_forma,@observacion,@subtotal,@igv,@total);";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }





        public static bool Actualizar(Entidad.Facturacion pEntidad)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"select * from documento where id_documento=@id_documento;", cn))
                {
                    cmd.Parameters.AddWithValue("id_documento", pEntidad.iddocumento);
                   
                    cmd.Parameters.AddWithValue("id_forma", pEntidad.id_forma);

                    cmd.Parameters.AddWithValue("observacion", pEntidad.observacion);



                    cn.Open();
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        cmd.CommandText = @"update  documento set id_forma=@id_forma,observacion=@observacion where id_documento=@id_documento;";
                    }
                  
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }


        public static bool Cancelar_Facturacion(Entidad.Facturacion pEntidad)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"select * from documento where id_documento=@id_documento;", cn))
                {
                    cmd.Parameters.AddWithValue("id_documento", pEntidad.iddocumento);
                    cn.Open();
                    cmd.CommandText = "delete from documento where id_documento=@id_documento;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        public static bool Cancelar_Detalle_Facturacion(Entidad.Facturacion pEntidad)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"select * from Detalle_documento where id_documento=@id_documento;", cn))
                {
                    cmd.Parameters.AddWithValue("id_documento", pEntidad.iddocumento);
                    cn.Open();
                    cmd.CommandText = "delete from Detalle_documento  where id_documento=@id_documento;";
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


         public DataTable Buscar_cliente(String Nombres)
         {
             using (var cn = new SqlConnection(Conexion.LeerCC))
             {

                 SqlCommand cmd = new SqlCommand("consultar_cliente_facturado", cn);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@cliente", "%" + Nombres);
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
         }

         public DataTable Buscar_forma(String Nombres)
         {
             using (var cn = new SqlConnection(Conexion.LeerCC))
             {

                 SqlCommand cmd = new SqlCommand("consultar_forma_pago_facturado", cn);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@forma", "%" + Nombres);
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 return dt;
             }
         }




         public string contador;

         public List<Facturacion> UltimoCod()
         {
             using (var cn = new SqlConnection(Conexion.LeerCC))
             {



                 SqlCommand sqlcmd = new SqlCommand("select count(id_documento),max (id_documento) from DOCUMENTO", cn);
                 sqlcmd.CommandType = CommandType.Text;
                 cn.Open();
                 SqlDataReader PaTable = sqlcmd.ExecuteReader();

                


                 List<Facturacion> Coleccion = new List<Facturacion>();

                
         

                 while (PaTable.Read())
                 {
                     this.contador = Convert.ToString(PaTable.GetInt32(0));
                     if (contador == "0")
                     {



                       Coleccion.Add(new Facturacion(PaTable.GetInt32(0).ToString()));



                     }
                     else
                     {



                         Coleccion.Add(new Facturacion(PaTable.GetString(1)));

                     
                     }
                 }
                 return Coleccion;

           
             }

         

    }



    }
}
