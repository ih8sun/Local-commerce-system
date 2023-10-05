using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using Entidad;
using AccesoDatos;

namespace Negocio
{


    public sealed class cnMarca
    {
        adMarca cliente_dao = new adMarca();


        public static bool Grabar(Entidad.Marca pEntidad, bool esNuevaInsercion)
        {
            if (esNuevaInsercion)
            {
                return AccesoDatos.adMarca.Grabar(pEntidad, true);
            }
            else
            {
                return AccesoDatos.adMarca.Grabar(pEntidad, false);
            }
        }
        public static bool Cambiar(Entidad.Marca pEntidad)
        {
            return AccesoDatos.adMarca.Cambiar(pEntidad);
        }

        public static bool Eliminar(Entidad.Marca pEntidad)
        {
            return AccesoDatos.adMarca.Eliminar(pEntidad);
        }

        public DataTable Buscar(String parametro)
        {
            return cliente_dao.Buscar(parametro);
        }



    }
}
