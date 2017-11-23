using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using System.Web.Script.Serialization;

namespace WindowsFormsApp1.Views
{
    public partial class FormDetalleVenta : Form
    {
        int fac, ven, pro;
        public FormDetalleVenta()
        {
            InitializeComponent();
            l_ZonaMensaje.Text = string.Empty;
            Factura();
            Venta();
            Producto();
        }
        private async void B_Agregar_Click(object sender, EventArgs e)
        {
            if (tb_Cantidad.TextLength == 0)//cbcategoria and descripcion
            {
                l_ZonaMensaje.Text = "Debe ingresar los datos del DetalleVenta a Agregar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "numFactura=" + cb_Factura.SelectedValue;
                urlParametros += "&idVenta=" + cb_Venta.SelectedValue;
                urlParametros += "&subTotal=" + tb_SubTotal.Text;
                urlParametros += "&idProducto=" + cb_Producto.SelectedValue;
                urlParametros += "&cantidad=" + tb_Cantidad.Text;
                //url lista
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/DetalleVenta/AddDetalleVenta" + urlParametros))
                    {
                        using (HttpContent contenido = response.Content)
                        {
                            string respuestaserver = await contenido.ReadAsStringAsync();
                            JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                            dynamic dynamic = jsserialiser.DeserializeObject(respuestaserver);

                            
                            foreach (var item in dynamic)
                            {
                                l_ZonaMensaje.Text = item.Value;
                            }
                            tb_Id.Text = string.Empty;
                            tb_Cantidad.Text = string.Empty;
                            tb_SubTotal.Text = string.Empty;
                            cb_Factura.SelectedValue = 0;
                            cb_Producto.SelectedValue = 0;
                            cb_Venta.SelectedValue = 0;
                        }
                    }
                }//agregar
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/DetalleVenta/GetAll"))
                    {
                        using (HttpContent contenido = response.Content)
                        {
                            string respuestaserver = await contenido.ReadAsStringAsync();
                            JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                            dynamic listaDetalleVentasdynamica = jsserialiser.DeserializeObject(respuestaserver);
                            List<DetalleVenta> listaDetalleVentas = new List<DetalleVenta>();
                            foreach (var item in listaDetalleVentasdynamica)
                            {
                                listaDetalleVentas.Add(new DetalleVenta
                                {
                                    idDetalle = item["idDetalle"],
                                    numFactura = item["numFactura"],
                                    idVenta = item["idVenta"],
                                    subTotal = item["subTotal"],
                                    idProducto = item["idProducto"],
                                    cantidad = item["cantidad"]
                                });
                            }
                            dataGridView1.DataSource = listaDetalleVentas;
                        }
                    }
                }//get all
            }
        }
        private async void B_Editar_Click(object sender, EventArgs e)
        {
            if (tb_Id.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el ID del DetalleVenta a Eliminar";
            }
            else if (!int.TryParse(tb_Id.Text, out int id))
            {
                l_ZonaMensaje.Text = "Debe ingresar un valor Entero para el ID del DetalleVenta a Eliminar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "idDetalle=" + tb_Id.Text;
                urlParametros += "&numFactura=" + cb_Factura.SelectedValue;
                urlParametros += "&idVenta=" + cb_Venta.SelectedValue;
                urlParametros += "&subTotal=" + tb_SubTotal.Text;
                urlParametros += "&idProducto=" + cb_Producto.SelectedValue;
                urlParametros += "&cantidad=" + tb_Cantidad.Text;
                //url lista
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/DetalleVenta/EditDetalleVenta" + urlParametros))
                    {
                        using (HttpContent contenido = response.Content)
                        {
                            string respuestaserver = await contenido.ReadAsStringAsync();
                            JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                            dynamic dynamic = jsserialiser.DeserializeObject(respuestaserver);


                            foreach (var item in dynamic)
                            {
                                l_ZonaMensaje.Text = item.Value;
                            }
                            tb_Id.Text = string.Empty;
                            tb_Cantidad.Text = string.Empty;
                            tb_SubTotal.Text = string.Empty;
                            cb_Factura.SelectedValue = 0;
                            cb_Producto.SelectedValue = 0;
                            cb_Venta.SelectedValue = 0;
                        }
                    }
                }//agregar
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/DetalleVenta/GetAll"))
                    {
                        using (HttpContent contenido = response.Content)
                        {
                            string respuestaserver = await contenido.ReadAsStringAsync();
                            JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                            dynamic listaDetalleVentasdynamica = jsserialiser.DeserializeObject(respuestaserver);
                            List<DetalleVenta> listaDetalleVentas = new List<DetalleVenta>();
                            foreach (var item in listaDetalleVentasdynamica)
                            {
                                listaDetalleVentas.Add(new DetalleVenta
                                {
                                    idDetalle = item["idDetalle"],
                                    numFactura = item["numFactura"],
                                    idVenta = item["idVenta"],
                                    subTotal = item["subTotal"],
                                    idProducto = item["idProducto"],
                                    cantidad = item["cantidad"]
                                });
                            }
                            dataGridView1.DataSource = listaDetalleVentas;
                        }
                    }
                }//get all
            }
        }
        private async void B_Eliminar_Click(object sender, EventArgs e)
        {
            if (tb_Id.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el ID del DetalleVenta a Eliminar";
            }
            else if (!int.TryParse(tb_Id.Text, out int id))
            {
                l_ZonaMensaje.Text = "Debe ingresar un valor Entero para el ID del DetalleVenta a Eliminar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "idDetalle=" + tb_Id.Text;
                //url lista
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/DetalleVenta/DeleteDetalleVenta" + urlParametros))
                    {
                        using (HttpContent contenido = response.Content)
                        {
                            string respuestaserver = await contenido.ReadAsStringAsync();
                            JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                            dynamic dynamic = jsserialiser.DeserializeObject(respuestaserver);


                            foreach (var item in dynamic)
                            {
                                l_ZonaMensaje.Text = item.Value;
                            }
                            tb_Id.Text = string.Empty;
                            tb_Cantidad.Text = string.Empty;
                            tb_SubTotal.Text = string.Empty;
                            cb_Factura.SelectedValue = 0;
                            cb_Producto.SelectedValue = 0;
                            cb_Venta.SelectedValue = 0;
                        }
                    }
                }//agregar
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/DetalleVenta/GetAll"))
                    {
                        using (HttpContent contenido = response.Content)
                        {
                            string respuestaserver = await contenido.ReadAsStringAsync();
                            JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                            dynamic listaDetalleVentasdynamica = jsserialiser.DeserializeObject(respuestaserver);
                            List<DetalleVenta> listaDetalleVentas = new List<DetalleVenta>();
                            foreach (var item in listaDetalleVentasdynamica)
                            {
                                listaDetalleVentas.Add(new DetalleVenta
                                {
                                    idDetalle = item["idDetalle"],
                                    numFactura = item["numFactura"],
                                    idVenta = item["idVenta"],
                                    subTotal = item["subTotal"],
                                    idProducto = item["idProducto"],
                                    cantidad = item["cantidad"]
                                });
                            }
                            dataGridView1.DataSource = listaDetalleVentas;
                        }
                    }
                }//get all
            }
        }
        private async void B_Mostrar_Click(object sender, EventArgs e)
        {
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/DetalleVenta/GetAll"))
                {
                    using (HttpContent contenido = response.Content)
                    {
                        string respuestaserver = await contenido.ReadAsStringAsync();
                        JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                        dynamic listaDetalleVentasdynamica = jsserialiser.DeserializeObject(respuestaserver);
                        List<DetalleVenta> listaDetalleVentas = new List<DetalleVenta>();
                        foreach (var item in listaDetalleVentasdynamica)
                        {
                            listaDetalleVentas.Add(new DetalleVenta
                            {
                                idDetalle = item["idDetalle"],
                                numFactura = item["numFactura"],
                                idVenta = item["idVenta"],
                                subTotal = item["subTotal"],
                                idProducto = item["idProducto"],
                                cantidad = item["cantidad"]
                            });
                        }
                        dataGridView1.DataSource = listaDetalleVentas;
                    }
                }
            }
            l_ZonaMensaje.Text = string.Empty;
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                tb_Id.Text = row.Cells[0].Value.ToString();
                cb_Factura.SelectedValue = row.Cells[1].Value;
                cb_Venta.SelectedValue = row.Cells[2].Value;
                tb_SubTotal.Text = row.Cells[3].Value.ToString();
                cb_Producto.SelectedValue = row.Cells[4].Value;
                tb_Cantidad.Text = row.Cells[5].Value.ToString();// para nulls
            }
        }
        private async void Factura()
        {
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Factura/GetAll"))
                {
                    using (HttpContent contenido = response.Content)
                    {
                        string respuestaserver = await contenido.ReadAsStringAsync();
                        JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                        dynamic listaproductosdynamica = jsserialiser.DeserializeObject(respuestaserver);
                        List<Factura> listaproductos = new List<Factura>();
                        listaproductos.Add(new Factura
                        {
                            numFactura = 0,
                            fecha = DateTime.Now
                        });
                        foreach (var item in listaproductosdynamica)
                        {
                            listaproductos.Add(new Factura
                            {
                                numFactura = item["numFactura"],
                                fecha = item["fecha"]
                            });
                        }
                        cb_Factura.DataSource = listaproductos;
                        cb_Factura.DisplayMember = "fecha";
                        cb_Factura.ValueMember = "numFactura";
                        fac = (int)cb_Factura.SelectedValue;
                    }
                }
            }
        }
        private async void Venta()
        {
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Venta/GetAll"))
                {
                    using (HttpContent contenido = response.Content)
                    {
                        string respuestaserver = await contenido.ReadAsStringAsync();
                        JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                        dynamic listaproductosdynamica = jsserialiser.DeserializeObject(respuestaserver);
                        List<Venta> listaproductos = new List<Venta>();
                        listaproductos.Add(new Venta
                        {
                            idVenta = 0,
                            fecha = DateTime.Now
                        });
                        foreach (var item in listaproductosdynamica)
                        {
                            listaproductos.Add(new Venta
                            {
                                idVenta = item["idVenta"],
                                fecha = item["fecha"]
                            });
                        }
                        cb_Venta.DataSource = listaproductos;
                        cb_Venta.DisplayMember = "fecha";
                        cb_Venta.ValueMember = "idVenta";
                        ven = (int)cb_Venta.SelectedValue;
                    }
                }
            }
        }
        private async void Producto()
        {
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Producto/GetAll"))
                {
                    using (HttpContent contenido = response.Content)
                    {
                        string respuestaserver = await contenido.ReadAsStringAsync();
                        JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                        dynamic listaproductosdynamica = jsserialiser.DeserializeObject(respuestaserver);
                        List<Producto> listaproductos = new List<Producto>();
                        listaproductos.Add(new Producto
                        {
                            idProducto = 0,
                            nombre = "Selecionar Producto"
                        });
                        foreach (var item in listaproductosdynamica)
                        {
                            listaproductos.Add(new Producto
                            {
                                idProducto = item["idProducto"],
                                nombre = item["nombre"]
                            });
                        }
                        cb_Producto.DataSource = listaproductos;
                        cb_Producto.DisplayMember = "nombre";
                        cb_Producto.ValueMember = "idProducto";
                        pro = (int)cb_Producto.SelectedValue;
                    }
                }
            }
        }
    }
}