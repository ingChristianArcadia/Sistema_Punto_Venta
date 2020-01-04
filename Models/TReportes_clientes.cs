using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TReportes_clientes
    {
        [PrimaryKey, Identity]
        public int IdReporte { set; get; }
        public string Pago { set; get; }
        public string FechaPago { set; get; }
        public string Deuda { set; get; }
        public string FechaDeuda { set; get; }
        public string Ticket { set; get; }
        public int IdCliente { set; get; }
    }
}
