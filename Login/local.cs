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
    public partial class local : Form
    {
        public local()
        {
            InitializeComponent();

            this.label1.Text = Database.NombreCompleto.ToString();
            this.label2.Text = Database.TipoDeUsuario.ToString();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
