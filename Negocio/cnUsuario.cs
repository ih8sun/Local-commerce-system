using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using Entidad;
using AccesoDatos;

namespace Negocio
{
    public sealed class cnUsuario
    {
        adUsuario cliente_dao = new adUsuario();

        public static bool Grabar(Entidad.Usuario pEntidad, bool esNuevaInsercion)
        {
            if (esNuevaInsercion)
            {
                return AccesoDatos.adUsuario.Grabar(pEntidad, true);
            }
            else
            {
                return AccesoDatos.adUsuario.Grabar(pEntidad, false);

            }
        }

        public static bool Cambiar(Entidad.Usuario pEntidad)
        {
            return AccesoDatos.adUsuario.Cambiar(pEntidad);
        }


        public static bool Eliminar(Entidad.Usuario pEntidad)
        {
            return AccesoDatos.adUsuario.Eliminar(pEntidad);
        }

        public DataTable Buscar(String parametro)
        {
            return cliente_dao.Buscar(parametro);
        }


        public DataTable Listar_cargo()
        {
            return cliente_dao.Listar_cargo();
        }
    }
}
