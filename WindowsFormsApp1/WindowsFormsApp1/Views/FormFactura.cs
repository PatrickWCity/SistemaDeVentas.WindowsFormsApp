using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using System.Web.Script.Serialization;

namespace WindowsFormsApp1.Views
{
    public partial class FormFactura : Form
    {
        int mod;
        public FormFactura()
        {
            InitializeComponent();
            l_ZonaMensaje.Text = string.Empty;
            ModoPago();
        }
        private async void B_Agregar_Click(object sender, EventArgs e)
        {
            if (tb_IVA.TextLength == 0)//cbcategoria and descripcion
            {
                l_ZonaMensaje.Text = "Debe ingresar los datos del Factura a Agregar";
            }
            else if (tb_IVA.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el nombre del Factura a Agregar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "fecha=" + DateTime.Now;
                urlParametros += "&IVA=" + tb_IVA.Text;
                urlParametros += "&total=" + tb_Total.Text;
                urlParametros += "&numPago=" + cb_ModoPago.SelectedValue;
                urlParametros += "&descuento=" + tb_Descuento.Text;
                //url lista
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Factura/AddFactura" + urlParametros))
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
                            tb_IVA.Text = string.Empty;
                            tb_Total.Text = string.Empty;
                            cb_ModoPago.SelectedValue = 0;
                            tb_Descuento.Text = string.Empty;
                        }
                    }
                }//agregar
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Factura/GetAll"))
                    {
                        using (HttpContent contenido = response.Content)
                        {
                            string respuestaserver = await contenido.ReadAsStringAsync();
                            JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                            dynamic listaFacturasdynamica = jsserialiser.DeserializeObject(respuestaserver);
                            List<Factura> listaFacturas = new List<Factura>();
                            foreach (var item in listaFacturasdynamica)
                            {
                                listaFacturas.Add(new Factura
                                {
                                    numFactura = item["numFactura"],
                                    fecha = item["fecha"],
                                    IVA = item["IVA"],
                                    total = item["total"],
                                    numPago = item["numPago"],
                                    descuento = item["descuento"]
                                });
                            }
                            dataGridView1.DataSource = listaFacturas;
                        }
                    }
                }//get all
            }
        }
        private async void B_Editar_Click(object sender, EventArgs e)
        {
            if (tb_Id.TextLength == 0 && tb_IVA.TextLength == 0)//cbcategoria and descripcion
            {
                l_ZonaMensaje.Text = "Debe ingresar los datos del Factura a Agregar";
            }
            else if (tb_Id.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el ID del Factura a Eliminar";
            }
            else if (!int.TryParse(tb_Id.Text, out int id))
            {
                l_ZonaMensaje.Text = "Debe ingresar un valor Entero para el ID del Factura a Eliminar";
            }
            else if (tb_IVA.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el nombre del Factura a Agregar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "numFactura=" + tb_Id.Text;
                urlParametros += "&fecha=" + DateTime.Now;
                urlParametros += "&IVA=" + tb_IVA.Text;
                urlParametros += "&total=" + tb_Total.Text;
                urlParametros += "&numPago=" + cb_ModoPago.SelectedValue;
                urlParametros += "&descuento=" + tb_Descuento.Text;
                //url lista
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Factura/EditFactura" + urlParametros))
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
                            tb_IVA.Text = string.Empty;
                            tb_Total.Text = string.Empty;
                            cb_ModoPago.SelectedValue = 0;
                            tb_Descuento.Text = string.Empty;
                        }
                    }
                }//agregar
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Factura/GetAll"))
                    {
                        using (HttpContent contenido = response.Content)
                        {
                            string respuestaserver = await contenido.ReadAsStringAsync();
                            JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                            dynamic listaFacturasdynamica = jsserialiser.DeserializeObject(respuestaserver);
                            List<Factura> listaFacturas = new List<Factura>();
                            foreach (var item in listaFacturasdynamica)
                            {
                                listaFacturas.Add(new Factura
                                {
                                    numFactura = item["numFactura"],
                                    fecha = item["fecha"],
                                    IVA = item["IVA"],
                                    total = item["total"],
                                    numPago = item["numPago"],
                                    descuento = item["descuento"]
                                });
                            }
                            dataGridView1.DataSource = listaFacturas;
                        }
                    }
                }//get all
            }
        }
        private async void B_Eliminar_Click(object sender, EventArgs e)
        {
            if (tb_Id.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el ID del Factura a Eliminar";
            }
            else if (!int.TryParse(tb_Id.Text, out int id))
            {
                l_ZonaMensaje.Text = "Debe ingresar un valor Entero para el ID del Factura a Eliminar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "numFactura=" + tb_Id.Text;
                //url lista
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Factura/DeleteFactura" + urlParametros))
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
                            tb_IVA.Text = string.Empty;
                            tb_Total.Text = string.Empty;
                            cb_ModoPago.SelectedValue = 0;
                            tb_Descuento.Text = string.Empty;
                        }
                    }
                }//agregar
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Factura/GetAll"))
                    {
                        using (HttpContent contenido = response.Content)
                        {
                            string respuestaserver = await contenido.ReadAsStringAsync();
                            JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                            dynamic listaFacturasdynamica = jsserialiser.DeserializeObject(respuestaserver);
                            List<Factura> listaFacturas = new List<Factura>();
                            foreach (var item in listaFacturasdynamica)
                            {
                                listaFacturas.Add(new Factura
                                {
                                    numFactura = item["numFactura"],
                                    fecha = item["fecha"],
                                    IVA = item["IVA"],
                                    total = item["total"],
                                    numPago = item["numPago"],
                                    descuento = item["descuento"]
                                });
                            }
                            dataGridView1.DataSource = listaFacturas;
                        }
                    }
                }//get all
            }
        }
        private async void B_Mostrar_Click(object sender, EventArgs e)
        {
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Factura/GetAll"))
                {
                    using (HttpContent contenido = response.Content)
                    {
                        string respuestaserver = await contenido.ReadAsStringAsync();
                        JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                        dynamic listaFacturasdynamica = jsserialiser.DeserializeObject(respuestaserver);
                        List<Factura> listaFacturas = new List<Factura>();
                        foreach (var item in listaFacturasdynamica)
                        {
                            listaFacturas.Add(new Factura
                            {
                                numFactura = item["numFactura"],
                                fecha = item["fecha"],
                                IVA = item["IVA"],
                                total = item["total"],
                                numPago = item["numPago"],
                                descuento = item["descuento"]
                            });
                        }
                        dataGridView1.DataSource = listaFacturas;
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
                tb_IVA.Text = row.Cells[2].Value.ToString();
                tb_Total.Text = row.Cells[3].Value.ToString();// para nulls
                cb_ModoPago.SelectedValue = row.Cells[4].Value;
                tb_Descuento.Text = row.Cells[5].Value.ToString();
            }
        }
        private async void ModoPago()
        {
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/ModoPago/GetAll"))
                {
                    using (HttpContent contenido = response.Content)
                    {
                        string respuestaserver = await contenido.ReadAsStringAsync();
                        JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                        dynamic listaproductosdynamica = jsserialiser.DeserializeObject(respuestaserver);
                        List<ModoPago> listaproductos = new List<ModoPago>();
                        listaproductos.Add(new ModoPago
                        {
                            numPago = 0,
                            nombre = "Selecionar Modo de Pago"
                        });
                        foreach (var item in listaproductosdynamica)
                        {
                            listaproductos.Add(new ModoPago
                            {
                                numPago = item["numPago"],
                                nombre = item["nombre"]//+" "+item["apPaterno"]+" "+item["ApMaterno"] 
                            });
                        }
                        cb_ModoPago.DataSource = listaproductos;
                        cb_ModoPago.DisplayMember = "nombre";
                        cb_ModoPago.ValueMember = "numPago";
                        mod = (int)cb_ModoPago.SelectedValue;
                    }
                }
            }
        }
    }
}