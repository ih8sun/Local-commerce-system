using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using Entidad;
using AccesoDatos;

namespace Negocio
{
    public sealed class cnCategoria
    {
        adCategoria cliente_dao = new adCategoria();

        public static bool Grabar(Entidad.Categoria pEntidad, bool esNuevaInsercion)
        {

            if (esNuevaInsercion)
            {
                return AccesoDatos.adCategoria.Grabar(pEntidad, true);
            }
            else
            {
                return AccesoDatos.adCategoria.Grabar(pEntidad, false);
            }
        }
        public static bool Cambiar(Entidad.Categoria pEntidad)
        {
            return AccesoDatos.adCategoria.Cambiar(pEntidad);
        }

        public static bool Eliminar(Entidad.Categoria pEntidad)
        {
            return AccesoDatos.adCategoria.Eliminar(pEntidad);
        }

        public DataTable Buscar(String parametro)
        {
            return cliente_dao.Buscar(parametro);
        }

        

    }
}
