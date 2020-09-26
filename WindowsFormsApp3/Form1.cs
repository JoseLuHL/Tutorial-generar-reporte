using CrystalDecisions.ReportAppServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        JosephTutos_PedidosEntities JosephTutos;
        private async void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("Todos");
            comboBox2.Items.Add(2);
            comboBox2.Items.Add(4);
            comboBox2.Items.Add(6);
            comboBox2.Items.Add(8);
            comboBox2.Items.Add(10);

            JosephTutos = new JosephTutos_PedidosEntities();
            var sp = JosephTutos.SP_Clientes("");

            clientes = new List<cliente>();
            clientes = await JosephTutos.cliente.ToListAsync();

            comboBox1.DataSource = clientes;
            comboBox1.DisplayMember = "clie_nombre";
            comboBox1.ValueMember = "clie_id";
            //comboBox1.Items.Add("Todos");
        }

        List<cliente> clientes;
        private async void button1_Click(object sender, EventArgs e)
        {
                await CargarClientes(null, 0, checkBox1.Checked, checkBox2.Checked);
        }


        async Task CargarClientes(int? id, int cantidadRegistros, bool tel, bool direccion)
        {
            JosephTutos = new JosephTutos_PedidosEntities();
            var clientesBD = await JosephTutos.cliente.ToListAsync();
            if (string.IsNullOrEmpty(id.ToString()))
            {
                clientes = clientesBD;
            }
            else
            {
                clientes = clientesBD.Where(s => s.clie_id == id).ToList();
            }

            if (cantidadRegistros > 0)
            {
                clientes = clientesBD.Take(cantidadRegistros).ToList();
            }

            if (tel)
            {
                clientes.ForEach(s => s.clie_telefono = "");
            }

            if (direccion)
            {
                clientes.ForEach(s => s.clie_direccion = "");
            }

            var cry = new CrystalReport1();

            this.crystalReportViewer1.ReportSource = cry;

            cry.SetDataSource(clientes);

            this.crystalReportViewer1.RefreshReport();
            
            clientesBD = null;
            clientes = null;
        }


        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var valor = comboBox2.Text;
            if (valor == "Todos")
            {
                valor = "0";
            }
            await CargarClientes(null, int.Parse(valor), checkBox1.Checked, checkBox2.Checked);
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "Todos")
                {
                    await CargarClientes(null, 0, checkBox1.Checked, checkBox2.Checked);
                    return;
                }

                var valor = int.Parse(comboBox1.SelectedValue.ToString());
                await CargarClientes(valor, 0, checkBox1.Checked, checkBox2.Checked);
            }
            catch (Exception)
            {

            }
           
        }

        private async void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            await CargarClientes(0, 0, checkBox1.Checked, checkBox2.Checked);
        }

        private async void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            await CargarClientes(0, 0, checkBox1.Checked, checkBox2.Checked);
        }
    }
}
