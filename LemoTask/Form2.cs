using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Npgsql;

namespace LemoTask
{
    public partial class Form2 : Form
    {       NpgsqlConnection cn;
            NpgsqlDataAdapter da;
            DataSet ds;
        Form1 f;
        public Form2(Form1 _f)
        {
            InitializeComponent();
            f = _f;
          

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Le nom du projet est obligatoire !");
                return;
            }

            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("La date de fin doit être après la date de début !");
                return;
            }

            DataRow row = ds.Tables["projects"].NewRow();

            row["project_name"] = textBox1.Text;
            row["description"] = textBox2.Text;
            row["start_date"] = dateTimePicker1.Value;
            row["end_date"] = dateTimePicker2.Value;
            row["created_by"] = 1;// not sure abt this one , js asked chat
            ds.Tables["projects"].Rows.Add(row);
            da.Update(ds, "projects");
            MessageBox.Show("Projet ajouté avec succès !");
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {//the connection string is to be adapted to what you have on your computer
            cn = new NpgsqlConnection(
       "Host=localhost;Port=5432;Username=postgres;Password=[PASSWORD];Database=[DBNAME]"
   );
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM projects", cn);

            NpgsqlCommandBuilder cb = new NpgsqlCommandBuilder(da);

            DataSet ds = new DataSet();

            da.Fill(ds, "projects");
        }
    }
}
