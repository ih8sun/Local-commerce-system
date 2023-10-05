using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using Entidad;
using AccesoDatos;

namespace Negocio
{
    public sealed class cnCliente
    {
        adCliente cliente_dao = new adCliente();

        public static bool Grabar(Entidad.Cliente pEntidad, bool esNuevaInsercion)
        {
            if (esNuevaInsercion)
            {
                return AccesoDatos.adCliente.Grabar(pEntidad, true);
            }
            else
            {
                return AccesoDatos.adCliente.Grabar(pEntidad, false);
            }
        }
        public static bool Cambiar(Entidad.Cliente pEntidad)
        {
            return AccesoDatos.adCliente.Cambiar(pEntidad);
        }

        public static bool Eliminar(Entidad.Cliente pEntidad)
        {
            return AccesoDatos.adCliente.Eliminar(pEntidad);
        }

        public DataTable Buscar(String parametro)
        {
            return cliente_dao.Buscar(parametro);
        }

        public DataTable Listar_distrito()
        {
            return cliente_dao.Listar_distrito();
        }

    }
}
