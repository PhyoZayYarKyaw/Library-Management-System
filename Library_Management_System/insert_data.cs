using System;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing;
using System.Linq;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Library_Management_System
{
    public partial class insert_data : Form
    {
        MySqlConnection con = new MySqlConnection("datasource = localhost;initial catalog = 'showpj';port = 3306;username = root;password = root;CharSet = utf8mb4");
        MySqlCommand cmd;
        Bitmap bitmap;
        String classno; int s;
        public insert_data()
        {
            InitializeComponent();
        }

        String t; String b;

        private void button1_Click(object sender, EventArgs e)
        {

            
          
            panel1.Show();
            panel2.Hide();
        }




        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                //to make class number





                cmd.CommandText = "insert into book(date,author,book_name,publisher,edition,year,price,second_summary,class_number,how_to_get,rent_day,remark) values('" + dateTimePicker1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "'," + textBox6.Text + "," + textBox7.Text + ",'" + comboBox2.SelectedText + "','" + textBox8.Text + "','" + textBox9.Text + "'," + textBox10.Text + ", '" + textBox11.Text + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                pictureBox2.Hide();

                MessageBox.Show("Inserted Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

           
            panel2.Show();
            panel1.Hide();

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            AutoScroll = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            library_home l = new library_home();
            l.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            comboBox2.Items.Clear();

            if (comboBox1.SelectedItem == "Computer science,information & general works")
            {
                comboBox2.Text = ("");
                textBox1.Text = ("");
                comboBox2.Items.Add("Computer science,knowledge & systems");
                comboBox2.Items.Add("Bibliographies");
                comboBox2.Items.Add("Library & information sciences");
                comboBox2.Items.Add("Encyclopedias & books of facts");
                comboBox2.Items.Add("[Unassigned]");
                comboBox2.Items.Add("Magazines,journals & serials");
                comboBox2.Items.Add("Associations,organizations & museums");
                comboBox2.Items.Add("News media,journalism & publishing");
                comboBox2.Items.Add("Quotations");
                comboBox2.Items.Add("Manuscripts & rare books");

            }


            else if (comboBox1.SelectedItem == "Philosophy & psychology")
            {
                comboBox2.Text = ("");
                textBox1.Text = ("");
                comboBox2.Items.Add("Philosophy");
                comboBox2.Items.Add("Metaphysics");
                comboBox2.Items.Add("Epistemology");
                comboBox2.Items.Add("Parapsychology & occultism");
                comboBox2.Items.Add("Philosophical");
                comboBox2.Items.Add("Psychology");
                comboBox2.Items.Add("Logic");
                comboBox2.Items.Add("Ethics ");
                comboBox2.Items.Add("Ancient,medieval & eastern philosophy");
                comboBox2.Items.Add("Modern western philosophy ");

            }
            else if (comboBox1.SelectedItem == "Religion")
            {
                comboBox2.Text = ("");
                textBox1.Text = ("");
                comboBox2.Items.Add("Religion");
                comboBox2.Items.Add("Philosophy & theory of religion");
                comboBox2.Items.Add("The Bible");
                comboBox2.Items.Add("Christianity & Christian theology");
                comboBox2.Items.Add("Christian practice & observance");
                comboBox2.Items.Add("Christian pastoral practice & religious orders");
                comboBox2.Items.Add("Christian organization,social work & worship");
                comboBox2.Items.Add("History of Christianity");
                comboBox2.Items.Add("Christian denominations");
                comboBox2.Items.Add("Other religious");

            }
            else if (comboBox1.SelectedItem == "Social sciences")
            {
                comboBox2.Text = ("");
                textBox1.Text = ("");
                comboBox2.Items.Add("Social science,sociology & anthropology");
                comboBox2.Items.Add("Statistics");
                comboBox2.Items.Add("Political science");
                comboBox2.Items.Add("Economics");
                comboBox2.Items.Add("Law");
                comboBox2.Items.Add("Public administration & military science");
                comboBox2.Items.Add("social problem & social services");
                comboBox2.Items.Add("education");
                comboBox2.Items.Add("Commerce,commmunication & transportation");
                comboBox2.Items.Add("Customs,etiquette & folklore");

            }
            else if (comboBox1.SelectedItem == "Language")
            {
                comboBox2.Text = ("");
                textBox1.Text = ("");
                comboBox2.Items.Add("Language");
                comboBox2.Items.Add("Linguistics");
                comboBox2.Items.Add("English & Old English Languages");
                comboBox2.Items.Add("German & related languages");
                comboBox2.Items.Add("French & related laguages");
                comboBox2.Items.Add("Italian,Romanian & related laguages");
                comboBox2.Items.Add("Spanish & Portuguese languages");
                comboBox2.Items.Add("Latin & Italic languages");
                comboBox2.Items.Add("Classical & modern Greek languages");
                comboBox2.Items.Add("Other languages");
            }
            else if (comboBox1.SelectedItem == "Science")
            {
                comboBox2.Text = ("");
                textBox1.Text = ("");
                comboBox2.Items.Add("Science");
                comboBox2.Items.Add("Mathematics");
                comboBox2.Items.Add("Astronomy");
                comboBox2.Items.Add("Physics");
                comboBox2.Items.Add("Chemistry");
                comboBox2.Items.Add("Earth sciences & geology");
                comboBox2.Items.Add("Fossils & prehistoric life");
                comboBox2.Items.Add("Life sciences;biology");
                comboBox2.Items.Add("plants(Botany)");
                comboBox2.Items.Add("Animals(Zoology)");
            }
            else if (comboBox1.SelectedItem == "Technology")
            {
                comboBox2.Text = ("");
                textBox1.Text = ("");
                comboBox2.Items.Add("Technilogy");
                comboBox2.Items.Add("Medicine & health");
                comboBox2.Items.Add("Engineering");
                comboBox2.Items.Add("Agriculture");
                comboBox2.Items.Add("Home & family management");
                comboBox2.Items.Add("Management & public relations");
                comboBox2.Items.Add("Chemical engineering");
                comboBox2.Items.Add("Manufacturing");
                comboBox2.Items.Add("Manufacture for specific uses");
                comboBox2.Items.Add("Building & construction");
            }


            else if (comboBox1.SelectedItem == "Arts & recreation")
            {
                comboBox2.Text = ("");
                textBox1.Text = ("");
                comboBox2.Items.Add("Arts");
                comboBox2.Items.Add("Landscaping & area planning");
                comboBox2.Items.Add("Architecture");
                comboBox2.Items.Add("Sculpture,ceramics & metalwork");
                comboBox2.Items.Add("Drawing & decorative arts");
                comboBox2.Items.Add("Painting");
                comboBox2.Items.Add("Graphic arts");
                comboBox2.Items.Add("Photography & computer art");
                comboBox2.Items.Add("Music");
                comboBox2.Items.Add("sports,games & entertainment");
            }
            else if (comboBox1.SelectedItem == "Literature")
            {
                comboBox2.Text = ("");
                textBox1.Text = ("");
                comboBox2.Items.Add("Literature,rhetoric & criticism");
                comboBox2.Items.Add("American literature in English");
                comboBox2.Items.Add("English & Old Engilsh literatures");
                comboBox2.Items.Add("German & related literatures");
                comboBox2.Items.Add("French & related litteratures");
                comboBox2.Items.Add("Italian,Romanian & related literatures");
                comboBox2.Items.Add("Spanish&Potyuguese literatures");
                comboBox2.Items.Add("Latin & Italic literatures");
                comboBox2.Items.Add("Classical & modern Greek literatures");
                comboBox2.Items.Add("Other literatures");
            }
            else if (comboBox1.SelectedItem == "History & geography")
            {
                comboBox2.Text = ("");
                textBox1.Text = ("");
                comboBox2.Items.Add("History");
                comboBox2.Items.Add("Geography & travel");
                comboBox2.Items.Add("Biography & genealogy");
                comboBox2.Items.Add("History of ancient world(to ca.499)");
                comboBox2.Items.Add("History of Europe");
                comboBox2.Items.Add("History of Asia");
                comboBox2.Items.Add("History of Africa");
                comboBox2.Items.Add("History of North America");
                comboBox2.Items.Add("History of South America");
                comboBox2.Items.Add("History of other areas");
            }





        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {



            if (comboBox2.SelectedItem == "Computer science,knowledge & systems")
            {

                t = "000";
            }
            else if (comboBox2.SelectedItem == "Bibliographies")
            {

                t = "010";
            }
            else if (comboBox2.SelectedItem == "Library & information sciences")
            {
                t = "020";
            }
            else if (comboBox2.SelectedItem == "Encyclopedias & books of facts")
            {
                t = "030";
            }
            else if (comboBox2.SelectedItem == "[Unassigned]")
            {
                t = "040";
            }
            else if (comboBox2.SelectedItem == "Magazines,journals & serials")
            {
                t = "050";
            }
            else if (comboBox2.SelectedItem == "Associations,organizations & museums")
            {
                t = "060";
            }
            else if (comboBox2.SelectedItem == "News media,journalism & publishing")
            {
                t = "070";
            }
            else if (comboBox2.SelectedItem == "Quotations")
            {
                t = "080";
            }
            else if (comboBox2.SelectedItem == "Manuscripts & rare books")
            {
                t = "090";
            }
            else if (comboBox2.SelectedItem == "Philosophy")
            {
                t = "100";
            }
            else if (comboBox2.SelectedItem == "Metaphysics")
            {
                t = "110";
            }
            else if (comboBox2.SelectedItem == "Epistemology")
            {
                t = "120";
            }
            else if (comboBox2.SelectedItem == "Parapsychology & occultism")
            {
                t = "130";
            }
            else if (comboBox2.SelectedItem == "Philosophical")
            {
                t = "140";
            }
            else if (comboBox2.SelectedItem == "Psychology")
            {
                t = "150";
            }
            else if (comboBox2.SelectedItem == "Logic")
            {
                t = "160";
            }
            else if (comboBox2.SelectedItem == "Ethics ")
            {
                t = "170";
            }
            else if (comboBox2.SelectedItem == "Ancient,medieval & eastern philosophy")
            {
                t = "180";
            }
            else if (comboBox2.SelectedItem == "Modern western philosophy ")
            {
                t = "190";
            }
            else if (comboBox2.SelectedItem == "Religion")
            {
                t = "200";
            }
            else if (comboBox2.SelectedItem == "Philosophy & theory of religion")
            {
                t = "210";
            }
            else if (comboBox2.SelectedItem == "The Bible")
            {
                t = "220";
            }
            else if (comboBox2.SelectedItem == "Christianity & Christian theology")
            {
                t = "230";
            }
            else if (comboBox2.SelectedItem == "Christian practice & observance")
            {
                t = "240";
            }
            else if (comboBox2.SelectedItem == "Christian pastoral practice & religious orders")
            {
                t = "250";
            }
            else if (comboBox2.SelectedItem == "Christian organization,social work & worship")
            {
                t = "260";
            }
            else if (comboBox2.SelectedItem == "History of Christianity")
            {
                t = "270";
            }
            else if (comboBox2.SelectedItem == "Christian denominations")
            {
                t = "280";
            }
            else if (comboBox2.SelectedItem == "Other religious")
            {
                t = "290";
            }
            else if (comboBox2.SelectedItem == "Social science,sociology & anthropology")
            {
                t = "300";
            }
            else if (comboBox2.SelectedItem == "Statistics")
            {
                t = "310";
            }
            else if (comboBox2.SelectedItem == "Political science")
            {
                t = "320";
            }
            else if (comboBox2.SelectedItem == "Economics")
            {
                t = "330";
            }
            else if (comboBox2.SelectedItem == "Law")
            {
                t = "340";
            }
            else if (comboBox2.SelectedItem == "Public administration & military science")
            {
                t = "350";
            }
            else if (comboBox2.SelectedItem == "social problem & social services")
            {
                t = "360";
            }
            else if (comboBox2.SelectedItem == "education")
            {
                t = "370";
            }
            else if (comboBox2.SelectedItem == "Commerce,commmunication & transportation")
            {
                t = "380";
            }
            else if (comboBox2.SelectedItem == "Customs,etiquette & folklore")
            {
                t = "390";
            }
            else if (comboBox2.SelectedItem == "Language")
            {
                t = "400";
            }
            else if (comboBox2.SelectedItem == "Linguistics")
            {
                t = "410";
            }
            else if (comboBox2.SelectedItem == "English & Old English Languages")
            {
                t = "420";
            }
            else if (comboBox2.SelectedItem == "German & related languages")
            {
                t = "430";
            }
            else if (comboBox2.SelectedItem == "French & related laguages")
            {
                t = "440";
            }
            else if (comboBox2.SelectedItem == "Italian,Romanian & related laguages")
            {
                t = "450";
            }
            else if (comboBox2.SelectedItem == "Spanish & Portuguese languages")
            {
                t = "460";
            }
            else if (comboBox2.SelectedItem == "Latin & Italic languages")
            {
                t = "470";
            }
            else if (comboBox2.SelectedItem == "Classical & modern Greek languages")
            {
                t = "480";
            }
            else if (comboBox2.SelectedItem == "Other languages")
            {
                t = "490";
            }
            else if (comboBox2.SelectedItem == "Science")
            {
                t = "500";
            }
            else if (comboBox2.SelectedItem == "Mathematics")
            {
                t = "510";
            }
            else if (comboBox2.SelectedItem == "Astronomy")
            {
                t = "520";
            }
            else if (comboBox2.SelectedItem == "Physics")
            {
                t = "530";
            }
            else if (comboBox2.SelectedItem == "Chemistry")
            {
                t = "540";
            }
            else if (comboBox2.SelectedItem == "Earth sciences & geology")
            {
                t = "550";
            }
            else if (comboBox2.SelectedItem == "Fossils & prehistoric life")
            {
                t = "560";
            }
            else if (comboBox2.SelectedItem == "Life sciences;biology")
            {
                t = "570";
            }
            else if (comboBox2.SelectedItem == "plants(Botany)")
            {
                t = "580";
            }
            else if (comboBox2.SelectedItem == "Animals(Zoology)")
            {
                t = "590";
            }
            else if (comboBox2.SelectedItem == "Technilogy")
            {
                t = "600";
            }
            else if (comboBox2.SelectedItem == "Medicine & health")
            {
                t = "610";
            }
            else if (comboBox2.SelectedItem == "Engineering")
            {
                t = "620";
            }
            else if (comboBox2.SelectedItem == "Agriculture")
            {
                t = "630";
            }
            else if (comboBox2.SelectedItem == "Home & family management")
            {
                t = "640";
            }
            else if (comboBox2.SelectedItem == "Management & public relations")
            {
                t = "650";
            }
            else if (comboBox2.SelectedItem == "Chemical engineering")
            {
                t = "660";
            }
            else if (comboBox2.SelectedItem == "Manufacturing")
            {
                t = "670";
            }
            else if (comboBox2.SelectedItem == "Manufacture for specific uses")
            {
                t = "680";
            }
            else if (comboBox2.SelectedItem == "Building & construction")
            {
                t = "690";
            }
            else if (comboBox2.SelectedItem == "Arts")
            {
                t = "700";
            }
            else if (comboBox2.SelectedItem == "Landscaping & area planning")
            {
                t = "710";
            }
            else if (comboBox2.SelectedItem == "Architecture")
            {
                t = "720";
            }
            else if (comboBox2.SelectedItem == "Sculpture,ceramics & metalwork")
            {
                t = "730";
            }
            else if (comboBox2.SelectedItem == "Drawing & decorative arts")
            {
                t = "740";
            }
            else if (comboBox2.SelectedItem == "Painting")
            {
                t = "750";
            }
            else if (comboBox2.SelectedItem == "Graphic arts")
            {
                t = "760";
            }
            else if (comboBox2.SelectedItem == "Photography & computer art")
            {
                t = "770";
            }
            else if (comboBox2.SelectedItem == "Music")
            {
                t = "780";
            }
            else if (comboBox2.SelectedItem == "sports,games & entertainment")
            {
                t = "790";
            }
            else if (comboBox2.SelectedItem == "Literature,rhetoric & criticism")
            {
                t = "800";
            }
            else if (comboBox2.SelectedItem == "American literature in English")
            {
                t = "810";
            }
            else if (comboBox2.SelectedItem == "English & Old Engilsh literatures")
            {
                t = "820";
            }
            else if (comboBox2.SelectedItem == "German & related literatures")
            {
                t = "830";
            }
            else if (comboBox2.SelectedItem == "French & related litteratures")
            {
                t = "840";
            }
            else if (comboBox2.SelectedItem == "Italian,Romanian & related literatures")
            {
                t = "850";
            }
            else if (comboBox2.SelectedItem == "Spanish&Potyuguese literatures")
            {
                t = "860";
            }
            else if (comboBox2.SelectedItem == "Latin & Italic literatures")
            {
                t = "870";
            }
            else if (comboBox2.SelectedItem == "Classical & modern Greek literatures")
            {
                t = "880";
            }
            else if (comboBox2.SelectedItem == "Other literatures")
            {
                t = "890";
            }
            else if (comboBox2.SelectedItem == "History")
            {
                t = "900";
            }
            else if (comboBox2.SelectedItem == "Geography & travel")
            {
                t = "910";
            }
            else if (comboBox2.SelectedItem == "Biography & genealogy")
            {
                t = "920";
            }
            else if (comboBox2.SelectedItem == "History of ancient world(to ca.499)")
            {
                t = "930";
            }
            else if (comboBox2.SelectedItem == "History of Europe")
            {
                t = "940";
            }
            else if (comboBox2.SelectedItem == "History of Asia")
            {
                t = "950";
            }
            else if (comboBox2.SelectedItem == "History of Africa")
            {
                t = "960";
            }
            else if (comboBox2.SelectedItem == "History of North America")
            {
                t = "970";
            }
            else if (comboBox2.SelectedItem == "History of South America")
            {
                t = "980";
            }
            else if (comboBox2.SelectedItem == "History of other areas")
            {
                t = "990";
            }
            t += "*";


            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from book ORDER BY no DESC LIMIT 1";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    classno = dr["no"].ToString();
                }
               // int k = classno.Length;
                int ss = Convert.ToInt32(classno)+1;
                string s1 = ss.ToString();
                int j = 13 - (t.Length + s1.Length);
                for(int i =0;i < j; i++)
                {
                    t += "0";
                }

                t += s1;
                textBox8.Text = t;

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        







    }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";

            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
        }

        string bno;
        String memberid, mtype, mm;
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            int i = 0;
           
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select notation from person_type where type ='" + comboBox3.SelectedItem + "'";
                cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    b = dr["notation"].ToString();
                }
                b += "*";
               // MessageBox.Show(b);
                

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
                cmd.CommandText = "select * from member ORDER BY id DESC LIMIT 1";
                cmd.ExecuteNonQuery();

                DataTable dt1 = new DataTable();
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
                da1.Fill(dt1);

                foreach (DataRow dr in dt1.Rows)
                {
                    memberid = dr["id"].ToString();
                }
                s = Convert.ToInt32(memberid) + 1;
                string sq = s.ToString();
                int k = sq.Length;

                int j = 13 - (k + b.Length);
               
                for (i = 0; i < j; i++)
                {
                    b += "0";
                }

                b += sq;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

            pictureBox2.Show();
            bitmap = new Bitmap(b.Length * 40, 100);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Font f = new System.Drawing.Font("IDAutomationSHC39XS Demo", 30);


                PointF point = new PointF(2f, 2f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush white = new SolidBrush(Color.White);
                graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                graphics.DrawString(b, f, black, point);


            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Jpeg);
                pictureBox2.Image = bitmap;
                pictureBox2.Height = bitmap.Height;
                pictureBox2.Width = bitmap.Width;

            }







        }


        

        private void insert_data_Load(object sender, EventArgs e)
        {
            
          
            
            
            
            
      
            //combox
            using (con)
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter("SELECT type from person_type", con))
                {
                    //Fill the DataTable with records from Table.
                    MySqlDataReader rdr = null;
                    try
                    {
                        con.Open();
                        //  string s = comboBox1.Text;
                        MySqlCommand cmd = new MySqlCommand("select type from person_type", con);
                        //SqlDataAdapter da = new SqlDataAdapter(st, con);


                        rdr = cmd.ExecuteReader();



                        while (rdr.Read())
                        {

                            comboBox3.Items.Add(rdr[0].ToString());
                        }

                    }
                    catch (MySqlException SqlEx)
                    {
                        if (SqlEx.Message.StartsWith("Invalid object name"))
                        {

                        }
                        else throw;

                    }
                    finally
                    {
                        if (rdr != null)
                        {
                            rdr.Close();
                        }
                    }
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }







            panel1.Hide();
            panel2.Hide();



            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "select type from person_type";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);


            foreach (DataRow dr in dt.Rows)
            {

            }




            con.Close();




            comboBox1.Items.Add("Computer science,information & general works");
            comboBox1.Items.Add("Philosophy & psychology");
            comboBox1.Items.Add("Religion");
            comboBox1.Items.Add("Social sciences");
            comboBox1.Items.Add("Language");
            comboBox1.Items.Add("Science");
            comboBox1.Items.Add("Technology");
            comboBox1.Items.Add("Arts & recreation");
            comboBox1.Items.Add("Literature");
            comboBox2.Items.Clear();
            comboBox1.Items.Add("History & geography");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if(textBox8.Text.Length == 13)
            {
                pictureBox1.Show();
                string barcode = textBox8.Text;
                bitmap = new Bitmap(barcode.Length * 40, 100);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    Font f = new System.Drawing.Font("IDAutomationSHC39XS Demo", 30);


                    PointF point = new PointF(2f, 2f);
                    SolidBrush black = new SolidBrush(Color.Black);
                    SolidBrush white = new SolidBrush(Color.White);
                    graphics.FillRectangle(white, 0, 0, bitmap.Width, bitmap.Height);
                    graphics.DrawString(barcode, f, black, point);


                }
                using (MemoryStream ms = new MemoryStream())
                {
                    bitmap.Save(ms, ImageFormat.Jpeg);
                    pictureBox1.Image = bitmap;
                    pictureBox1.Height = bitmap.Height;
                    pictureBox1.Width = bitmap.Width;

                }



            }
        }




        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                //to make class number





                cmd.CommandText = "insert into member values('" + comboBox3.SelectedItem + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" +b+ "'," + s + ")";
                cmd.ExecuteNonQuery();
                con.Close();

                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                pictureBox2.Hide();


                MessageBox.Show("Inserted Successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            comboBox3.SelectedItem = "";
        }
    }

}