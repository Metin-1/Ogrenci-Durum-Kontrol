using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsAppgorev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;

        void grid()
        {
            con = new SqlConnection("Data Source=DESKTOP-9VACU93\\SQLEXPRESS;Initial Catalog=Tugrul;Integrated Security=True");
            da = new SqlDataAdapter("select * from dernek", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "dernek");
            dataGridView1.DataSource = ds.Tables["dernek"];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = "null";
            if (radioButton1.Checked == true)
            {
                a = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                a = radioButton2.Text;
            }
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into dernek(ogrencino,Ad,Soyad,Uyelikdurumu,Durum) values (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + a + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            grid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grid();
            //duzeltin mi kaldir
            button3.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton2.Checked = true;
            }
            if (checkBox1.Checked == false)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton1.Checked = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 2)
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton1.Checked = true;
                checkBox1.Enabled = false;
            }

            if (comboBox1.SelectedIndex != 2)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton1.Checked = true;
                checkBox1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = "null";
            if (radioButton1.Checked == true)
            {
                a = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                a = radioButton2.Text;
            }
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Update dernek set Ad='" + textBox2.Text + "',Soyad='" + textBox3.Text + "',Durum='" + a + "',Uyelikdurumu='" + comboBox1.SelectedItem.ToString() + "'where ogrencino=" + textBox1.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
            grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Duzeltilecek
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            //cmd.CommandText = "Select * from dernek where Ad = '" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            grid();
        }
    }
}
