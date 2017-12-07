using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using System.Web.Script.Serialization;

namespace WindowsFormsApp1.Views
{
    public partial class FormVenta : Form
    {
        int cli, ven;
        public FormVenta()
        {
            InitializeComponent();
            l_ZonaMensaje.Text = string.Empty;
            try { 
            Cliente();
            Vendedor();
            }
            catch
            {
                l_ZonaMensaje.Text = "Error de Conexión!";
            }
            Icon = Properties.Resources.Icon;
            B_Agregar.Enabled = true;
            B_Editar.Enabled = false;
            B_Eliminar.Enabled = false;
        }

        private async void B_Agregar_Click(object sender, EventArgs e)
        {
            if (tb_Total.TextLength == 0)//cbcategoria and descripcion
            {
                l_ZonaMensaje.Text = "Debe ingresar los datos del Venta a Agregar";
            }
            else if (tb_Total.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el nombre del Venta a Agregar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "total=" + tb_Total.Text;
                urlParametros += "&idCliente=" + cb_Cliente.SelectedValue;
                urlParametros += "&idVendedor=" + cb_Vendedor.SelectedValue;
                urlParametros += "&fecha=" + DateTime.Now;
                urlParametros += "&descuento=" + tb_Descuento.Text;
                urlParametros += "&IVA=" + tb_IVA.Text;
                //url lista
                try { 
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Venta/AddVenta" + urlParametros))
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
                            tb_Total.Text = string.Empty;
                            tb_Descuento.Text = string.Empty;
                            tb_IVA.Text = string.Empty;
                            cb_Cliente.SelectedValue = 0;
                            cb_Vendedor.SelectedValue = 0;
                        }
                    }
                }//agregar
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
                            foreach (var item in listaproductosdynamica)
                            {
                                listaproductos.Add(new Venta
                                {
                                    idVenta = item["idVenta"],
                                    total = item["total"],
                                    idCliente = item["idCliente"],
                                    idVendedor = item["idVendedor"],
                                    fecha = item["fecha"],
                                    descuento = item["descuento"],
                                    IVA = item["IVA"]
                                });
                            }
                            dataGridView1.DataSource = listaproductos;
                        }
                    }
                }//get all
                }
                catch
                {
                    l_ZonaMensaje.Text = "Error de Conexión!";
                }
            }
        }
        private async void B_Editar_Click(object sender, EventArgs e)
        {
            if (tb_Id.TextLength == 0 && tb_Total.TextLength == 0)//cbcategoria and descripcion
            {
                l_ZonaMensaje.Text = "Debe ingresar los datos del Venta a Agregar";
            }
            else if (tb_Id.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el ID del Venta a Eliminar";
            }
            else if (!int.TryParse(tb_Id.Text, out int id))
            {
                l_ZonaMensaje.Text = "Debe ingresar un valor Entero para el ID del Venta a Eliminar";
            }
            else if (tb_Total.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el nombre del Venta a Agregar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "idVenta=" + tb_Id.Text;
                urlParametros += "&total=" + tb_Total.Text;
                urlParametros += "&idCliente=" + cb_Cliente.SelectedValue;
                urlParametros += "&idVendedor=" + cb_Vendedor.SelectedValue;
                urlParametros += "&fecha=" + DateTime.Now;
                urlParametros += "&descuento=" + tb_Descuento.Text;
                urlParametros += "&IVA=" + tb_IVA.Text;
                //url lista
                try { 
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Venta/EditVenta" + urlParametros))
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
                            tb_Total.Text = string.Empty;
                            tb_Descuento.Text = string.Empty;
                            tb_IVA.Text = string.Empty;
                            cb_Cliente.SelectedItem = 0;
                            cb_Vendedor.SelectedItem = 0;
                        }
                    }
                }//agregar
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
                            foreach (var item in listaproductosdynamica)
                            {
                                listaproductos.Add(new Venta
                                {
                                    idVenta = item["idVenta"],
                                    total = item["total"],
                                    idCliente = item["idCliente"],
                                    idVendedor = item["idVendedor"],
                                    fecha = item["fecha"],
                                    descuento = item["descuento"],
                                    IVA = item["IVA"]
                                });
                            }
                            dataGridView1.DataSource = listaproductos;
                        }
                    }
                }//get all
                }
                catch
                {
                    l_ZonaMensaje.Text = "Error de Conexión!";
                }
            }
        }
        private async void B_Eliminar_Click(object sender, EventArgs e)
        {
            if (tb_Id.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el ID del Venta a Eliminar";
            }
            else if (!int.TryParse(tb_Id.Text, out int id))
            {
                l_ZonaMensaje.Text = "Debe ingresar un valor Entero para el ID del Venta a Eliminar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "idVenta=" + tb_Id.Text;
                //url lista
                try { 
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Venta/DeleteVenta" + urlParametros))
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
                            tb_Total.Text = string.Empty;
                            tb_Descuento.Text = string.Empty;
                            tb_IVA.Text = string.Empty;
                            cb_Cliente.SelectedValue = 0;
                            cb_Vendedor.SelectedValue = 0;
                        }
                    }
                }//agregar
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
                            foreach (var item in listaproductosdynamica)
                            {
                                listaproductos.Add(new Venta
                                {
                                    idVenta = item["idVenta"],
                                    total = item["total"],
                                    idCliente = item["idCliente"],
                                    idVendedor = item["idVendedor"],
                                    fecha = item["fecha"],
                                    descuento = item["descuento"],
                                    IVA = item["IVA"]
                                });
                            }
                            dataGridView1.DataSource = listaproductos;
                        }
                    }
                }//get all
                }
                catch
                {
                    l_ZonaMensaje.Text = "Error de Conexión!";
                }
            }
        }
        private async void B_Mostrar_Click(object sender, EventArgs e)
        {
            try { 
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
                        foreach (var item in listaproductosdynamica)
                        {
                            listaproductos.Add(new Venta
                            {
                                idVenta = item["idVenta"],
                                total = item["total"],
                                idCliente = item["idCliente"],
                                idVendedor = item["idVendedor"],
                                fecha = item["fecha"],
                                descuento = item["descuento"],
                                IVA = item["IVA"]
                            });
                        }
                        dataGridView1.DataSource = listaproductos;
                    }
                }
            }
            l_ZonaMensaje.Text = string.Empty;
            }
            catch
            {
                l_ZonaMensaje.Text = "Error de Conexión!";
            }
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                tb_Id.Text = row.Cells[0].Value.ToString();
                tb_Total.Text = row.Cells[1].Value.ToString();
                cb_Cliente.SelectedValue = row.Cells[2].Value;
                cb_Vendedor.SelectedValue = row.Cells[3].Value;
                tb_Descuento.Text = row.Cells[4].Value.ToString();
                tb_IVA.Text = row.Cells[5].Value.ToString();
                B_Agregar.Enabled = false;
                B_Editar.Enabled = true;
                B_Eliminar.Enabled = true;
            }
        }
        private async void Cliente()
        {
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Cliente/GetAll"))
                {
                    using (HttpContent contenido = response.Content)
                    {
                        string respuestaserver = await contenido.ReadAsStringAsync();
                        JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                        dynamic listaproductosdynamica = jsserialiser.DeserializeObject(respuestaserver);
                        List<Cliente> listaproductos = new List<Cliente>();
                        listaproductos.Add(new Cliente
                        {
                            idCliente = 0,
                            nombre = "Selecionar Cliente"
                        });
                        foreach (var item in listaproductosdynamica)
                        {
                            listaproductos.Add(new Cliente
                            {
                                idCliente = item["idCliente"],
                                nombre = item["nombre"]+" "+item["apPaterno"]
                            });
                        }
                        cb_Cliente.DataSource = listaproductos;
                        cb_Cliente.DisplayMember = "nombre";
                        cb_Cliente.ValueMember = "idCliente";
                        cli = (int)cb_Cliente.SelectedValue;
                    }
                }
            }
        }

        private void B_Restablecer_Click(object sender, EventArgs e)
        {
            B_Agregar.Enabled = true;
            B_Editar.Enabled = false;
            B_Eliminar.Enabled = false;
            tb_Id.Text = string.Empty;
            tb_Total.Text = string.Empty;
            tb_Descuento.Text = string.Empty;
            tb_IVA.Text = string.Empty;
            cb_Cliente.SelectedValue = 0;
            cb_Vendedor.SelectedValue = 0;
        }

        private async void Vendedor()
        {
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Vendedor/GetAll"))
                {
                    using (HttpContent contenido = response.Content)
                    {
                        string respuestaserver = await contenido.ReadAsStringAsync();
                        JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                        dynamic listaproductosdynamica = jsserialiser.DeserializeObject(respuestaserver);
                        List<Vendedor> listaproductos = new List<Vendedor>();
                        listaproductos.Add(new Vendedor
                        {
                            idVendedor = 0,
                            nombre = "Selecionar Vendedor"
                        });
                        foreach (var item in listaproductosdynamica)
                        {
                            listaproductos.Add(new Vendedor
                            {
                                idVendedor = item["idVendedor"],
                                nombre = item["nombre"] + " " + item["apPaterno"]
                            });
                        }
                        cb_Vendedor.DataSource = listaproductos;
                        cb_Vendedor.DisplayMember = "nombre";
                        cb_Vendedor.ValueMember = "idVendedor";
                        ven = (int)cb_Vendedor.SelectedValue;
                    }
                }
            }
        }
    }
}