using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using Entidad;

namespace AccesoDatos
{
    public class adDetalleFacturacion
    {




        public void Insert(DetalleFacturacion historial_entidad)
        {

            var cn = new SqlConnection(Conexion.LeerCC);

            {

                SqlCommand cmd = new SqlCommand("guardar_detalle_facturacion", cn);

                cmd.CommandType = CommandType.StoredProcedure;





                cmd.Parameters.Add("@id_documento", SqlDbType.Char).Value = historial_entidad.Ids;

                cmd.Parameters.Add("@id_producto", SqlDbType.Int).Value = historial_entidad.Cod_Productos;

                cmd.Parameters.Add("@producto", SqlDbType.VarChar, 50).Value = historial_entidad.Productos;

                cmd.Parameters.Add("@precio", SqlDbType.Decimal, 10).Value = historial_entidad.Precios;
                cmd.Parameters.Add("@cantidad", SqlDbType.Char, 10).Value = historial_entidad.Cantidads;
                cmd.Parameters.Add("@importe", SqlDbType.Decimal, 10).Value = historial_entidad.Subtotals;



                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

        }
    }
}
