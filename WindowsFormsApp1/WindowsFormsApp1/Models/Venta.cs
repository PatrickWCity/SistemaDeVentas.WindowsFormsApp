using System;

namespace WindowsFormsApp1.Models
{
    class Venta
    {
        public int idVenta { get; set; }
        public int total { get; set; }
        public int idCliente { get; set; }
        public int idVendedor { get; set; }
        public DateTime fecha { get; set; }
        public int descuento { get; set; }
        public int IVA { get; set; }
    }
}