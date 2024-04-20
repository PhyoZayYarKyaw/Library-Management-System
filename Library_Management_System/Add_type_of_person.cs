using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library_Management_System
{
    public partial class Add_type_of_person : Form
    {
        MySqlConnection con = new MySqlConnection("datasource = localhost;initial catalog = 'showpj';port = 3306;username = root;password = root;CharSet = utf8mb4");
        MySqlCommand cmd;
        public Add_type_of_person()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "insert into person_type values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "' )   ";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted");
                con.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
            catch (Exception es)
            {
                MessageBox.Show(es.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            library_home l = new library_home();
            l.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
