using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VaccinationApp
{
    public partial class Form3 : Form
    {
        String connectionString = "Data Source=Covid19.db;Version=3;";
        SQLiteConnection conn;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);
            conn.Open();
            String displayQuery = "Select * from Cases";
            SQLiteCommand cmd1 = new SQLiteCommand(displayQuery, conn);
            SQLiteDataReader reader1 = cmd1.ExecuteReader();
           
            DataTable dt = new DataTable();
            dt.Load(reader1);
            
            conn.Close();
            dataGridView1.DataSource = dt;
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String keyword = textBox1.Text;
            conn.Open();
            String searchQuery = "Select * From Cases WHERE FullName LIKE'%" + keyword + "%' OR Email LIKE'%" + keyword + "%' OR Gender LIKE'%" + keyword + "%' OR Birthdate LIKE'%" + keyword + "%' OR UnderlyingDisease LIKE'%" + keyword + "%' OR Address LIKE'%" + keyword + "%' OR RegistrationDate LIKE'%" + keyword + "%' OR PhoneNumber LIKE'%" + keyword + "%' ";
            SQLiteCommand cmd2 = new SQLiteCommand(searchQuery, conn);
            SQLiteDataReader reader2 = cmd2.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader2);
            conn.Close();
            dataGridView1.DataSource = dt;

        }
    }
}
