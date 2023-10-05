using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidad;
using AccesoDatos;

namespace Negocio
{
    public class cnDetalleCompras
    {
        adDetalleCompras historial_dao = new adDetalleCompras();




        public void insert(DetalleCompras historial_entidad)
        {
            historial_dao.Insert(historial_entidad);

        }


    }
}
