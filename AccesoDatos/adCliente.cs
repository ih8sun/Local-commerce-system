using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.SqlClient;

using System.Data;


namespace AccesoDatos
{
    public sealed class adCliente
    {
        public static bool Grabar(Entidad.Cliente pEntidad, bool esNuevaInsercion)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                cn.Open();

                if (esNuevaInsercion)
                {
                    using (var cmdExistencia = new SqlCommand(@"SELECT COUNT(*) FROM cliente WHERE cedula = @cedula or razon_social = @razon_social or telefono = @telefono or email = @email or ruc = @ruc", cn))
                    {
                        cmdExistencia.Parameters.AddWithValue("cedula", pEntidad.cedula);
                        cmdExistencia.Parameters.AddWithValue("razon_social", pEntidad.razon);
                        cmdExistencia.Parameters.AddWithValue("telefono", pEntidad.telefono);
                        cmdExistencia.Parameters.AddWithValue("email", pEntidad.email);
                        cmdExistencia.Parameters.AddWithValue("ruc", pEntidad.ruc);

                        if (Convert.ToInt32(cmdExistencia.ExecuteScalar()) > 0)
                        {
                            // Ya existe un registro con la misma cédula, no se permite la inserción
                            throw new ApplicationException("Ya existe un registro con la misma cédula y/o razon social y/o teléfono y/o RUC");
                        }
                    }
                }

                using (var cmd = new SqlCommand(@"select * from cliente where codigo_cliente=@codigo_cliente;", cn))//@"select * from cliente where id_cliente=@id_cliente;"
                {
                    cmd.Parameters.AddWithValue("codigo_cliente", pEntidad.idcliente);
                    cmd.Parameters.AddWithValue("cedula", pEntidad.cedula);
                    cmd.Parameters.AddWithValue("cliente", pEntidad.nombres);
                    cmd.Parameters.AddWithValue("razon_social", pEntidad.razon);

                    cmd.Parameters.AddWithValue("direccion", pEntidad.direccion);
                    cmd.Parameters.AddWithValue("telefono", pEntidad.telefono);
                    cmd.Parameters.AddWithValue("email", pEntidad.email);
                    cmd.Parameters.AddWithValue("ruc", pEntidad.ruc);
                    cmd.Parameters.AddWithValue("estado", pEntidad.estado);

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        cmd.CommandText = @"update cliente set cedula=@cedula,cliente=@cliente,razon_social=@razon_social,direccion=@direccion,telefono=@telefono,email=@email,ruc=@ruc,estado=@estado where codigo_cliente=@codigo_cliente;";
                    }
                    else
                        cmd.CommandText = @"insert into cliente (cedula,cliente,razon_social,direccion,telefono,email,ruc,estado) values (@cedula,@cliente,@razon_social,@direccion,@telefono,@email,@ruc,'Activo');";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }


        public static bool Cambiar(Entidad.Cliente pEntidad)
        {
            string nuevoEstado = "Activo";
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"update cliente set estado = case when estado = 'Activo' then 'Inactivo' else 'Activo' end where codigo_cliente=@codigo_cliente", cn))//@"select * from cliente where id_cliente=@id_cliente;"
                {
                    cmd.Parameters.AddWithValue("codigo_cliente", pEntidad.idcliente);

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = @"select estado from Cliente where codigo_cliente=@codigo_cliente;";
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

                SqlCommand cmd = new SqlCommand("buscar_cliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cliente", "%" + Nombres);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        public static bool Eliminar(Entidad.Cliente pEntidad)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"select * from cliente where codigo_cliente=@codigo_cliente;", cn))
                {
                    cmd.Parameters.AddWithValue("codigo_cliente", pEntidad.idcliente);
                    cn.Open();
                    cmd.CommandText = "delete from cliente where codigo_cliente=@codigo_cliente;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        public DataTable Listar_distrito()
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from distrito", cn);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
