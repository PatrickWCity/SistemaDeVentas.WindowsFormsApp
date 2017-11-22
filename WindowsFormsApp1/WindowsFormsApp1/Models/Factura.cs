using System;

namespace WindowsFormsApp1.Models
{
    class Factura
    {
        public int numFactura { get; set; }
        public DateTime fecha { get; set; }
        public int IVA { get; set; }
        public int total { get; set; }
        public int numPago { get; set; }
        public int descuento { get; set; }
    }
}
