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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Main
{
    public partial class Manage_users : UserControl
    {
        int user_id1;

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=E_appartments;Integrated Security=True");
        public Manage_users()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        void show()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Users", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();


            }

        }
   

        private void Manage_users_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            String name = textBox1.Text.ToString();
            String username = textBox2.Text.ToString();
            String password = textBox3.Text.ToString();
            String role = comboBox1.SelectedItem.ToString();


            String qry = "INSERT INTO Users(full_name,username,password,role)VALUES('"+name+"' , '"+username+"' , '"+password+"' , '"+role+"')";

            SqlCommand sc = new SqlCommand(qry, con);
            int i = sc.ExecuteNonQuery();
            if (i >= 1)
            {
                MessageBox.Show("User added successfuly");
                show();
            }
            else
            {
                MessageBox.Show("User not added");
            }
            con.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                con.Open();
                if (MessageBox.Show("Are you sure want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int U_ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["U_ID"].Value);

                    String qry = "DELETE FROM Users WHERE user_id = " + U_ID + "";

                    SqlCommand sc = new SqlCommand(qry, con);
                    int i = sc.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        MessageBox.Show("User deleted");
                        show();

                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }




                }
                con.Close();

            }


            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                if (MessageBox.Show("Are you sure want to edit this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Get the selected row in the DataGridView
                    DataGridViewRow selectedRow = dataGridView1.CurrentRow;
                    // Assign the values of the selected row to the TextBoxes
                    user_id1 = int.Parse(selectedRow.Cells[0].Value.ToString());

                    textBox1.Text = selectedRow.Cells[1].Value.ToString();
                    textBox2.Text = selectedRow.Cells[2].Value.ToString();
                    textBox3.Text = selectedRow.Cells[3].Value.ToString();
                    comboBox1.Text = selectedRow.Cells[4].Value.ToString();


                }
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.Open();
            String name = textBox1.Text.ToString();
            String username = textBox2.ToString();
            String password = textBox3.Text.ToString();
            String role = comboBox1.SelectedItem.ToString();


            String qry = "UPDATE Users SET full_name = '" + name + "' , username = '" + username + "' , password = '" + password + "' , role = '" + role + "' ";

            SqlCommand sc = new SqlCommand(qry, con);
            int i = sc.ExecuteNonQuery();
            if (i >= 1)
            {
                MessageBox.Show("User updated successfuly");
                show();
            }
            else
            {
                MessageBox.Show("User not added");
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            show();
        }
    }
}
