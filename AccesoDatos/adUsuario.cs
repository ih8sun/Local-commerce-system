using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

using System.Data;


namespace AccesoDatos
{
    public sealed class adUsuario
    {
        public static bool Grabar(Entidad.Usuario pEntidad, bool esNuevaInsercion)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                cn.Open();

                if (esNuevaInsercion)
                {
                    using (var cmdExistencia = new SqlCommand(@"SELECT COUNT(*) FROM Usuario WHERE nombrecompleto = @nombrecompleto or usuario = @usuario", cn))
                    {
                        cmdExistencia.Parameters.AddWithValue("nombrecompleto", pEntidad.nombrecompleto);
                        cmdExistencia.Parameters.AddWithValue("usuario", pEntidad.nombres);
                        if (Convert.ToInt32(cmdExistencia.ExecuteScalar()) > 0)
                        {
                            // Ya existe un registro con la misma cédula, no se permite la inserción
                            throw new ApplicationException("Ya existe un registro con el mismo nombre o usuario");
                        }
                    }
                }

                using (var cmd = new SqlCommand(@"select * from Usuario where id_Usuario=@id_Usuario;", cn))
                {
                    cmd.Parameters.AddWithValue("id_Usuario", pEntidad.idcodigo);

                    cmd.Parameters.AddWithValue("nombrecompleto", pEntidad.nombrecompleto);

                    cmd.Parameters.AddWithValue("usuario", pEntidad.nombres);

                    cmd.Parameters.AddWithValue("contraseña", pEntidad.contraseña);

                    cmd.Parameters.AddWithValue("id_cargo", pEntidad.cargo);

                    cmd.Parameters.AddWithValue("estado", pEntidad.estado);


                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        cmd.CommandText = @"update Usuario set nombrecompleto=@nombrecompleto,usuario=@usuario,contraseña=@contraseña,id_cargo=@id_cargo,estado=@estado where id_Usuario=@id_Usuario;";
                    }
                    else
                        cmd.CommandText = @"insert into Usuario (nombrecompleto,Usuario,contraseña,id_cargo,estado) values (@nombrecompleto,@Usuario,@contraseña,@id_cargo,'Activo');";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        public static bool Cambiar(Entidad.Usuario pEntidad)
        {
            string nuevoEstado = "Activo";
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"update Usuario set estado = case when estado = 'Activo' then 'Inactivo' else 'Activo' end where id_Usuario=@id_Usuario", cn))
                {
                    cmd.Parameters.AddWithValue("id_Usuario", pEntidad.idcodigo);

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = @"select estado from Usuario where id_Usuario=@id_Usuario;";
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

                SqlCommand cmd = new SqlCommand("buscar_Usuarios", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", "%" + Nombres);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public static bool Eliminar(Entidad.Usuario pEntidad)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"select * from Usuario where id_Usuario=@id_Usuario;", cn))
                {
                    cmd.Parameters.AddWithValue("id_Usuario", pEntidad.idcodigo);
                    cn.Open();
                    cmd.CommandText = "delete from Usuario where id_Usuario=@id_Usuario;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }



             public DataTable Listar_cargo()
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from cargo where estado ='Activo'", cn);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        
    }
}
