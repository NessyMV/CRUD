using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace crud1
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        public void llenarcombo()
        {

            SqlConnection con;
            SqlCommand cmd;
            string cadena = "";
            SqlDataReader datos;
            con = new SqlConnection("Data Source=Victoria-PC;Initial Catalog=SITIO;Integrated Security=True");
            con.Open();
            comboBox1.Items.Clear();
            cadena = "select id from biblioteki";
            cmd = new SqlCommand(cadena, con);
            datos = cmd.ExecuteReader();
            while (datos.Read())
            {
                comboBox1.Items.Add(datos.GetInt32(0).ToString());

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            llenarcombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (ServiceReference1.IfuuncionesClient cliente = new ServiceReference1.IfuuncionesClient())
            {
                cliente.Create(textBox1.Text, textBox2.Text, textBox3.Text,textBox4.Text, textBox5.Text);
                MessageBox.Show("REGISTRO GUARDADO");
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            llenarcombo();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] most = new string[4];
            using (ServiceReference1.IfuuncionesClient cliente = new ServiceReference1.IfuuncionesClient())
            {
                most = cliente.Read(comboBox1.Text);
            }

            textBox1.Text = most[0];
            textBox2.Text = most[1];
            textBox3.Text = most[2];
            textBox4.Text = most[3];
            textBox5.Text = most[4];
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] most = new string[5];
            using (ServiceReference1.IfuuncionesClient cliente = new ServiceReference1.IfuuncionesClient())
            {
                most = cliente.Read(textBox1.Text);
            }
            textBox1.Text = most[0];
            textBox2.Text = most[1];
            textBox3.Text = most[2];
            textBox4.Text = most[3];
            textBox5.Text = most[4];
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            using (ServiceReference1.IfuuncionesClient cliente = new ServiceReference1.IfuuncionesClient())
            {
                if (cliente.delete(textBox1.Text))
                {

                    MessageBox.Show("datos de registro eliminado");

                }
                else
                {
                    MessageBox.Show("datos eliminados");
                }


                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                llenarcombo();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (ServiceReference1.IfuuncionesClient cliente = new ServiceReference1.IfuuncionesClient())
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""&& textBox4.Text != ""&& textBox5.Text != "" )
                {
                    cliente.update(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                    MessageBox.Show("DATOS  ACTUALIZADOS");

                }
                else
                {
                    MessageBox.Show("intente de nuevo");
                }
                llenarcombo();
                textBox1.Clear();
                 textBox2.Clear();
                 textBox3.Clear();
                 textBox4.Clear();
                 textBox5.Clear();
            }
            
        }
    }
}
