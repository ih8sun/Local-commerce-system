using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

using System.Data;


namespace AccesoDatos
{
    public sealed class adCategoria
    {
        public static bool Grabar(Entidad.Categoria pEntidad, bool esNuevaInsercion)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                cn.Open();

                if (esNuevaInsercion)
                {
                    using (var cmdExistencia = new SqlCommand(@"select count(*) from Categoria where Categoria=@Categoria;", cn))
                    {
                        cmdExistencia.Parameters.AddWithValue("Categoria", pEntidad.nombres);

                        if(Convert.ToInt32(cmdExistencia.ExecuteScalar()) > 0)
                        {
                            throw new ApplicationException("Ya existe un registro con la misma categoria");
                        }
                    }
                }

                using (var cmd = new SqlCommand(@"select * from Categoria where id_Categoria=@id_Categoria;", cn))
                {
                    cmd.Parameters.AddWithValue("id_Categoria", pEntidad.idcodigo);
                   
                    cmd.Parameters.AddWithValue("Categoria", pEntidad.nombres);

                    cmd.Parameters.AddWithValue("estado", pEntidad.estado);


                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        cmd.CommandText = @"update Categoria set Categoria=@Categoria, estado=@estado where id_Categoria=@id_Categoria;"; 
                    }
                    else
                        cmd.CommandText = @"insert into Categoria (Categoria,estado) values (@Categoria, 'Activo');";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        public static bool Cambiar(Entidad.Categoria pEntidad)
        {
            string nuevoEstado = "Activo";
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"update Categoria set estado = case when estado = 'Activo' then 'Inactivo' else 'Activo' end where id_Categoria=@id_Categoria", cn))
                {
                    cmd.Parameters.AddWithValue("id_Categoria", pEntidad.idcodigo);

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = @"select estado from Categoria where id_Categoria=@id_Categoria;";
                        nuevoEstado = (string)cmd.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {

                    }

                }
            }
            return Convert.ToBoolean(nuevoEstado);
        }

        public DataTable Buscar(String Nombres)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {

                SqlCommand cmd = new SqlCommand("buscar_categoria", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@categoria", "%" + Nombres);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public static bool Eliminar(Entidad.Categoria pEntidad)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"select * from Categoria where id_Categoria=@id_Categoria;", cn))
                {
                    cmd.Parameters.AddWithValue("id_Categoria", pEntidad.idcodigo);
                    cn.Open();
                    cmd.CommandText = "delete from Categoria where id_Categoria=@id_Categoria;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        

     
        }
    }
}
