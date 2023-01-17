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
    public partial class Appartment : UserControl
    {
        int apartment_id1;

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=E_appartments;Integrated Security=True");
        public Appartment()
        {
            InitializeComponent();
            show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Appartment_Load(object sender, EventArgs e)
        {
            SqlCommand cmb = new SqlCommand("SELECT building_name,building_id FROM Building", con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmb;
            DataTable dt = new DataTable();
            da.Fill(dt);

            //default value
            DataRow itemrow = dt.NewRow();
            itemrow[0] = "Select building";
            dt.Rows.InsertAt(itemrow, 0);



            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "building_name";
            comboBox2.ValueMember = "building_id";



        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            String aprt_no = textBox1.Text.ToString();
            int aprt_num = Int32.Parse(aprt_no);

            String building_id1 = comboBox2.SelectedValue.ToString();
            int building_id2 = Int32.Parse(building_id1);

            String prc = textBox2.Text.ToString();
            int price = Int32.Parse(prc);

            String class1 = textBox3.Text.ToString();

            String roomss = textBox5.Text.ToString();
            int room1 = Int32.Parse(roomss);

            String flr_ar = textBox6.Text.ToString();
            int area1 = Int32.Parse(flr_ar);

            String mx_oc = textBox7.Text.ToString();
            int max_occupancy1 = Int32.Parse(mx_oc);

            String pk_id = textBox9.Text.ToString();
            string parking_id1 = pk_id;

            String availability = comboBox1.SelectedItem.ToString();

            string qry = "INSERT INTO Apartment (building_id,apartment_num,classes,rooms,area,max_occupancy,available,parking_id,price) VALUES(" + building_id2 + "," + aprt_num + ",'" + class1 + "'," + room1 + "," + area1 + "," + max_occupancy1 + ",'" + availability + "','" + parking_id1 + "' , '" + price + "')";

            SqlCommand sc = new SqlCommand(qry, con);

            int i = sc.ExecuteNonQuery();

            if (i >= 1)
            {
                MessageBox.Show("Apartment added");
                show();
            }
            else
            {
                MessageBox.Show("Apartment not added");
            }
            con.Close();
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                con.Open();
                if (MessageBox.Show("Are you sure want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int apartment_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Apartment_ID"].Value);

                    String qry = "DELETE FROM Apartment WHERE apartment_id = " + apartment_id + "";

                    SqlCommand sc = new SqlCommand(qry, con);
                    int i = sc.ExecuteNonQuery();
                    if (i >= 1)
                    {
                        MessageBox.Show("Apartment deleted");
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
                    apartment_id1 = int.Parse(selectedRow.Cells[0].Value.ToString());
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

        void show()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Apartment", con);
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
                dataGridView1.Rows[n].Cells[7].Value = dr[8].ToString();
                dataGridView1.Rows[n].Cells[8].Value = dr[9].ToString();
                dataGridView1.Rows[n].Cells[9].Value = dr[7].ToString();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            String aprt_no = textBox1.Text.ToString();
            int aprt_num = Int32.Parse(aprt_no);

            String building_id1 = comboBox2.SelectedValue.ToString();
            int building_id2 = Int32.Parse(building_id1);

            String prc = textBox2.Text.ToString();
            int price = Int32.Parse(prc);

            String class1 = textBox3.Text.ToString();

            String roomss = textBox5.Text.ToString();
            int room1 = Int32.Parse(roomss);

            String flr_ar = textBox6.Text.ToString();
            int area1 = Int32.Parse(flr_ar);

            String mx_oc = textBox7.Text.ToString();
            int max_occupancy1 = Int32.Parse(mx_oc);

            String pk_id = textBox9.Text.ToString();
            string parking_id1 = pk_id;

            String availability = comboBox1.SelectedItem.ToString();

            string qry = "UPDATE Apartment SET building_id = '" + building_id2 + "' , apartment_num = '" + aprt_num + "' , classes = '" + class1 + "', rooms = '" + room1 + "', area = '" + area1 + "' ,max_occupancy = '" + max_occupancy1 + "' , available = '" + availability + "' , parking_id = '" + parking_id1 + "' , price = '" + price + "' WHERE apartment_id = '" + apartment_id1 + "' ";

            SqlCommand sc = new SqlCommand(qry, con);

            int i = sc.ExecuteNonQuery();

            if (i >= 1)
            {
                MessageBox.Show("Apartment updated");
                show();
            }
            else
            {
                MessageBox.Show("Apartment not updateds");
            }
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Get the search text
            String searchText = textBox8.Text;

            //Build the search query
            String searchQuery = "SELECT * FROM Apartment WHERE apartment_id like '%" + searchText + "%'";

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
                dataGridView1.Rows[n].Cells[7].Value = dr[8].ToString();
                dataGridView1.Rows[n].Cells[8].Value = dr[9].ToString();
                dataGridView1.Rows[n].Cells[9].Value = dr[7].ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            show();
        }
    }
}


