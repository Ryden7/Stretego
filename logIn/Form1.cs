using StrategoBoardBothPlayers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logIn
{
    public partial class Form1 : Form
    {
         String userLogin = "null";
        public Form1()
        {
            InitializeComponent();
        }
        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            String userLogin = Console.ReadLine();
            // Return userLogin;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = "Data Source=KRISHNA-PC\\SQLEXPRESS;Initial Catalog=STUDENT;Integrated Security=True";
            //con.Open();
            //string userid = textBox1.Text;
            //string password = textBox2.Text;
            //SqlCommand cmd = new SqlCommand("select userid,password from login where userid='" + textBox1.Text + "'and password='" + text            Box2.Text + "'", con);
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)
            //{
            //    MessageBox.Show("Login sucess Welcome to Homepage http://krishnasinghprogramming.nlogspot.com");
            //    System.Diagnostics.Process.Start(" URL of server here ");
            //}


            // Regex pattern = new Regex("[0-9]{4,25}");
            //string valueFromTextBox = userLogin.Text;
            //if (pattern.IsMatch(valueFromTextBox.Text))
            //if (userLogin != "null")
            //{

          //  AsynchronousClient.StartClient();
            Stratego frm = new Stratego();
                frm.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Please input a valid user name and password");
            //}
            //Stratego frm = new Stratego();
            //frm.Show();

        }
    
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
