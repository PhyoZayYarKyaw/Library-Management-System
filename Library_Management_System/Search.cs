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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("datasource = localhost;initial catalog = 'showpj';port = 3306;username = root;password = root;CharSet = utf8mb4");
        MySqlCommand cmd = new MySqlCommand();


        private void view_books_members_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            dataGridView1.Hide();
            panel3.Hide();
            radioButton1.Select();
            

           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Show();
            if (comboBox1.SelectedIndex == 0)
            {
                
                label1.Text = "Enter Book Name";
                panel1.Show();
                radioButton1.Show();
                radioButton2.Show();
                radioButton1.Text = "Search with book name";
                radioButton2.Text = "Search with Author name";
                
               

            }
            if (comboBox1.SelectedIndex == 1)
            {
                panel1.Show();
                radioButton1.Hide();
                radioButton2.Hide();
                label1.Text = " Enter Member Name :";
                

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Show();
            //Book
            if (comboBox1.SelectedIndex == 0)
            {
                int i = 0;
                try
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from book where book_name like('%" + textBox1.Text + "%')";
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
                int i = 0;
                try
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from member where name like('%" + textBox1.Text + "%')";
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

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Show();
            //Book
            if (comboBox1.SelectedIndex == 0)
            {
                int i = 0;
                try
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from book where book_name like('%" + textBox1.Text + "%')";
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
            if (comboBox1.SelectedIndex == 0)
            {
                int i = 0;
                try
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from member where name like('%" + textBox1.Text + "%')";
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


        //keyup

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            panel1.Show();

            //book
            if (comboBox1.SelectedIndex == 0)
            {
                try
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from book where book_name like('%" + textBox1.Text + "%')";
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }




                con.Close();
            }

            //member
            if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from member where name like('%" + textBox1.Text + "%')";
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }




                con.Close();
            }


        }



        //textbox2_keyup
        

           

        
        public void dispaly_book()
        {
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select date,author,book_name,publisher,edition,year,price,how_to_get,rent_day,remark from book";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            con.Close();
        }

        //Delete Button Click
        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = " Enter Book Name :";
            dataGridView1.ClearSelection();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = " Enter Author Name :";
            dataGridView1.ClearSelection();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            library_home l = new library_home();
            l.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;
            int i = 0;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select date,author,book_name,publisher,edition,year,price,how_to_get,rent_day,remark from book where no = " + i + "";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {

                    date.Value = Convert.ToDateTime(dr["date"].ToString());
                    author.Text = dr["author"].ToString();
                    book_name.Text = dr["book_name"].ToString();
                    publisher.Text = dr["publisher"].ToString();
                    edition.Text = dr["edition"].ToString();
                    year.Text = dr["year"].ToString();
                    price.Text = dr["price"].ToString();

                    how.Text = dr["how_to_get"].ToString();
                    no_of_day.Text = dr["rent_day"].ToString();
                    remark.Text = dr["remark"].ToString();
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            con.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            try
            {
               
               

                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update book set date ='" + date.Value + "', author='" + author.Text + "' ,book_name = '" + book_name.Text + "', publisher = '" + publisher.Text + "', edition ='" + edition.Text + "', year= '" + year.Text + "',price = " + price.Text + " , how_to_get = '" + how.Text + "' , rent_day = '" + no_of_day.Text + "', remark = '" + remark.Text + "' where no = " + i + " ";
                cmd.ExecuteNonQuery();
                con.Close();
                dispaly_book();
                MessageBox.Show("Updated Successfully");
                panel3.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int i = 0;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());

            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from book where no = " + i + " ";
                cmd.ExecuteNonQuery();
                con.Close();
                dispaly_book();
                MessageBox.Show("Deleted Successfully");
                panel3.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyUp_1(object sender, KeyEventArgs e)
        {
           
                panel1.Show();

            //book
            if (comboBox1.SelectedIndex == 0)
            {
                if (radioButton1.Checked == true)
                {
                    try
                    {
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select * from book where book_name like('%" + textBox1.Text + "%')";
                        cmd.ExecuteNonQuery();

                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }




                    con.Close();
                }
            }
            if (radioButton2.Checked == true)
            {
                try
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from book where author like('%" + textBox1.Text + "%')";
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }




                con.Close();
            }

                //member
                if (comboBox1.SelectedIndex == 1)
                {
                    try
                    {
                        con.Open();
                        cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select * from member where name like('%" + textBox1.Text + "%')";
                        cmd.ExecuteNonQuery();

                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }




                    con.Close();
                
            }
        }
    }
}

