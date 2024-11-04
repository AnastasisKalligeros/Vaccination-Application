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
    public partial class Form4 : Form
    {
        String connectionString = "Data Source=Covid19.db;Version=3;";
        SQLiteConnection conn;
        public Form4()
        {
          
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int age = 0;
            String UnderlyingDisease = "None";

            Case c = new Case();

            try
            {
                conn.Open();
                string query = "Select Birthdate, UnderlyingDisease FROM Cases WHERE ID =@ID";

                SQLiteCommand cmd = new SQLiteCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));

                SQLiteDataReader reader1 = cmd.ExecuteReader();
                while (reader1.Read())
                {
                    age = 2021 - reader1.GetInt32(0);
                    UnderlyingDisease = reader1.GetString(1);

                }




                conn.Close();

                c.age = age;
                c.underlyingDisease = UnderlyingDisease;
                if (comboBox1.Text == "Yes")
                {
                    c.Symptoms = true;
                }
                else
                {
                    c.Symptoms = false;
                }
                if (comboBox2.Text == "Yes")
                {
                    c.seriousSymptoms = true;
                }
                else
                {
                    c.seriousSymptoms = false;
                }
                label6.Text = c.Severity();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Wrong id.Try again.");
            }




        }

        private void Form4_Load(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);
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
    }
}
