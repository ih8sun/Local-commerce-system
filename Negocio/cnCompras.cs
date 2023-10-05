using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using Entidad;
using AccesoDatos;

namespace Negocio
{
    public sealed class cnCompras
    {
        adCompras cliente_dao = new adCompras();

        public static bool Grabar(Entidad.Compras pEntidad)
        {
            return AccesoDatos.adCompras.Grabar(pEntidad);
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

        public DataTable Buscar_cliente(String parametro)
        {
            return cliente_dao.Buscar_cliente(parametro);
        }


        public DataTable Listar_porcentaje()
        {
            return cliente_dao.Listar_porcentaje();
        }



        public DataTable Buscar_forma(String parametro)
        {
            return cliente_dao.Buscar_forma(parametro);
        }


        public List<Compras> UltimoEmp()
        {
            adCompras cd = new adCompras();
            return cd.UltimoCod();
        }



    }
}
