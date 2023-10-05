using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using Entidad;
using AccesoDatos;

namespace Negocio
{
    public sealed class cnProveedor
    {
        adProveedor cliente_dao = new adProveedor();

        public static bool Grabar(Entidad.Proveedor pEntidad, bool esNuevaInsercion)
        {
            if (esNuevaInsercion)
            {
                return AccesoDatos.adProveedor.Grabar(pEntidad, true);
            }
            else
            {
                return AccesoDatos.adProveedor.Grabar(pEntidad, false);
            }
        }

        public static bool Cambiar(Entidad.Proveedor pEntidad)
        {
            return AccesoDatos.adProveedor.Cambiar(pEntidad);
        }
        public static bool Eliminar(Entidad.Proveedor pEntidad)
        {
            return AccesoDatos.adProveedor.Eliminar(pEntidad);
        }

        public DataTable Buscar(String parametro)
        {
            return cliente_dao.Buscar(parametro);
        }

       

    }
}
