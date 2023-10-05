using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using Entidad;
using AccesoDatos;
using System.Diagnostics.SymbolStore;

namespace Negocio
{
    public sealed class cnCargo
    {
        adCargo cliente_dao = new adCargo();

        public static bool Grabar(Entidad.Cargo pEntidad, bool esNuevaInsercion)
        {
            if (esNuevaInsercion)
            {
                return AccesoDatos.adCargo.Grabar(pEntidad, true);
            }
            else
            {
                return AccesoDatos.adCargo.Grabar(pEntidad, false);
            }
        }

        public static bool Cambiar(Entidad.Cargo pEntidad)
        {
            return AccesoDatos.adCargo.Cambiar(pEntidad);
        }

        public static bool Eliminar(Entidad.Cargo pEntidad)
        {
            return AccesoDatos.adCargo.Eliminar(pEntidad);
        }

        public DataTable Buscar(String parametro)
        {
            return cliente_dao.Buscar(parametro);
        }



    }
}
