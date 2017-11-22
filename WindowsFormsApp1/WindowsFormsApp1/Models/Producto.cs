
namespace WindowsFormsApp1.Models
{
    class Producto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int precioUnitario { get; set; }
        public string url_imagen { get; set; }
        public int? idCategoria { get; set; }
    }
}