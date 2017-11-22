
namespace WindowsFormsApp1.Models
{
    class DetalleVenta
    {
        public int idDetalle { get; set; }
        public int numFactura { get; set; }
        public int idVenta { get; set; }
        public int subTotal { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
    }
}