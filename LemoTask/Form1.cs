using Npgsql;

namespace LemoTask
{

    public partial class Form1 : Form
    {

        NpgsqlConnection con;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = new Form2(this);
            f.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con = Connectioncs.getConnection();
            
        }
    }
}
