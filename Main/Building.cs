using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;

namespace Main
{
    
    public partial class Building : UserControl
    {
        int buidling_id2;

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=E_appartments;Integrated Security=True");
        public Building()
        {
            InitializeComponent();
            show();
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void Building_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String building_name = textBox1.Text.ToString();
            String location = textBox2.Text.ToString();
            String Num_of_app1 = textBox3.Text.ToString();
            int Num_of_app = Int32.Parse(Num_of_app1);

            String Num_of_floor1 = textBox4.Text.ToString();
            int Num_of_floor = Int32.Parse(Num_of_floor1);

            String Num_of_parking1 = textBox5.Text.ToString();
            int Num_of_parking = Int32.Parse(Num_of_parking1);
            String Tel_no1 = textBox6.Text.ToString();
            int Tel_no = Int32.Parse(Tel_no1);
            String Email = textBox7.Text.ToString();

            String qry = "INSERT INTO Building(building_name,location,num_of_apprtments,num_of_floor,num_of_parking,tel_no,email) VALUES ('" + building_name + "','" + location + "'," + Num_of_app + "," + Num_of_floor + "," + Num_of_parking + "," + Tel_no + ",'" + Email + "')";


            SqlCommand sc = new SqlCommand(qry, con);
            int i = sc.ExecuteNonQuery();
            if (i >= 1)
            {
                MessageBox.Show("Building added successfuly");
                show();
            }
            else
            {
                MessageBox.Show("Building not added");
            }
            con.Close();
        }

        void show()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Building", con);
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
                dataGridView1.Rows[n].Cells[5].Value = dr[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = dr[6].ToString();
                dataGridView1.Rows[n].Cells[7].Value = dr[7].ToString();

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                con.Open();
                if (MessageBox.Show("Are you sure want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int building_id1 = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Building_ID"].Value);
                   
                    String qry = "DELETE FROM Building WHERE building_id = " + building_id1 + "";

                    SqlCommand sc = new SqlCommand(qry, con);
                    int i = sc.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        MessageBox.Show("Building deleted");
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
                    buidling_id2 = int.Parse(selectedRow.Cells[0].Value.ToString());
                    textBox1.Text = selectedRow.Cells[1].Value.ToString();
                    textBox2.Text = selectedRow.Cells[2].Value.ToString();
                    textBox3.Text = selectedRow.Cells[3].Value.ToString();
                    textBox4.Text = selectedRow.Cells[4].Value.ToString();
                    textBox5.Text = selectedRow.Cells[5].Value.ToString();
                    textBox6.Text = selectedRow.Cells[6].Value.ToString();
                    textBox7.Text = selectedRow.Cells[7].Value.ToString();
                }
            }
        }


        

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            String building_name = textBox1.Text.ToString();
            String location = textBox2.Text.ToString();
            String Num_of_app1 = textBox3.Text.ToString();
            int Num_of_app = Int32.Parse(Num_of_app1);

            String Num_of_floor1 = textBox4.Text.ToString();
            int Num_of_floor = Int32.Parse(Num_of_floor1);

            String Num_of_parking1 = textBox5.Text.ToString();
            int Num_of_parking = Int32.Parse(Num_of_parking1);
            String Tel_no1 = textBox6.Text.ToString();
            int Tel_no = Int32.Parse(Tel_no1);
            String Email = textBox7.Text.ToString();

            String qry = "UPDATE Building SET building_name = '" + building_name + "', location = '" + location + "', num_of_apprtments = " + Num_of_app + ", num_of_floor = " + Num_of_floor + ", num_of_parking = " + Num_of_parking + ", tel_no = " + Tel_no + ", email = '" + Email + "' WHERE building_id = " + buidling_id2;



            SqlCommand sc = new SqlCommand(qry, con);
            int i = sc.ExecuteNonQuery();
            if (i >= 1)
            {
                MessageBox.Show("Building Updated successfuly");
                show();
            }
            else
            {
                MessageBox.Show("Error");
            }
            con.Close();
            

        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Get the search text
            String searchText = textBox8.Text;

            //Build the search query
            String searchQuery = "SELECT * FROM Building WHERE building_name like '%" + searchText + "%'";

            //create a Datatable to store the results
            SqlDataAdapter sda = new SqlDataAdapter(searchQuery, con);

            //create a datatable to store the results
            DataTable dt = new DataTable();

            //fill the datatable with the search result
            sda.Fill(dt);

            //clear the datagrid view
            dataGridView1.Rows.Clear();

            //Add the search result to the datagridview
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr[0].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr[4].ToString();
                dataGridView1.Rows[n].Cells[5].Value = dr[5].ToString();
                dataGridView1.Rows[n].Cells[6].Value = dr[6].ToString();
                dataGridView1.Rows[n].Cells[7].Value = dr[7].ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            show();
        }
    }
}




