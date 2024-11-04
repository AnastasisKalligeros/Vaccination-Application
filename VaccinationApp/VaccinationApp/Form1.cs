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
    public partial class Form1 : Form
    {
        String connectionString = "Data Source=Covid19.db;Version=3;";
        SQLiteConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            
        }

        private void seeAllCasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }

        private void deleteACaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }

        private void modifyACaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void ageRangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int NumberUnder50 = 0;
            int Number50to75 = 0;
            int NumberOver75 = 0;
            conn.Open();
            String statisticQuery3 = "Select Birthdate From Cases";
            SQLiteCommand cmd = new SQLiteCommand(statisticQuery3, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
               if(2021 - reader.GetInt32(0) < 50)
                {
                    NumberUnder50++;
                }
               else if(2021 - reader.GetInt32(0) <75 && 2021 - reader.GetInt32(0) > 50)
                {
                    Number50to75++;
                }
               else if (2021 - reader.GetInt32(0) > 75)
                {
                    NumberOver75++;
                }
            }
            MessageBox.Show("Under 50:  " + NumberUnder50.ToString() + Environment.NewLine + "50 to 75:   " +Number50to75.ToString() +Environment.NewLine + "Over75:   " + NumberOver75.ToString() );
           

            conn.Close();
        }

        private void maleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void maleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int numberMale = 0;
            conn.Open();
            String statisticQuery1 = "Select Id From Cases where Gender='Male' ";
            SQLiteCommand cmd = new SQLiteCommand(statisticQuery1, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                numberMale++;
            }
            MessageBox.Show(numberMale.ToString());

            conn.Close();
        }

        private void femaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int numberFemale = 0;
            conn.Open();
            String statisticQuery2 = "Select Id From Cases where Gender='Female' ";
            SQLiteCommand cmd = new SQLiteCommand(statisticQuery2, conn);

            SQLiteDataReader reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {
                numberFemale++;
            }
            MessageBox.Show(numberFemale.ToString());

            conn.Close();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Covid19CaseRegistrationApp! You have the ability to add a new case ,update an existing, search through all cases , delete a case or use the statistics tab to see some of them and use the beta feature to check the severity of a case. When you add a case in the underlying disease box write 'None' If the subject has no underlying Disease. ");
        }

        private void sToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new Form4().Show();
        }
    }
}
