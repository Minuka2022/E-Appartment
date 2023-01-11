namespace Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}