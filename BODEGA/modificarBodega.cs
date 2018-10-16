using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LOGIC;

namespace BODEGA
{
    public partial class modificarBodega : Form
    {

        logicaBodega dt = new logicaBodega();

        public modificarBodega()
        {
            InitializeComponent();
        }


        void tipos()
        {
            comboBox1.DataSource = dt.getTipo();
            comboBox1.DisplayMember = "name";
            comboBox1.SelectedIndex = -1;
        }

        void encargados()
        {
            comboBox2.DataSource = dt.getEncargados();
            comboBox2.DisplayMember = "name";
            comboBox2.SelectedIndex = -1;
        }

        public void currentTipo(string reference)
        {

            foreach (var item in comboBox1.Items)
            {


                string current = ((DataRowView)item)["name"].ToString();
                int index = comboBox1.Items.IndexOf(item);

                if (current == reference)
                {
                    comboBox1.SelectedIndex = index;
                }

            }

        }


        public void currentEncargado(string reference)
        {

            foreach (var item in comboBox2.Items)
            {


                string current = ((DataRowView)item)["name"].ToString();
                int index = comboBox2.Items.IndexOf(item);

                if (current == reference)
                {
                    comboBox2.SelectedIndex = index;
                }

            }

        }


        public void currentEstado(string reference)
        {

            if (Equals(reference, "ACTIVO"))
            {
                comboBox3.SelectedIndex = 0;

            }
            else if (Equals(reference, "INACTIVO"))
            {
                comboBox3.SelectedIndex = 1;
            }

        }



        public void showBodega()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt.getBodegas();
        }


        private void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            textBox3.Focus();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
        }


        private void modificarBodega_Load(object sender, EventArgs e)
        {
            showBodega();
            tipos();
            encargados();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(textBox1.Text.ToString());
            string nombre = textBox2.Text.ToString();
            int tipo = dt.CodTipo(comboBox1.Text.ToString());
            int encargado = dt.CodEncargado(comboBox2.Text.ToString());
            string ubicacion = textBox4.Text.ToString();
            int estado = 0;

            if (Equals(comboBox3.Text.ToString(), "ACTIVO"))
            {
                estado = 1;
            }
            else
            {
                estado = 0;
            }

            if (dt.updateBodega(codigo, nombre, tipo, encargado, ubicacion, estado))
            {
                MessageBox.Show("Bodega actualizada correctamente!");
                limpiar();
                showBodega();
            }
            else
            {
                MessageBox.Show("Brror al actualizar bodega!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchBodega frmse = new searchBodega();
            frmse.Show();
            this.Hide();
        }
    }
}
