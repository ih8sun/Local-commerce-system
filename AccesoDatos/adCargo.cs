using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

using System.Data;


namespace AccesoDatos
{
    public sealed class adCargo
    {
        public static bool Grabar(Entidad.Cargo pEntidad, bool esNuevaInsercion)
        {

            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                cn.Open();

                if (esNuevaInsercion)
                {
                    using (var cmdExistencia = new SqlCommand(@"SELECT COUNT(*) FROM Cargo WHERE Cargo = @Cargo", cn))
                    {
                        cmdExistencia.Parameters.AddWithValue("Cargo", pEntidad.nombres);

                        if (Convert.ToInt32(cmdExistencia.ExecuteScalar()) > 0)
                        {
                            // Ya existe un registro con la misma cédula, no se permite la inserción
                            throw new ApplicationException("Ya existe un registro con el mismo cargos");
                        }
                    }
                }


                using (var cmd = new SqlCommand(@"select * from Cargo where id_Cargo=@id_Cargo;", cn))
                {
                    cmd.Parameters.AddWithValue("id_Cargo", pEntidad.idcodigo);

                    cmd.Parameters.AddWithValue("Cargo", pEntidad.nombres);
                    cmd.Parameters.AddWithValue("estado", pEntidad.estado);


                   
                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        cmd.CommandText = @"update Cargo set Cargo=@Cargo, estado=@estado where id_Cargo=@id_Cargo;";
                    }
                    else
                        cmd.CommandText = @"insert into Cargo(Cargo,estado) values (@Cargo,'Activo');";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

            public static bool Cambiar(Entidad.Cargo pEntidad)
        {
            string nuevoEstado = "Activo";
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"update Cargo set estado = case when estado = 'Activo' then 'Inactivo' else 'Activo' end where id_Cargo=@id_Cargo", cn))
                {
                    cmd.Parameters.AddWithValue("id_Cargo", pEntidad.idcodigo);

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = @"select estado from Cargo where id_Cargo=@id_Cargo;";
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

                SqlCommand cmd = new SqlCommand("buscar_cargo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cargo", "%" + Nombres);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public static bool Eliminar(Entidad.Cargo pEntidad)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"select * from Cargo where id_Cargo=@id_Cargo;", cn))
                {
                    cmd.Parameters.AddWithValue("id_Cargo", pEntidad.idcodigo);
                    cn.Open();
                    cmd.CommandText = "delete from Cargo where id_Cargo=@id_Cargo;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        

     
        }
    }
}
