using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using Entidad;
using AccesoDatos;

namespace Negocio
{
    public sealed class cnTipo
    {
        adTipo cliente_dao = new adTipo();

        public static bool Grabar(Entidad.Tipo pEntidad, bool esNuevaInsercion)
        {
            if (esNuevaInsercion)
            {
                return AccesoDatos.adTipo.Grabar(pEntidad, true);
            }
            else
            {
                return AccesoDatos.adTipo.Grabar(pEntidad, false);
            }
            
        }
        public static bool Cambiar(Entidad.Tipo pEntidad)
        {
            return AccesoDatos.adTipo.Cambiar(pEntidad);
        }
        public static bool Eliminar(Entidad.Tipo pEntidad)
        {
            return AccesoDatos.adTipo.Eliminar(pEntidad);
        }

        public DataTable Buscar(String parametro)
        {
            return cliente_dao.Buscar(parametro);
        }

        

    }
}
