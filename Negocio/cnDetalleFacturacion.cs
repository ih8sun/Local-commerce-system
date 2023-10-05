using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entidad;
using AccesoDatos;

namespace Negocio
{
    public class cnDetalleFacturacion
    {
        adDetalleFacturacion historial_dao = new adDetalleFacturacion();




        public void insert(DetalleFacturacion historial_entidad)
        {
            historial_dao.Insert(historial_entidad);

        }


    }
}
