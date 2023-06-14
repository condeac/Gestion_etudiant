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
using GestionEtudiant.Database2DataSet2TableAdapters;

namespace GestionEtudiant
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename\"C:\\Users\\condeac\\Desktop\\GestionEtudiant\\GestionEtudiant\\data\\Database1.mdf\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Student",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //dataGridView1.DataSource= dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\condeac\\Desktop\\GestionEtudiant\\GestionEtudiant\\data\\Database2.mdf\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Stud values (@name,@age)", con);
           // cmd.Parameters.AddWithValue("@Id", "");
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@age", int.Parse(textBox2.Text));
            cmd.ExecuteNonQuery();
            StudTableAdapter stud = new StudTableAdapter(); 
            stud.Connection= con;

            stud.Fill(this.database2DataSet2.Stud);
            con.Close();
          
            MessageBox.Show("success");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'database2DataSet2.Stud'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.studTableAdapter2.Fill(this.database2DataSet2.Stud);
            // TODO: cette ligne de code charge les données dans la table 'database2DataSet1.Stud'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            

        }

        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            


        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\condeac\\Desktop\\GestionEtudiant\\GestionEtudiant\\data\\Database2.mdf\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete  Stud where Id=@Id ", con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            StudTableAdapter stud = new StudTableAdapter();
            stud.Connection = con;

            stud.Fill(this.database2DataSet2.Stud);
            con.Close();

            MessageBox.Show("success deleteed");


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\condeac\\Desktop\\GestionEtudiant\\GestionEtudiant\\data\\Database2.mdf\";Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update  Stud set name=@name, age=@age where Id=@Id ", con);
            cmd.Parameters.AddWithValue("@Id", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@age", int.Parse(textBox2.Text));
            cmd.ExecuteNonQuery();
            StudTableAdapter stud = new StudTableAdapter();
            stud.Connection = con;

            stud.Fill(this.database2DataSet2.Stud);
            con.Close();

            MessageBox.Show("success upd");
        }
    }
}
