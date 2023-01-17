namespace Main
{
    public partial class Form1 : Form
    {

        
        public Form1()
        {
            InitializeComponent();
            sidepanel.Height = button1.Height;
            sidepanel.Top = button1.Top;
            dashboard1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (LeaseDrop.Height == 159)
            {
                LeaseDrop.Height = 64;
            }
            else
            {
                LeaseDrop.Height =159 ;
            }

            sidepanel.Height = button3.Height;
            sidepanel.Top = button3.Top;
            lease1.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ReportDrop.Height == 159)
            {
                ReportDrop.Height = 64;
            }
            else
            {
                ReportDrop.Height = 159;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sidepanel.Height = button1.Height;
            sidepanel.Top = button1.Top;
            dashboard1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sidepanel.Height = button2.Height;
            sidepanel.Top = button2.Top;
            appartment2.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sidepanel.Height = button4.Height;
            sidepanel.Top = button4.Top;
            lease_request1.BringToFront();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            rent_and_deposits1.BringToFront();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            customer1.BringToFront(); 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            occupancy_report1.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            rental_income2.BringToFront();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            manage_users2.BringToFront();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Sign_in secondForm = new Sign_in();
            secondForm.Show();
            this.Hide();
            

        }

        private void button12_Click(object sender, EventArgs e)
        {
            building1.BringToFront();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            employee1.BringToFront();
        }
    }
}