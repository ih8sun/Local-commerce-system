using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

using System.Data;


namespace AccesoDatos
{
    public sealed class adProducto
    {
        public static bool Grabar(Entidad.Producto pEntidad, bool esNuevaInsercion)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                cn.Open();

                if (esNuevaInsercion)
                {
                    using (var cmdExistencia = new SqlCommand(@"select count(*) from productos where producto = @producto and descripcion = @descripcion and id_proveedor = @id_proveedor and id_marca = @id_marca and id_categoria = @id_categoria", cn))
                    {
                        cmdExistencia.Parameters.AddWithValue("producto", pEntidad.product);
                        cmdExistencia.Parameters.AddWithValue("descripcion", pEntidad.descripcion);
                        cmdExistencia.Parameters.AddWithValue("id_proveedor", pEntidad.idproveedor);
                        cmdExistencia.Parameters.AddWithValue("id_marca", pEntidad.idmarca);
                        cmdExistencia.Parameters.AddWithValue("id_categoria", pEntidad.idcategoria);

                        if(Convert.ToInt32(cmdExistencia.ExecuteScalar()) > 0)
                        {
                            // Ya existe un registro con la misma cédula, no se permite la inserción
                            throw new ApplicationException("Ya existe un registro con el mismo nombre, descripcion, proveedor, marca y categoria");
                        }
                    }
                }

                using (var cmd = new SqlCommand(@"select * from Productos where id_producto=@id_producto;", cn))//@"select * from cliente where id_cliente=@id_cliente;"
                {
                    cmd.Parameters.AddWithValue("id_producto", pEntidad.idproducto);
                    cmd.Parameters.AddWithValue("producto", pEntidad.product);
                    cmd.Parameters.AddWithValue("descripcion", pEntidad.descripcion);

                    cmd.Parameters.AddWithValue("precio_compra", pEntidad.compra);
                    cmd.Parameters.AddWithValue("precio_venta", pEntidad.venta);
                    cmd.Parameters.AddWithValue("id_proveedor", pEntidad.idproveedor);

                    cmd.Parameters.AddWithValue("unidad_medida", pEntidad.unidad);
                    cmd.Parameters.AddWithValue("stock", pEntidad.stock);
                    cmd.Parameters.AddWithValue("id_marca", pEntidad.idmarca);

                    cmd.Parameters.AddWithValue("id_categoria", pEntidad.idcategoria);

                    cmd.Parameters.AddWithValue("fecha", pEntidad.fecha);
                    cmd.Parameters.AddWithValue("estado", pEntidad.estado);

                    if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    {
                        cmd.CommandText = @"update productos set producto=@producto,descripcion=@descripcion,precio_compra=@precio_compra,precio_venta=@precio_venta,id_proveedor=@id_proveedor,unidad_medida=@unidad_medida,stock=@stock,id_marca=@id_marca,id_categoria=@id_categoria,fecha=@fecha,estado=@estado where id_producto=@id_producto;"; 
                    }
                    else
                        cmd.CommandText = @"insert into productos (producto,descripcion,precio_compra,precio_venta,id_proveedor,unidad_medida,stock,id_marca,id_categoria,fecha,estado) values (@producto,@descripcion,@precio_compra,@precio_venta,@id_proveedor,@unidad_medida,@stock,@id_marca,@id_categoria,@fecha,'Activo');";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        public static bool Cambiar(Entidad.Producto pEntidad)
        {
            string nuevoEstado = "Activo";
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"update productos set estado = case when estado = 'Activo' then 'Inactivo' else 'Activo' end where id_producto=@id_producto", cn))//@"select * from cliente where id_cliente=@id_cliente;"
                {
                    cmd.Parameters.AddWithValue("id_producto", pEntidad.idproducto);

                    try
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = @"select estado from productos where id_producto=@id_producto;";
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

                SqlCommand cmd = new SqlCommand("buscar_producto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@producto", "%" + Nombres);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable Buscarr(String Nombress)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {

                SqlCommand cmd = new SqlCommand("buscar_productos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@producto", "%" + Nombress);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static bool Eliminar(Entidad.Producto pEntidad)
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                using (var cmd = new SqlCommand(@"select * from Productos where id_producto=@id_producto;", cn))
                {
                    cmd.Parameters.AddWithValue("id_producto", pEntidad.idproducto);
                    cn.Open();
                    cmd.CommandText = "delete from Productos where id_producto=@id_producto;";
                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
        }

        public DataTable Listar_proveedor()
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from proveedor where estado ='Activo'", cn);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable Listar_marca()
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from marca where estado ='Activo'", cn);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable Listar_categoria()
        {
            using (var cn = new SqlConnection(Conexion.LeerCC))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from categoria where estado ='Activo'", cn);
                da.SelectCommand.CommandType = CommandType.Text;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}
