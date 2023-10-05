using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

using System.Data;


namespace AccesoDatos
{
    public sealed class adProveedor
    {
        public static bool Grabar(Entidad.Proveedor pEntidad, bool esNuevaInsercion)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                cn.Open();

                if (esNuevaInsercion)
                {
                    using (var cmdExistencia = new SqlCommand(@"SELECT COUNT(*) FROM proveedor WHERE razon_social = @razon_social or telefono = @telefono or celular=@celular or email = @email or ruc = @ruc", cn))
                    {
                        cmdExistencia.Parameters.AddWithValue("razon_social", pEntidad.razon);
                        cmdExistencia.Parameters.AddWithValue("telefono", pEntidad.telefono);
                        cmdExistencia.Parameters.AddWithValue("celular", pEntidad.celular);
                        cmdExistencia.Parameters.AddWithValue("ruc", pEntidad.ruc);
                        cmdExistencia.Parameters.AddWithValue("email", pEntidad.email);
                        if (Convert.ToInt32(cmdExistencia.ExecuteScalar()) > 0)
                        {
                            // Ya existe un registro con la misma cédula, no se permite la inserción
                            throw new ApplicationException("Ya existe un registro con la misma razon social y/o teléfono y/o celular y/o RUC y/o email");
                        }
                    }
                }
                using (var cmd = new SqlCommand(@"select * from Proveedor where id_Proveedor=@id_Proveedor;", cn))//@"select * from cliente where id_cliente=@id_cliente;"
                {
                    cmd.Parameters.AddWithValue("id_proveedor", pEntidad.idproveedor);
                    cmd.Parameters.AddWithValue("proveedor", pEntidad.nombres);
                    cmd.Parameters.AddWithValue("razon_social", pEntidad.razon);

                    cmd.Parameters.AddWithValue("telefono", pEntidad.telefono);
                    cmd.Parameters.AddWithValue("celular", pEntidad.celular);
                    cmd.Parameters.AddWithValue("direccion", pEntidad.direccion);
                    cmd.Parameters.AddWithValue("ruc", pEntidad.ruc);
                    cmd.Parameters.AddWithValue("email", pEntidad.email);
                    cmd.Parameters.AddWithValue("estado", pEntidad.estado);

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        cmd.CommandText = @"update proveedor set proveedor=@proveedor,razon_social=@razon_social,telefono=@telefono,celular=@celular,direccion=@direccion,ruc=@ruc,email=@email,estado=@estado where id_proveedor=@id_proveedor;"; 
                    }
                    else
                        cmd.CommandText = @"insert into proveedor (Proveedor,Razon_Social,Telefono,Celular,Direccion,Ruc,Email,Estado) values (@Proveedor,@Razon_Social,@Telefono,@Celular,@Direccion,@Ruc,@Email,'Activo');";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        public static bool Cambiar(Entidad.Proveedor pEntidad)
        {
            string nuevoEstado = "Activo";
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"update proveedor set estado = case when estado = 'Activo' then 'Inactivo' else 'Activo' end where id_proveedor=@id_proveedor", cn))//@"select * from cliente where id_cliente=@id_cliente;"
                {
                    cmd.Parameters.AddWithValue("id_proveedor", pEntidad.idproveedor);

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = @"select estado from proveedor where id_proveedor=@id_proveedor;";
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

                SqlCommand cmd = new SqlCommand("buscar_proveedor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@proveedor", "%" + Nombres);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public static bool Eliminar(Entidad.Proveedor pEntidad)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"select * from proveedor where id_proveedor=@id_proveedor;", cn))
                {
                    cmd.Parameters.AddWithValue("id_proveedor", pEntidad.idproveedor);
                    cn.Open();
                    cmd.CommandText = "delete from proveedor where id_proveedor=@id_proveedor;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            
        }

      
        }
    }
}
