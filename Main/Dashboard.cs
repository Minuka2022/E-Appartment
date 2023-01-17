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
    public partial class Dashboard : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=E_appartments;Integrated Security=True");
        public Dashboard()
        {
            InitializeComponent();
            ShowBuilding();
            Showlease();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            con.Open();

            // City view labe;l
            String classes = "city view";
            String Available1 = "Available";
            SqlCommand cmd = new SqlCommand("SELECT COUNT(apartment_num) FROM Apartment WHERE classes = '" + classes + "' AND available = '"+Available1+"' ", con);

            int count1 = (int)cmd.ExecuteScalar();
            CityViewNo.Text = String.Format("{0}",count1);


            // Sky view label
            String classes1 = "sky view";
            String Available2 = "Available";
            SqlCommand cmd1 = new SqlCommand("SELECT COUNT(apartment_num) FROM Apartment WHERE classes = '" + classes1 + "' AND available = '" + Available1 + "' ", con);

            int count2 = (int)cmd1.ExecuteScalar();
            SkyViewNo.Text = String.Format("{0}", count2);


            //Mellenium
            String classes2 = "part place";
            String Available3 = "Available";
            SqlCommand cmd2 = new SqlCommand("SELECT COUNT(apartment_num) FROM Apartment WHERE classes = '" + classes2 + "' AND available = '" + Available1 + "' ", con);

            int count3 = (int)cmd2.ExecuteScalar();
            PartPlaceNo.Text = String.Format("{0}", count3);

            con.Close();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            con.Open();
            // City view labe;l
            String classes = "city view";
            String Unavailable4 = "Unavailable";
            SqlCommand cmd3 = new SqlCommand("SELECT COUNT(apartment_num) FROM Apartment WHERE classes = '" + classes + "' AND available = '" + Unavailable4 + "' ", con);

            int count4 = (int)cmd3.ExecuteScalar();
            ocCity.Text = String.Format("{0}", count4);

            // City view labe;l
            String classes3 = "sky view";
            String Unavailable5= "Unavailable";
            SqlCommand cmd4 = new SqlCommand("SELECT COUNT(apartment_num) FROM Apartment WHERE classes = '" + classes3 + "' AND available = '" + Unavailable5 + "' ", con);

            int count5 = (int)cmd4.ExecuteScalar();
            ocSky.Text = String.Format("{0}", count5);

            // City view labe;l
            String classes4 = "part place";
            String Unavailable6 = "Unavailable";
            SqlCommand cmd5 = new SqlCommand("SELECT COUNT(apartment_num) FROM Apartment WHERE classes = '" + classes4 + "' AND available = '" + Unavailable6 + "' ", con);

            int count6 = (int)cmd5.ExecuteScalar();
            ocPart.Text = String.Format("{0}", count6);

            con.Close();

        }


                    void ShowBuilding()
                    { 
                        //building
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Building", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        dataGridView1.DataSource= dt;



                    }

                    void Showlease()
                    {
                        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Lease", con);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        foreach (DataRow dr in dt.Rows)
                        {
                            int n = dataGridView1.Rows.Add();

                            dataGridView1.Rows[n].Cells[0].Value = dr[1].ToString();
                            dataGridView1.Rows[n].Cells[1].Value = dr[2].ToString();
                            dataGridView1.Rows[n].Cells[2].Value = dr[3].ToString();
                            dataGridView1.Rows[n].Cells[3].Value = dr[4].ToString();
                            dataGridView1.Rows[n].Cells[4].Value = dr[5].ToString();
           
                        }

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }


        
    }

