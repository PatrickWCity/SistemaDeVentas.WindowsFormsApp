using System;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            label3.Text = "";
            Icon = Properties.Resources.Icon;
        }

        private async void B_Login_Click(object sender, EventArgs e)
        {

            if (textBox1.TextLength == 0 && textBox2.TextLength == 0)
            {
                label3.Text = "Debe Ingresar el Correo y la clave para Iniciar Session";
            }
            else if (textBox1.TextLength == 0)
            {
                label3.Text = "Debe ingresar el Correo";
            }
            else if (textBox2.TextLength == 0)
            {
                label3.Text = "Debe ingresar la Clave";
            }
            else
            {

                string urlParametros = "?";
                urlParametros += "email=" + textBox1.Text;
                urlParametros += "&pass=" + textBox2.Text;
                //url lista
                try
                {
                    using (HttpClient cliente = new HttpClient())
                    {
                        using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Login/Iniciar" + urlParametros))
                        {
                            using (HttpContent contenido = response.Content)
                            {
                                string respuestaserver = await contenido.ReadAsStringAsync();
                                JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                                dynamic dynamic = jsserialiser.DeserializeObject(respuestaserver);


                                foreach (var item in dynamic)
                                {
                                    label3.Text = item.Value;
                                }
                            }
                        }
                    }//agregar
                    if (label3.Text == "ok")
                    {
                        FormMenu fm = new FormMenu();
                        fm.Show();
                        Close();

                    }
                    else
                    {
                    }
                }
                catch
                {
                    label3.Text = "Error de Conexión!";
                }
            }
        }

        private void B_Restablecer_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            label3.Text = string.Empty;
        }

        private void B_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (textBox1.TextLength == 0 && textBox2.TextLength == 0)
                {
                    label3.Text = "Debe Ingresar el Correo y la clave para Iniciar Session";
                }
                else if (textBox1.TextLength == 0)
                {
                    label3.Text = "Debe ingresar el Correo";
                }
                else if (textBox2.TextLength == 0)
                {
                    label3.Text = "Debe ingresar la Clave";
                }
                else
                {

                    string urlParametros = "?";
                    urlParametros += "email=" + textBox1.Text;
                    urlParametros += "&pass=" + textBox2.Text;
                    //url lista
                    using (HttpClient cliente = new HttpClient())
                    {
                        using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Login/Iniciar" + urlParametros))
                        {
                            using (HttpContent contenido = response.Content)
                            {
                                string respuestaserver = await contenido.ReadAsStringAsync();
                                JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                                dynamic dynamic = jsserialiser.DeserializeObject(respuestaserver);


                                foreach (var item in dynamic)
                                {
                                    label3.Text = item.Value;
                                }
                            }
                        }
                    }//agregar
                    if (label3.Text == "ok")
                    {
                        FormMenu fm = new FormMenu();
                        fm.Show();
                        Close();

                    }
                    else
                    {
                    }
                }
            }
        }

        private async void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (textBox1.TextLength == 0 && textBox2.TextLength == 0)
                {
                    label3.Text = "Debe Ingresar el Correo y la clave para Iniciar Session";
                }
                else if (textBox1.TextLength == 0)
                {
                    label3.Text = "Debe ingresar el Correo";
                }
                else if (textBox2.TextLength == 0)
                {
                    label3.Text = "Debe ingresar la Clave";
                }
                else
                {

                    string urlParametros = "?";
                    urlParametros += "email=" + textBox1.Text;
                    urlParametros += "&pass=" + textBox2.Text;
                    //url lista
                    using (HttpClient cliente = new HttpClient())
                    {
                        using (HttpResponseMessage response = await cliente.GetAsync("http://localhost:58327/Login/Iniciar" + urlParametros))
                        {
                            using (HttpContent contenido = response.Content)
                            {
                                string respuestaserver = await contenido.ReadAsStringAsync();
                                JavaScriptSerializer jsserialiser = new JavaScriptSerializer();
                                dynamic dynamic = jsserialiser.DeserializeObject(respuestaserver);


                                foreach (var item in dynamic)
                                {
                                    label3.Text = item.Value;
                                }
                            }
                        }
                    }//agregar
                    if (label3.Text == "ok")
                    {
                        FormMenu fm = new FormMenu();
                        fm.Show();
                        Close();

                    }
                    else
                    {
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:58327/Registrar");
        }
    }
}
