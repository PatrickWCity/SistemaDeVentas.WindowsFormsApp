using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using System.Web.Script.Serialization;

namespace WindowsFormsApp1.Views
{
    public partial class FormModoPago : Form
    {
        public FormModoPago()
        {
            InitializeComponent();
            l_ZonaMensaje.Text = string.Empty;
            Icon = Properties.Resources.Icon;
            B_Agregar.Enabled = true;
            B_Editar.Enabled = false;
            B_Eliminar.Enabled = false;
        }
        private async void B_Agregar_Click(object sender, EventArgs e)
        {
            if (tb_Nombre.TextLength == 0 && tb_Detalles.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar los datos del ModoPago a Agregar";
            }
            else if (tb_Nombre.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el nombre del ModoPago a Agregar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "nombre=" + tb_Nombre.Text;
                urlParametros += "&otroDetalles=" + tb_Detalles.Text; //temp cambiar ?
                try { 
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/ModoPago/AddModoPago" + urlParametros))
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
                            tb_Nombre.Text = string.Empty;
                            tb_Detalles.Text = string.Empty;
                        }
                    }
                }//agregar
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/ModoPago/GetAll"))
                    {
                        using (HttpContent contenido = response.Content)
                        {
                            string respuestaserver = await contenido.ReadAsStringAsync();
                            JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                            dynamic listaModoPagosdynamica = jsserialiser.DeserializeObject(respuestaserver);
                            List<ModoPago> listaModoPagos = new List<ModoPago>();
                            foreach (var item in listaModoPagosdynamica)
                            {
                                listaModoPagos.Add(new ModoPago
                                {
                                    numPago = item["numPago"],
                                    nombre = item["nombre"],
                                    otroDetalles = item["otroDetalles"]//cambiar a detalles
                                });
                            }
                            dataGridView1.DataSource = listaModoPagos;
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
            if (tb_Id.TextLength == 0 && tb_Nombre.TextLength == 0 && tb_Detalles.TextLength == 0)//cbcategoria and descripcion
            {
                l_ZonaMensaje.Text = "Debe ingresar los datos del ModoPago a Agregar";
            }
            else if (tb_Id.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el ID del ModoPago a Eliminar";
            }
            else if (!int.TryParse(tb_Id.Text, out int id))
            {
                l_ZonaMensaje.Text = "Debe ingresar un valor Entero para el ID del ModoPago a Eliminar";
            }
            else if (tb_Nombre.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el nombre del ModoPago a Agregar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "numPagoo=" + tb_Id.Text;
                urlParametros += "&nombre=" + tb_Nombre.Text;
                urlParametros += "&otroDetalles=" + tb_Detalles.Text;//detalles
                //url lista
                try { 
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/ModoPago/EditModoPago" + urlParametros))
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
                            tb_Nombre.Text = string.Empty;
                            tb_Detalles.Text = string.Empty;
                        }
                    }
                }//agregar
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/ModoPago/GetAll"))
                    {
                        using (HttpContent contenido = response.Content)
                        {
                            string respuestaserver = await contenido.ReadAsStringAsync();
                            JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                            dynamic listaModoPagosdynamica = jsserialiser.DeserializeObject(respuestaserver);
                            List<ModoPago> listaModoPagos = new List<ModoPago>();
                            foreach (var item in listaModoPagosdynamica)
                            {
                                listaModoPagos.Add(new ModoPago
                                {
                                    numPago = item["numPago"],
                                    nombre = item["nombre"],
                                    otroDetalles = item["otroDetalles"]
                                });
                            }
                            dataGridView1.DataSource = listaModoPagos;
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
                l_ZonaMensaje.Text = "Debe ingresar el ID del ModoPago a Eliminar";
            }
            else if (!int.TryParse(tb_Id.Text, out int id))
            {
                l_ZonaMensaje.Text = "Debe ingresar un valor Entero para el ID del ModoPago a Eliminar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "numPago=" + tb_Id.Text;
                //url lista
                try { 
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/ModoPago/DeleteModoPago" + urlParametros))
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
                            tb_Nombre.Text = string.Empty;
                            tb_Detalles.Text = string.Empty;
                        }
                    }
                }//agregar
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/ModoPago/GetAll"))
                    {
                        using (HttpContent contenido = response.Content)
                        {
                            string respuestaserver = await contenido.ReadAsStringAsync();
                            JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                            dynamic listaModoPagosdynamica = jsserialiser.DeserializeObject(respuestaserver);
                            List<ModoPago> listaModoPagos = new List<ModoPago>();
                            foreach (var item in listaModoPagosdynamica)
                            {
                                listaModoPagos.Add(new ModoPago
                                {
                                    numPago = item["numPago"],
                                    nombre = item["nombre"],
                                    otroDetalles = item["otroDetalles"]
                                });
                            }
                            dataGridView1.DataSource = listaModoPagos;
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
                using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/ModoPago/GetAll"))
                {
                    using (HttpContent contenido = response.Content)
                    {
                        string respuestaserver = await contenido.ReadAsStringAsync();
                        JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                        dynamic listaModoPagosdynamica = jsserialiser.DeserializeObject(respuestaserver);
                        List<ModoPago> listaModoPagos = new List<ModoPago>();
                        foreach (var item in listaModoPagosdynamica)
                        {
                            listaModoPagos.Add(new ModoPago
                            {
                                numPago = item["numPago"],
                                nombre = item["nombre"],
                                otroDetalles = item["otroDetalles"]//detalles
                            });
                        }
                        dataGridView1.DataSource = listaModoPagos;
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
                tb_Nombre.Text = row.Cells[1].Value.ToString();
                tb_Detalles.Text = (string)row.Cells[2].Value;// para nulls
                B_Agregar.Enabled = false;
                B_Editar.Enabled = true;
                B_Eliminar.Enabled = true;
            }
        }

        private void B_Restablecer_Click(object sender, EventArgs e)
        {
            B_Agregar.Enabled = true;
            B_Editar.Enabled = false;
            B_Eliminar.Enabled = false;
            tb_Id.Text = string.Empty;
            tb_Nombre.Text = string.Empty;
            tb_Detalles.Text = string.Empty;
        }
    }
}