using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using Entidad;
using AccesoDatos;

namespace Negocio
{
    public sealed class cnFacturacion
    {
        adFacturacion cliente_dao = new adFacturacion();

        public static bool Grabar(Entidad.Facturacion pEntidad)
        {
            return AccesoDatos.adFacturacion.Grabar(pEntidad);
        }






        public static bool Actualizar(Entidad.Facturacion pEntidad)
        {
            return AccesoDatos.adFacturacion.Actualizar(pEntidad);
        }



        public static bool Cancelar_Facturacion(Entidad.Facturacion pEntidad)
        {
            return AccesoDatos.adFacturacion.Cancelar_Facturacion(pEntidad);
        }



        public static bool Cancelar_Detalle_Facturacion(Entidad.Facturacion pEntidad)
        {
            return AccesoDatos.adFacturacion.Cancelar_Detalle_Facturacion(pEntidad);
        }




        public DataTable Listar_usuario()
        {
            return cliente_dao.Listar_usuario();
        }


        public DataTable Listar_forma()
        {
            return cliente_dao.Listar_forma();
        }

        public DataTable Listar_documento()
        {
            return cliente_dao.Listar_documento();
        }


        public DataTable Listar_porcentaje()
        {
            return cliente_dao.Listar_porcentaje();
        }



        public DataTable Buscar_cliente(String parametro)
        {
            return cliente_dao.Buscar_cliente(parametro);
        }

        public DataTable Buscar_forma(String parametro)
        {
            return cliente_dao.Buscar_forma(parametro);
        }

        public List<Facturacion> UltimoEmp()
        {
            adFacturacion cd = new adFacturacion();
            return cd.UltimoCod();
        }


    }
}
