using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaccinationApp
{
    public partial class Form5 : Form
    {
        String connectionString = "Data Source=Covid19.db;Version=3;";
        SQLiteConnection conn;
        public Form5()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);
            conn.Open();
            String displayQuery = "Select * from Cases";
            SQLiteCommand cmd1 = new SQLiteCommand(displayQuery, conn);
            SQLiteDataReader reader1 = cmd1.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader1);

            conn.Close();
            dataGridView1.DataSource = dt; //dataGrid has the deleting option enabled 
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String deleteQuery = "DELETE FROM Cases WHERE ID =@ID";
                SQLiteCommand cmd = new SQLiteCommand(deleteQuery, conn);
                cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                int rows = cmd.ExecuteNonQuery(); // rows must be greater than 0 if successfull
                conn.Close();
                if (rows > 0)
                {
                    conn.Open();
                    String displayQuery = "Select * from Cases";
                    SQLiteCommand cmd1 = new SQLiteCommand(displayQuery, conn);
                    SQLiteDataReader reader1 = cmd1.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader1);

                    conn.Close();
                    dataGridView1.DataSource = dt;
                    String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Covid19.mdb";
                    OleDbConnection connection = new OleDbConnection(connectionString);
                    String deleteQuery1 = "DELETE FROM Cases WHERE ID=@ID1";



                    connection.Open();
                    OleDbCommand command = new OleDbCommand(deleteQuery1, connection);
                    command.Parameters.AddWithValue("@ID1", int.Parse(textBox1.Text));
                    command.ExecuteNonQuery();
                    connection.Close();

                }
                else
                {
                    MessageBox.Show("Invalid id");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid id");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
