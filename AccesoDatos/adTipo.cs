using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

using System.Data;


namespace AccesoDatos
{
    public sealed class adTipo
    {
        public static bool Grabar(Entidad.Tipo pEntidad, bool esNuevaInsercion)
        {

            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                cn.Open();
                
                if (esNuevaInsercion)
                {
                    using (var cmdExistencia = new SqlCommand(@"select count(*) from Tipo_Documento where tipo=@tipo", cn))
                    {
                        cmdExistencia.Parameters.AddWithValue("tipo", pEntidad.nombres);
                        if(Convert.ToInt32(cmdExistencia.ExecuteScalar()) > 0)
                        {
                            throw new ApplicationException("Ya existe un registro con el mismo tipo");
                        }
                    }
                }

                using (var cmd = new SqlCommand(@"select * from Tipo_Documento where id_tipo=@id_tipo;", cn))
                {
                    cmd.Parameters.AddWithValue("id_tipo", pEntidad.idcodigo);

                    cmd.Parameters.AddWithValue("tipo", pEntidad.nombres);

                    cmd.Parameters.AddWithValue("estado", pEntidad.estado);


                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        cmd.CommandText = @"update Tipo_Documento set tipo=@tipo, estado=@estado where id_tipo=@id_tipo;";
                    }
                    else
                        cmd.CommandText = @"insert Tipo_Documento (tipo,estado) values (@tipo, 'Activo');";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        public static bool Cambiar(Entidad.Tipo pEntidad)
        {
            string nuevoEstado = "Activo";
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"update Tipo_Documento set estado = case when estado = 'Activo' then 'Inactivo' else 'Activo' end where id_tipo=@id_tipo", cn))
                {
                    cmd.Parameters.AddWithValue("id_tipo", pEntidad.idcodigo);

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = @"select estado from Tipo_Documento where id_tipo=@id_tipo;";
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

                SqlCommand cmd = new SqlCommand("buscar_Tipo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", "%" + Nombres);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public static bool Eliminar(Entidad.Tipo pEntidad)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"select * from Tipo_Documento  where id__Tipo=@id_Tipo;", cn))
                {
                    cmd.Parameters.AddWithValue("id_Tipo", pEntidad.idcodigo);
                    cn.Open();
                    cmd.CommandText = "delete from Tipo_Documento  where id_Tipo=@id_Tipo;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }



        }
    }
}
