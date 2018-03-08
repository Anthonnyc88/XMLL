using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Datos;

namespace Interfaz
{
    public partial class Crud_Hoteles : Form
    {
        Hotel conectar = new Hotel();

        public static ArrayList lista1 = new ArrayList();
        public static ArrayList lista2 = new ArrayList();
        public static ArrayList lista3 = new ArrayList();
        public static ArrayList lista4 = new ArrayList();
        public static ArrayList lista5 = new ArrayList();
        public static ArrayList lista6 = new ArrayList();

        string direccion = "";

        public Crud_Hoteles()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void Crud_Hoteles_Load(object sender, EventArgs e)
        {

        }


        public  void Limpiar()
        {
            txtIdentificador.Clear();
            txtNombre.Clear();
            txtHabitaciones.Clear();
           Foto.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu mostrar = new Menu();
            mostrar.Show();

        }

        private void bntGuardar_Click(object sender, EventArgs e)
        {



            if (txtIdentificador.Text == "")
            {
                MessageBox.Show("Ingrese un Identificador!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtNombre.Text == "")
            {
                MessageBox.Show("Ingrese un Nombre!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (direccion == null)
            {
                MessageBox.Show("Ingrese un Foto!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtHabitaciones.Text == "")
            {
                MessageBox.Show("Ingrese Habitaciones!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                lista1.Add(txtIdentificador.Text);
                lista2.Add(txtNombre.Text);
                lista3.Add(direccion);
                lista4.Add(txtHabitaciones.Text);
                lista5.Add(comboPaises.SelectedItem.ToString());
                lista6.Add(comboLugares.SelectedItem.ToString());

               conectar._Añadir(txtIdentificador.Text, txtNombre.Text, direccion, txtHabitaciones.Text, comboPaises.SelectedItem.ToString(), comboLugares.SelectedItem.ToString());

                MessageBox.Show("Se ha guardado correctamente!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Limpiar();



            }
        }

        private void Foto_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    Foto.Image = Image.FromFile(imagen);
                    direccion = imagen;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido" + ex);
            }
        }
    }
}
