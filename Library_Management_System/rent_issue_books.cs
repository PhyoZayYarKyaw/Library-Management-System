using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library_Management_System
{
    public partial class rent_issue_books : Form
    {
        MySqlConnection con = new MySqlConnection("datasource = localhost;initial catalog = 'showpj';port = 3306;username = root;password = root;CharSet = utf8mb4");
        MySqlCommand cmd = new MySqlCommand();
        DateTime today;
        String bname, classno, mname, mbarcode, returndate;
        DateTime rent;

        public rent_issue_books()
        {
            InitializeComponent();
        }

        private void rent_issue_books_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();

        }
        int day;
        //Insert
        
        int days;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Length == 13)
            {

                dispaly_book();
                this.ActiveControl = txtMember;



            }
        }

        public void dispaly_book()
        {
            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select  book_name,rent_day from book where class_number = '"+txtBarcode.Text+"'";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    textBox2.Text = dr["book_name"].ToString();
                    day = Convert.ToInt32(dr["rent_day"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            con.Close();

            
            DateTime today = DateTime.Today;
            
            DateTime rent = today.AddDays(day);

            if (rent.ToString("dddd") == "Saturday")
            {

                rent = rent.AddDays(2);
               
            }
            else if (rent.ToString("dddd") == "Sunday")
            {
                rent = rent.AddDays(1);
               
            }
           dateTimePicker1.Text = rent.ToString();








        }



        

        private void txtMember_TextChanged(object sender, EventArgs e)
        {
            if(txtMember.Text.Length == 13)
            {
                this.ActiveControl = label1;

                display_member();







            }
        }
        public void display_member()
        {
            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select  name from member where barcode = '" + txtMember.Text + "'";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    textBox3.Text = dr["name"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            library_home l = new library_home();
            l.Show();
            this.Hide();
        }

        private void txtIssueMember_TextChanged(object sender, EventArgs e)
        {
            if (txtMember.Text.Length == 13)
            {

                dispaly_member();
                this.ActiveControl = label1;


            }
        }


        public void dispaly_member()
        {
            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select  name from member where barcode = '" + txtMember.Text + "' ";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    textBox3.Text = dr["name"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            con.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            


                try
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select book_name,rent_day from book where class_number ='" + txtBarcode.Text + "'";
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        bname = dr["book_name"].ToString();
                        day = Convert.ToInt32(dr["rent_day"].ToString());
                    }

                    classno = txtBarcode.Text;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();

                try
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select name from member where barcode ='" + txtMember.Text + "'";
                    cmd.ExecuteNonQuery();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        mname = dr["name"].ToString();
                    }

                    mbarcode = txtMember.Text;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();





            //int t = Int32.Parse(s);


            DateTime today = DateTime.Today;
           
            DateTime rent = today.AddDays(day);
            if (rent.ToString("dddd") == "Saturday")
                {

                    dateTimePicker1.Value.AddDays(2);
                MessageBox.Show(dateTimePicker1.Value.ToString());

                }
                else if (rent.ToString("dddd") == "Sunday")
                {
                dateTimePicker1.Value.AddDays(1);
                MessageBox.Show(dateTimePicker1.Value.ToString());

            }

            dateTimePicker1.Show();




            //   textBox1.Text = rent.ToLongDateString();

            try
                {
                    con.Open();
                    MySqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Insert into rent(class_number,book_name,barcode,name,rent_date,return_date)values('" + classno.ToString() + "','" + bname + "','" + mbarcode + "','" + mname + "','" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "')";
                    cmd.ExecuteNonQuery();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
           
        }

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            button1.ForeColor = Color.Cyan;
        }

        private void issueExit_Click(object sender, EventArgs e)
        {
            library_home l = new library_home();
            l.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            library_home l = new library_home();
            l.Show();
            this.Hide();
        }
    }
}
