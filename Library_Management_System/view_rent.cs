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
    public partial class view_rent : Form
    {
        MySqlConnection con = new MySqlConnection("datasource = localhost;initial catalog = 'showpj';port = 3306;username = root;password = root;CharSet = utf8mb4");
       
        public view_rent()
        {
            InitializeComponent();
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            dataGridView1.ClearSelection();
            panel2.Show();
            if (comboBox1.SelectedIndex == 0)
            {
               
                label2.Text = "Enter Member Name";

            }
            if (comboBox1.SelectedIndex == 1)
            {
                label2.Text = "Enter Book Name";

            }
        }

        private void view_rent_Load(object sender, EventArgs e)
        {
            
            panel2.Visible = false;
            //justTextBox.Visible = false;
            dataGridView1.Visible = false;
            textArea.Visible = false;
        }

        private void ptext_KeyUp(object sender, KeyEventArgs e)
        {
            int i = 0;

            //Book
            if (comboBox1.SelectedIndex == 0)
            {
                try
                {
                    dataGridView1.Visible = true;
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from book where book_name like('%" + ptext.Text + "%')";
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    i = Convert.ToInt32(dt.Rows.Count.ToString());
                    dataGridView1.DataSource = dt;

                    if (i == 0)
                    {
                        MessageBox.Show("Book Not Found");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



                con.Close();
            }

            //Member
            if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    dataGridView1.Visible = true;
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from member where name like('%" + ptext.Text + "%')";
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    i = Convert.ToInt32(dt.Rows.Count.ToString());
                    dataGridView1.DataSource = dt;

                    if (i == 0)
                    {
                        MessageBox.Show("Member Not Found");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



                con.Close();
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textArea.Visible = true;
            string s = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            textArea.Text = "No\tPerson Name\tRoll Number\tBook Number\tRent Date\tReturn Date\tRemark\n";

            if (comboBox1.SelectedIndex == 1)
            {
                // int i = 0;
                //i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());       

                try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from rent where bname = '" + s + "' ";


                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        textArea.AppendText(dr["Id"].ToString() + " \t");
                        textArea.AppendText(dr["class_number"].ToString() + " \t");
                        textArea.AppendText(dr["book_name"].ToString() + " \t");
                        textArea.AppendText(dr["barcode"].ToString() + " \t");
                        textArea.AppendText(dr["name"].ToString() + " \t");
                        textArea.AppendText(dr["rent"].ToString() + " \t");
                        textArea.AppendText(dr["return"].ToString() + " \n");

                    }




                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (comboBox1.SelectedIndex == 0)
            {
                textArea.Visible = true;
                string t = dataGridView1.SelectedRows[0].Cells[1].ToString();

                textArea.Text = "No \t Person Name \t Roll Number \t Rent Date \t Return Date \t Remark \n";

                if (comboBox1.SelectedIndex == 1)
                {
                    int i = 0;
                    i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

                    try
                    {
                        con.Open();
                        MySqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select * from rent_list where pname = " + t + "";
                        cmd.ExecuteNonQuery();

                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);


                        foreach (DataRow dr in dt.Rows)
                        {
                            string no = dr["No"].ToString();
                            string name = dr["pname"].ToString();
                            string roll = dr["roll"].ToString();
                            string bname = dr["bname"].ToString();
                            string rdate = dr["rent_date"].ToString();
                            string redate = dr["return_date"].ToString();
                            string remark = dr["remark"].ToString();
                            textArea.AppendText(no + "\t" + name + "\t" + roll + "\t" + bname + "\t" + rdate + "\t" + redate + "\t" + remark + "\n");

                        }

                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }



            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            library_home l = new library_home();
            l.Show();
            this.Hide();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            int i = 0;

            //Book
            if (comboBox1.SelectedIndex == 0)
            {
                try
                {
                    dataGridView1.Visible = true;
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from person where pname like('%" + ptext.Text + "%')";
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    i = Convert.ToInt32(dt.Rows.Count.ToString());
                    dataGridView1.DataSource = dt;

                    if (i == 0)
                    {
                        MessageBox.Show("Book Not Found");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



                con.Close();
            }

            //Member
            if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    dataGridView1.Visible = true;
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from person where pname like('%" + ptext.Text + "%')";
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    i = Convert.ToInt32(dt.Rows.Count.ToString());
                    dataGridView1.DataSource = dt;

                    if (i == 0)
                    {
                        MessageBox.Show("Member Not Found");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



                con.Close();
            }
        }

        private void textArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
