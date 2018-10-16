using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using LOGIC;
namespace BODEGA
{
    public partial class crearBodega : Form
    {

        logicaBodega dt = new logicaBodega();


        public crearBodega()
        {
            InitializeComponent();
        }


        private void encargados()
        {
            comboBox2.DataSource = dt.getEncargados();
            comboBox2.DisplayMember = "name";
        }

        private void tipos()
        {
            comboBox1.DataSource = dt.getTipo();
            comboBox1.DisplayMember = "name";
        }

        private void mostrarBodegas()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt.getBodegas();
        }

        private void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
        }


        private void crearBodega_Load(object sender, EventArgs e)
        {
            mostrarBodegas();
            encargados();
            tipos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int encargado = dt.CodEncargado(comboBox2.Text.ToString());
            int tipo = dt.CodTipo(comboBox1.Text.ToString());
            string nombre = textBox1.Text.ToString();
            string direc = textBox2.Text.ToString();
            int estado = 0;

            if (comboBox3.SelectedIndex == 0)
            {
                estado = 1;
            }
            else
            {
                estado = 0;
            }


            if (dt.createBodega(nombre, tipo, encargado, direc, estado))
            {
                MessageBox.Show("Bodega creada exitosamente!");
                mostrarBodegas();
                limpiar();
            }
            else
            {
                MessageBox.Show("Error al crear bodega");
            }
        }
    }
}
