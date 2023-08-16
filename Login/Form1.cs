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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {
                try
                {
                    Database data = new Database();

                    Boolean res = data.IniciarSeccion(textBox1.Text, textBox2.Text);

                    if (res)
                    {
                        local lo = new local();
                        lo.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Inicio Incorecto: ");
                    }

                }
                catch
                {
                    MessageBox.Show("Error; ");
                }
            }
            else
            {
                MessageBox.Show("Complete Los datos: ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Hide();
        }
    }
}
