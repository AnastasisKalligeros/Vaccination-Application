using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.OleDb;

namespace VaccinationApp
{
    public partial class Form2 : Form
    {
        String connectionString = "Data Source=Covid19.db;Version=3;";
        SQLiteConnection conn;
        String gender;
        Boolean modify;
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox6.Text = System.DateTime.Now.ToString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);
            label10.Visible = false;
            textBox8.Visible = false;
            modify = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (modify == false)
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox3.Text) == false && String.IsNullOrEmpty(textBox4.Text) == false && String.IsNullOrEmpty(textBox5.Text) == false && String.IsNullOrEmpty(textBox6.Text) == false && String.IsNullOrEmpty(textBox7.Text) == false) {
                    conn.Open();
                    if (radioButton1.Checked)
                    {
                        gender = "Male";
                    }
                    else if (radioButton2.Checked)
                    {
                        gender = "Female";

                    }
                    String insertQuery = "Insert into Cases(Fullname,Email,Gender,Birthdate,UnderlyingDisease,Address,RegistrationDate,PhoneNumber) values('" + textBox1.Text + "','" + textBox2.Text + "','" + gender + "','" + textBox7.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox3.Text + "')";

                    SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
                    int count = cmd.ExecuteNonQuery();
                    //MessageBox.Show(count.ToString()); to see if cmd has executed and how many rows were affected
                    conn.Close();
                    MessageBox.Show("New case submitted.");
                   
                    String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Covid19.mdb";
                    OleDbConnection connection = new OleDbConnection(connectionString);
                    connection.Open();
                    String query = "Insert into Cases(Fullname,Email,Gender,Birthdate,UnderlyingDisease,Address,RegistrationDate,PhoneNumber) values('" + textBox1.Text + "','" + textBox2.Text + "','" + gender + "','" + textBox7.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox3.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    int count1 = command.ExecuteNonQuery();
                    connection.Close();
                    Close();
                }

                else
                {
                    MessageBox.Show("Please fill all of the information.");
                }
                
            }
            else
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox3.Text) == false && String.IsNullOrEmpty(textBox4.Text) == false && String.IsNullOrEmpty(textBox5.Text) == false && String.IsNullOrEmpty(textBox6.Text) == false && String.IsNullOrEmpty(textBox7.Text) == false && String.IsNullOrEmpty(textBox8.Text) == false)
                {
                    conn.Open();
                    if (radioButton1.Checked)
                    {
                        gender = "Male";
                    }
                    else if (radioButton2.Checked)
                    {
                        gender = "Female";

                    }
                    String updateQuery = "Update Cases SET Fullname=@Fullname, Email=@Email, Gender=@Gender, Birthdate=@Birthdate, UnderlyingDisease=@UnderlyingDisease, Address=@Address, RegistrationDate=@RegistrationDate, PhoneNumber=@PhoneNumber WHERE ID=@ID";


                    SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn);
                    cmd.Parameters.AddWithValue("@ID", int.Parse(textBox8.Text));
                    cmd.Parameters.AddWithValue("@Fullname", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@Birthdate", textBox7.Text);
                    cmd.Parameters.AddWithValue("@UnderlyingDisease", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox4.Text);
                    cmd.Parameters.AddWithValue("@RegistrationDate", textBox6.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", textBox3.Text);
                    int count = cmd.ExecuteNonQuery();
                    
                    conn.Close();
                    if (count > 0)
                    {
                        String connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Covid19.mdb";
                        OleDbConnection connection = new OleDbConnection(connectionString);
                        connection.Open();
                        
                        String updateQuery1 = "Update Cases SET Fullname='" + textBox1.Text + "', Email='" + textBox2.Text + "', Gender='" + gender + "', Birthdate='" + textBox7.Text + "', UnderlyingDisease='" + textBox5.Text + "', Address='" + textBox4.Text + "', RegistrationDate='" + textBox6.Text + "', PhoneNumber='" + textBox3.Text + "' WHERE ID=@ID1";


                        OleDbCommand command = new OleDbCommand(updateQuery1, connection);
                        command.Parameters.AddWithValue("@ID1", int.Parse(textBox8.Text));
                        
                        int count1 = command.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show(" Case updated.");
                    }
                    else
                    {
                        MessageBox.Show("Invalid id");
                    }

                    Close();
                }
                else
                {
                    MessageBox.Show("Please fill all of the information.");
                }

            }

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if(!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label10.Visible = true;
            textBox8.Visible = true;
            modify = true;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
