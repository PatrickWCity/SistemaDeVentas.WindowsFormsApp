using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using System.Web.Script.Serialization;

namespace WindowsFormsApp1.Views
{
    public partial class FormCliente : Form
    {
        public FormCliente()
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
            if (tb_Nombre.TextLength == 0 )//cbcategoria and descripcion
            {
                l_ZonaMensaje.Text = "Debe ingresar los datos del Cliente a Agregar";
            }
            else if (tb_Nombre.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el nombre del Cliente a Agregar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "nombre=" + tb_Nombre.Text;
                urlParametros += "&apPaterno=" + tb_ApellidoPaterno.Text;
                urlParametros += "&apMaterno=" + tb_ApellidoMaterno.Text;
                urlParametros += "&direccion=" + tb_Direccion.Text;
                urlParametros += "&telefono=" + tb_Telefono.Text;
                urlParametros += "&rut=" + tb_Rut.Text;
                //url lista
                try { 
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Cliente/AddCliente" + urlParametros))
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
                            tb_ApellidoPaterno.Text = string.Empty;
                            tb_ApellidoMaterno.Text = string.Empty;
                            tb_Direccion.Text = string.Empty;
                            tb_Telefono.Text = string.Empty;
                            tb_Rut.Text = string.Empty;
                        }
                    }
                }//agregar
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
                            foreach (var item in listaproductosdynamica)
                            {
                                listaproductos.Add(new Cliente
                                {
                                    idCliente = item["idCliente"],
                                    nombre = item["nombre"],
                                    apPaterno = item["apPaterno"],
                                    apMaterno = item["apMaterno"],
                                    direccion = item["direccion"],
                                    telefono = item["telefono"],
                                    rut = item["rut"]
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
            if (tb_Id.TextLength == 0 && tb_Nombre.TextLength == 0)//cbcategoria and descripcion
            {
                l_ZonaMensaje.Text = "Debe ingresar los datos del Cliente a Agregar";
            }
            else if (tb_Id.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el ID del Cliente a Eliminar";
            }
            else if (!int.TryParse(tb_Id.Text, out int id))
            {
                l_ZonaMensaje.Text = "Debe ingresar un valor Entero para el ID del Cliente a Eliminar";
            }
            else if (tb_Nombre.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el nombre del Cliente a Agregar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "idCliente=" + tb_Id.Text;
                urlParametros += "&nombre=" + tb_Nombre.Text;
                urlParametros += "&apPaterno=" + tb_ApellidoPaterno.Text;
                urlParametros += "&apMaterno=" + tb_ApellidoMaterno.Text;
                urlParametros += "&direccion=" + tb_Direccion.Text;
                urlParametros += "&telefono=" + tb_Telefono.Text;
                urlParametros += "&rut=" + tb_Rut.Text;
                //url lista
                try { 
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Cliente/EditCliente" + urlParametros))
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
                            tb_ApellidoPaterno.Text = string.Empty;
                            tb_ApellidoMaterno.Text = string.Empty;
                            tb_Direccion.Text = string.Empty;
                            tb_Telefono.Text = string.Empty;
                            tb_Rut.Text = string.Empty;
                        }
                    }
                }//agregar
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
                            foreach (var item in listaproductosdynamica)
                            {
                                listaproductos.Add(new Cliente
                                {
                                    idCliente = item["idCliente"],
                                    nombre = item["nombre"],
                                    apPaterno = item["apPaterno"],
                                    apMaterno = item["apMaterno"],
                                    direccion = item["direccion"],
                                    telefono = item["telefono"],
                                    rut = item["rut"]
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
                l_ZonaMensaje.Text = "Debe ingresar el ID del Cliente a Eliminar";
            }
            else if (!int.TryParse(tb_Id.Text, out int id))
            {
                l_ZonaMensaje.Text = "Debe ingresar un valor Entero para el ID del Cliente a Eliminar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "idCliente=" + tb_Id.Text;
                //url lista
                try { 
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Cliente/DeleteCliente" + urlParametros))
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
                            tb_ApellidoPaterno.Text = string.Empty;
                            tb_ApellidoMaterno.Text = string.Empty;
                            tb_Direccion.Text = string.Empty;
                            tb_Telefono.Text = string.Empty;
                            tb_Rut.Text = string.Empty;
                        }
                    }
                }//agregar
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
                            foreach (var item in listaproductosdynamica)
                            {
                                listaproductos.Add(new Cliente
                                {
                                    idCliente = item["idCliente"],
                                    nombre = item["nombre"],
                                    apPaterno = item["apPaterno"],
                                    apMaterno = item["apMaterno"],
                                    direccion = item["direccion"],
                                    telefono = item["telefono"],
                                    rut = item["rut"]
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
                using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Cliente/GetAll"))
                {
                    using (HttpContent contenido = response.Content)
                    {
                        string respuestaserver = await contenido.ReadAsStringAsync();
                        JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                        dynamic listaproductosdynamica = jsserialiser.DeserializeObject(respuestaserver);
                        List<Cliente> listaproductos = new List<Cliente>();
                        foreach (var item in listaproductosdynamica)
                        {
                            listaproductos.Add(new Cliente
                            {
                                idCliente = item["idCliente"],
                                nombre = item["nombre"],
                                apPaterno = item["apPaterno"],
                                apMaterno = item["apMaterno"],
                                direccion = item["direccion"],
                                telefono = item["telefono"],
                                rut = item["rut"]
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
                tb_Nombre.Text = row.Cells[1].Value.ToString();
                tb_ApellidoPaterno.Text = (string)row.Cells[2].Value;// para nulls
                tb_ApellidoMaterno.Text = (string)row.Cells[3].Value;// para nulls
                tb_Direccion.Text = (string)row.Cells[4].Value;// para nulls
                tb_Telefono.Text = (string)row.Cells[5].Value;// para nulls
                tb_Rut.Text = (string)row.Cells[6].Value;// para nulls
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
            tb_ApellidoPaterno.Text = string.Empty;
            tb_ApellidoMaterno.Text = string.Empty;
            tb_Direccion.Text = string.Empty;
            tb_Telefono.Text = string.Empty;
            tb_Rut.Text = string.Empty;
        }
    }
}