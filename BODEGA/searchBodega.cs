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
    public partial class searchBodega : Form
    {
        logicaBodega dt = new logicaBodega();


        public searchBodega()
        {
            InitializeComponent();
        }

        private void showBodega()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt.getBodegas();
        }

        private void filtro(string name)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt.filtBodegas(name);
        }




        private void getCurrentRow()
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;

            string cod = "";
            int referenceCode = 0;
            string name = "";
            string tipo = "";
            string direccion = "";
            string encargado = "";
            string estado = "";

            cod = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            referenceCode = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[0].Value.ToString());
            name = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            tipo = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            encargado = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
            direccion = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
            estado = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();

            modificarBodega frm = new modificarBodega();
            frm.Show();
            frm.textBox1.Text = cod;
            frm.textBox2.Text = name;
            frm.currentTipo(tipo);
            frm.currentEncargado(encargado);
            frm.currentEstado(estado);
            frm.textBox4.Text = direccion;
            frm.showBodega();

            this.Dispose();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getCurrentRow();
        }

        private void searchBodega_Load(object sender, EventArgs e)
        {
            showBodega();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filtro(textBox1.Text.ToString());
        }
    }
}
