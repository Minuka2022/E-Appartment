using Main;
using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Main
{
    public partial class Sign_in : Form
    {

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=E_appartments;Integrated Security=True");
        SqlDataAdapter da;
        SqlCommand cmd;
        public Sign_in()
        {
            InitializeComponent();
            Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text.ToString();
            String password = textBox2.Text.ToString();

            con.Open();

            String qry = "SELECT role FROM users  WHERE username = '" + username + "' AND password = '" + password + "' ";

            using (SqlDataAdapter adapter = new SqlDataAdapter(qry, con))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string role = ds.Tables[0].Rows[0]["role"].ToString();
                    if (role == "Customer")
                    {
                        CustomerWindow customerWindow = new CustomerWindow();
                        customerWindow.Show();
                        this.Hide();
                    }
                    else if (role == "Admin")
                    {
                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.");
                }
            }
            con.Close();



        }
    }
}

