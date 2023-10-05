using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using Entidad;
using AccesoDatos;

namespace Negocio
{
    public sealed class cnPorcentaje
    {
        adPorcentaje cliente_dao = new adPorcentaje();

        public static bool Grabar(Entidad.Porcentaje pEntidad)
        {
            return AccesoDatos.adPorcentaje.Grabar(pEntidad);
        }

        public static bool Eliminar(Entidad.Porcentaje pEntidad)
        {
            return AccesoDatos.adPorcentaje.Eliminar(pEntidad);
        }

        public DataTable Buscar(String parametro)
        {
            return cliente_dao.Buscar(parametro);
        }



    }
}
