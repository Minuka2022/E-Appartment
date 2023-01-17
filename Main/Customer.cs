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

namespace Main
{
    public partial class Customer : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=E_appartments;Integrated Security=True");
        public Customer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Customer_Load(object sender, EventArgs e)
        {
            // Building combo
            SqlCommand cmb1 = new SqlCommand("SELECT building_name,building_id FROM Building", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmb1;
            DataTable dt = new DataTable();
            da.Fill(dt);

            //default value
            DataRow itemrow = dt.NewRow();
            itemrow[0] = "Select building";
            dt.Rows.InsertAt(itemrow, 0);



            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "building_name";
            comboBox1.ValueMember = "building_id";


            //Apartment combo
          

                String b_id = comboBox1.SelectedValue.ToString();


                SqlCommand cmb2 = new SqlCommand("SELECT apartment_num,apartment_id FROM Apartment WHERE building_id = @b_id", con);
                cmb2.Parameters.AddWithValue("@b_id", b_id);


                SqlDataAdapter da1 = new SqlDataAdapter();
                da1.SelectCommand = cmb2;
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);

           
                    //default value
                    DataRow it_row = dt1.NewRow();
                    it_row[0] = DBNull.Value;
                    dt1.Rows.InsertAt(it_row, 0);

            comboBox2.DataSource = dt1;
                comboBox2.DisplayMember = "apartment_num";
                comboBox2.ValueMember = "apartment_id";

            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            


        }


        void show()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM ", con);
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
                    int occupent_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["OC_ID"].Value);

                    String qry = "DELETE FROM Occupent WHERE occupent_id = " + occupent_id + "";

                    SqlCommand sc = new SqlCommand(qry, con);
                    int i = sc.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        MessageBox.Show("Occupent deleted");
                        show();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    con.Close();
                }
            }else if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                if (MessageBox.Show("Are you sure want to edit this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    // Get the selected row in the DataGridView
                    DataGridViewRow selectedRow = dataGridView1.CurrentRow;
                    // Assign the values of the selected row to the TextBoxes
                    //apartment_id1 = int.Parse(selectedRow.Cells[0].Value.ToString());
                    textBox1.Text = selectedRow.Cells[2].Value.ToString();
                    //comboBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    textBox3.Text = selectedRow.Cells[3].Value.ToString();
                    textBox5.Text = selectedRow.Cells[4].Value.ToString();
                    textBox2.Text = selectedRow.Cells[8].Value.ToString();
                    textBox6.Text = selectedRow.Cells[5].Value.ToString();
                    textBox7.Text = selectedRow.Cells[6].Value.ToString();
                    textBox9.Text = selectedRow.Cells[7].Value.ToString();
                   // comboBox1.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String full_name = textBox1.Text.ToString();
            String email = textBox2.Text.ToString();
            int phone = Int32.Parse(textBox3.Text.ToString());
            int nic = Int32.Parse(textBox5.Text.ToString());
            int emg_cont = Int32.Parse(textBox5.Text.ToString());
            String username = textBox8.Text.ToString();
            String password = textBox9.Text.ToString();
            //int building_id = Int32.Parse(comboBox1.SelectedValue.ToString());
          //  int aprt_num = Int32.Parse(comboBox2.SelectedValue.ToString());

            String qry = "INSER INTO Occupent(fullname,address,contact_info,emergancy_contact,nic,appartment_id,Username,password,building_id)VALUES(" + full_name + "," + email + "," + phone + "," + nic + "," + emg_cont + "," + username + "," + password + ")";

            SqlCommand sc = new SqlCommand(qry, con);

            int i = sc.ExecuteNonQuery();

            if (i >= 1)
            {
                MessageBox.Show("Customer added");
                show();
            }
            else
            {
                MessageBox.Show("Customer not added");
            }
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String searchText = textBox8.Text;

            //Build the search query
            String searchQuery = "SELECT * FROM Occupent WHERE occupent_id like '%" + searchText + "%'";

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
                dataGridView1.Rows[n].Cells[8].Value = dr[8].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            con.Open();
            String full_name = textBox1.Text.ToString();
            String email = textBox2.Text.ToString();
            int phone = Int32.Parse(textBox3.Text.ToString());
            int nic = Int32.Parse(textBox5.Text.ToString());
            int emg_cont = Int32.Parse(textBox5.Text.ToString());
            String username = textBox8.Text.ToString();
            String password = textBox9.Text.ToString();
            int building_id = Int32.Parse(comboBox1.SelectedValue.ToString());
            int aprt_num = Int32.Parse(comboBox2.SelectedValue.ToString());

            String qry = "UPDATE Occupent set fulname = '"+full_name+"' , address = '"+email+"' , contact_info = '"+phone+"' , emergancy_contact = '"+emg_cont+"' , nic = '"+nic+"' , appartment_id = '"+aprt_num+"' , Username = '"+username+"' , password = '"+password+"' , building_id = '"+building_id+"' ";
          
            SqlCommand sc = new SqlCommand(qry, con);

            int i = sc.ExecuteNonQuery();

            if (i >= 1)
            {
                MessageBox.Show("Occupent updated");
                show();
            }
            else
            {
                MessageBox.Show("Occupent not updated");
            }
            con.Close();

        }
    }
}
