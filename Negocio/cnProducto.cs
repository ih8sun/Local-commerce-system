using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using Entidad;
using AccesoDatos;

namespace Negocio
{
    public sealed class cnProducto
    {
        adProducto cliente_dao = new adProducto();

        public static bool Grabar(Entidad.Producto pEntidad, bool esNuevaInsercion)
        {
            if (esNuevaInsercion)
            {
                return AccesoDatos.adProducto.Grabar(pEntidad, true);
            }
            else
            {
                return AccesoDatos.adProducto.Grabar(pEntidad, false);
            }
        }

        public static bool Eliminar(Entidad.Producto pEntidad)
        {
            return AccesoDatos.adProducto.Eliminar(pEntidad);
        }
        public static bool Cambiar(Entidad.Producto pEntidad)
        {
            return AccesoDatos.adProducto.Cambiar(pEntidad);
        }

        public DataTable Buscar(String parametro)
        {
            return cliente_dao.Buscar(parametro);
        }

        public DataTable Listar_proveedor()
        {
            return cliente_dao.Listar_proveedor();
        }

        public DataTable Listar_marca()
        {
            return cliente_dao.Listar_marca();
        }

        public DataTable Listar_categoria()
        {
            return cliente_dao.Listar_categoria();
        }

        public DataTable Buscarr(String parametro)
        {
            return cliente_dao.Buscarr(parametro);
        }


    }
}
