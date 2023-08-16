using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Crear : Form
    {
        public Crear()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database data = new Database();
            string respuesta;

            try
            {
                if (string.IsNullOrEmpty(textBox1.Text)|| string.IsNullOrEmpty(textBox2.Text)|| string.IsNullOrEmpty(textBox3.Text)|| string.IsNullOrEmpty(textBox4.Text))
                {
                    MessageBox.Show("No puede dejar campos vacios: ");
                }
                else
                {
                    string Nombre = textBox1.Text;
                    string Apellido = textBox2.Text;
                    string Contrasena = textBox3.Text;
                    string Usuario = textBox4.Text;

                    respuesta = data.Crear(Nombre,Apellido,Contrasena,Usuario);
                    MessageBox.Show("Datos guardados corectamente: ");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
