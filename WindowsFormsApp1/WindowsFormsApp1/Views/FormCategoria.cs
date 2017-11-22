using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using System.Web.Script.Serialization;

namespace WindowsFormsApp1.Views
{
    public partial class FormCategoria : Form
    {
        public FormCategoria()
        {
            InitializeComponent();
            l_ZonaMensaje.Text = string.Empty;
        }
        private async void B_Agregar_Click(object sender, EventArgs e)
        {
            if (tb_Nombre.TextLength == 0)//cbcategoria and descripcion
            {
                l_ZonaMensaje.Text = "Debe ingresar los datos del Categoria a Agregar";
            }
            else if (tb_Nombre.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el nombre del Categoria a Agregar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "nombre=" + tb_Nombre.Text;
                urlParametros += "&descripcion=" + tb_Descripcion.Text;
                //url lista
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Categoria/AddCategoria" + urlParametros))
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
                            tb_Descripcion.Text = string.Empty;
                        }
                    }
                }//agregar
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Categoria/GetAll"))
                    {
                        using (HttpContent contenido = response.Content)
                        {
                            string respuestaserver = await contenido.ReadAsStringAsync();
                            JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                            dynamic listaproductosdynamica = jsserialiser.DeserializeObject(respuestaserver);
                            List<Categoria> listaproductos = new List<Categoria>();
                            foreach (var item in listaproductosdynamica)
                            {
                                listaproductos.Add(new Categoria
                                {
                                    idCategoria = item["idCategoria"],
                                    nombre = item["nombre"],
                                    descripcion = item["descripcion"]
                                });
                            }
                            DataGridView1.DataSource = listaproductos;
                        }
                    }
                }//get all
            }
        }
        private async void B_Editar_Click(object sender, EventArgs e)
        {
            if (tb_Id.TextLength == 0 && tb_Nombre.TextLength == 0)//cbcategoria and descripcion
            {
                l_ZonaMensaje.Text = "Debe ingresar los datos del Categoria a Agregar";
            }
            else if (tb_Id.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el ID del Categoria a Eliminar";
            }
            else if (!int.TryParse(tb_Id.Text, out int id))
            {
                l_ZonaMensaje.Text = "Debe ingresar un valor Entero para el ID del Categoria a Eliminar";
            }
            else if (tb_Nombre.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el nombre del Categoria a Agregar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "idCategoria=" + tb_Id.Text;
                urlParametros += "&nombre=" + tb_Nombre.Text;
                urlParametros += "&descripcion=" + tb_Descripcion.Text;
                //url lista
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Categoria/EditCategoria" + urlParametros))
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
                            tb_Descripcion.Text = string.Empty;
                        }
                    }
                }//agregar
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Categoria/GetAll"))
                    {
                        using (HttpContent contenido = response.Content)
                        {
                            string respuestaserver = await contenido.ReadAsStringAsync();
                            JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                            dynamic listaproductosdynamica = jsserialiser.DeserializeObject(respuestaserver);
                            List<Categoria> listaproductos = new List<Categoria>();
                            foreach (var item in listaproductosdynamica)
                            {
                                listaproductos.Add(new Categoria
                                {
                                    idCategoria = item["idCategoria"],
                                    nombre = item["nombre"],
                                    descripcion = item["descripcion"]
                                });
                            }
                            DataGridView1.DataSource = listaproductos;
                        }
                    }
                }//get all
            }
        }
        private async void B_Eliminar_Click(object sender, EventArgs e)
        {
            if (tb_Id.TextLength == 0)
            {
                l_ZonaMensaje.Text = "Debe ingresar el ID del Categoria a Eliminar";
            }
            else if (!int.TryParse(tb_Id.Text, out int id))
            {
                l_ZonaMensaje.Text = "Debe ingresar un valor Entero para el ID del Categoria a Eliminar";
            }
            else
            {
                string urlParametros = "?";
                urlParametros += "idCategoria=" + tb_Id.Text;
                //url lista
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Categoria/DeleteCategoria" + urlParametros))
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
                            tb_Descripcion.Text = string.Empty;
                        }
                    }
                }//agregar
                using (HttpClient cliente = new HttpClient())
                {
                    using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Categoria/GetAll"))
                    {
                        using (HttpContent contenido = response.Content)
                        {
                            string respuestaserver = await contenido.ReadAsStringAsync();
                            JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                            dynamic listaproductosdynamica = jsserialiser.DeserializeObject(respuestaserver);
                            List<Categoria> listaproductos = new List<Categoria>();
                            foreach (var item in listaproductosdynamica)
                            {
                                listaproductos.Add(new Categoria
                                {
                                    idCategoria = item["idCategoria"],
                                    nombre = item["nombre"],
                                    descripcion = item["descripcion"]
                                });
                            }
                            DataGridView1.DataSource = listaproductos;
                        }
                    }
                }//get all
            }
        }
        private async void B_Mostrar_Click(object sender, EventArgs e)
        {
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Categoria/GetAll"))
                {
                    using (HttpContent contenido = response.Content)
                    {
                        string respuestaserver = await contenido.ReadAsStringAsync();
                        JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                        dynamic listaproductosdynamica = jsserialiser.DeserializeObject(respuestaserver);
                        List<Categoria> listaproductos = new List<Categoria>();
                        foreach (var item in listaproductosdynamica)
                        {
                            listaproductos.Add(new Categoria
                            {
                                idCategoria = item["idCategoria"],
                                nombre = item["nombre"],
                                descripcion = item["descripcion"]
                            });
                        }
                        DataGridView1.DataSource = listaproductos;
                    }
                }
            }
            l_ZonaMensaje.Text = string.Empty;
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var row = DataGridView1.Rows[e.RowIndex];
                tb_Id.Text = row.Cells[0].Value.ToString();
                tb_Nombre.Text = row.Cells[1].Value.ToString();
                tb_Descripcion.Text = (string)row.Cells[2].Value;// para nulls
            }
        }
    }
}