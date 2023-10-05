using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class Compras
    {
        public string iddocumento { get; set; }
        public string serie { get; set; }
        public string fecha { get; set; }

        public string hora { get; set; }
        public string codigo_cliente { get; set; }
        public string id_usuario { get; set; }
        public string subtotal { get; set; }
        public string igv { get; set; }
        public string total { get; set; }

        public string id_tipo_documento { get; set; }
        public string id_forma { get; set; }

        public string observacion { get; set; }

        
        private string _codigo;

        public string Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                _codigo = value;
            }
        }

        public Compras()
        {
        }

        public Compras(string ccodigo)
        {
            _codigo = ccodigo;
        }

       


    }
}
