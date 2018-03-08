using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void bntSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnHotel_Click(object sender, EventArgs e)
        {
            this.Hide();
            Crud_Hoteles ventana = new Crud_Hoteles();
            ventana.Show();

        }
    }
}
