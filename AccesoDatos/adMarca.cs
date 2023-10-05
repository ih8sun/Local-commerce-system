using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

using System.Data;


namespace AccesoDatos
{
    public sealed class adMarca
    {
        public static bool Grabar(Entidad.Marca pEntidad, bool esNuevaInsercion)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                cn.Open();
                
                if (esNuevaInsercion)
                {
                    using (var cmdExistencia = new SqlCommand(@"select count(*) from Marca where Marca = @Marca;", cn))
                    {
                        cmdExistencia.Parameters.AddWithValue("Marca", pEntidad.nombres);

                        if (Convert.ToInt32(cmdExistencia.ExecuteScalar()) > 0)
                        {
                            // Ya existe un registro con la misma cédula, no se permite la inserción
                            throw new ApplicationException("Ya existe un registro con la misma marca");
                        }
                    }
                }

                using (var cmd = new SqlCommand(@"select * from Marca where id_Marca=@id_Marca;", cn))
                {
                    cmd.Parameters.AddWithValue("id_Marca", pEntidad.idcodigo);

                    cmd.Parameters.AddWithValue("Marca", pEntidad.nombres);

                    cmd.Parameters.AddWithValue("estado", pEntidad.estado);


                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        cmd.CommandText = @"update Marca set Marca=@Marca, estado=@estado where id_Marca=@id_Marca;";
                    }
                    else
                        cmd.CommandText = @"insert into Marca(Marca,estado) values (@Marca,'Activo');";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        public static bool Cambiar(Entidad.Marca pEntidad)
        {
            string nuevoEstado = "Activo";
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"update Marca set estado = case when estado = 'Activo' then 'Inactivo' else 'Activo' end where id_Marca=@id_Marca", cn))
                {
                    cmd.Parameters.AddWithValue("id_Marca", pEntidad.idcodigo);

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = @"select estado from Marca where id_Marca=@id_Marca;";
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

                SqlCommand cmd = new SqlCommand("buscar_marca", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@marca", "%" + Nombres);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public static bool Eliminar(Entidad.Marca pEntidad)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"select * from Marca where id_Marca=@id_Marca;", cn))
                {
                    cmd.Parameters.AddWithValue("id_Marca", pEntidad.idcodigo);
                    cn.Open();
                    cmd.CommandText = "delete from Marca where id_Marca=@id_Marca;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }



        }
    }
}
