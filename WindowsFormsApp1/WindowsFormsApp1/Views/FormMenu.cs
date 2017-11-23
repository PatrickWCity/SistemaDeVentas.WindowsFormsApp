using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCliente fc = new FormCliente();
            fc.Show();
        }

        private void vendedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVendedor fv = new FormVendedor();
            fv.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCategoria fc = new FormCategoria();
            fc.Show();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProducto fp = new FormProducto();
            fp.Show();
        }

        private void modoDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModoPago fm = new FormModoPago();
            fm.Show();

        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVenta fv = new FormVenta();
            fv.Show();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFactura ff = new FormFactura();
            ff.Show();
        }

        private void detalleDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDetalleVenta fd = new FormDetalleVenta();
            fd.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
