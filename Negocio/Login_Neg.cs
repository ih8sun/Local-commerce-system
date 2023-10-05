using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using Entidad;
using AccesoDatos;

namespace Negocio
{
    public class Login_Neg
    {
        Login_Dao objd = new Login_Dao();
        public DataTable N_login(Entidad.Login_Entidad obje)
        {
            return objd.D_Login(obje);
        }

      
    }
}
