using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.Views
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void B_Login_Click(object sender, EventArgs e)
        {
            FormMenu fm = new FormMenu();
            fm.Show();
        }

        private void B_Restablecer_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void B_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
