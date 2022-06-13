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

namespace Προαιρετικη_4_Π19032
{
    public partial class Form3 : Form
    {
        bool show_f1 = true;

        int old_width;
        int old_height;

        public Form3()
        {
            InitializeComponent();
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            old_width = this.Width;
            old_height = this.Height;
        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            int h = this.Height - old_height;
            int w = this.Width - old_width;

            button1.Location = new Point(button1.Location.X + w, button1.Location.Y + h);

            textBox1.Location = new Point(this.Width / 2 - textBox1.Width / 2, this.Height / 2 - 55);
            textBox2.Location = new Point(this.Width / 2 - textBox2.Width / 2, this.Height / 2 + 35);

            label1.Location = new Point(textBox1.Location.X - 5, textBox1.Location.Y - label1.Height);
            label2.Location = new Point(textBox2.Location.X - 5, textBox2.Location.Y - label2.Height);

            old_width = this.Width;
            old_height = this.Height;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(!textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source=Users.db;Version=3;";
            SQLiteConnection conn = new SQLiteConnection(connectionstring);

            conn.Open();
            SQLiteCommand cmd1 = new SQLiteCommand("Select Email,avatar,times from Users where Username=@name and Password=@pass", conn);
            cmd1.Parameters.AddWithValue("@pass", textBox2.Text);
            cmd1.Parameters.AddWithValue("@name", textBox1.Text);
            SQLiteDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Welcome back "+ textBox1.Text+"!");

                SQLiteCommand cmd2 = new SQLiteCommand("update Users set times = times + 1 WHERE Username=@name", conn);
                cmd2.Parameters.AddWithValue("@name", textBox1.Text);
                cmd2.ExecuteNonQuery();

                new Form4(textBox1.Text, textBox2.Text, reader.GetString(0), reader.GetString(1), reader.GetInt32(2)+1).Show();
                show_f1 = false;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid details!");
            }

            conn.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
          if(show_f1)
            Application.OpenForms[0].Show();
        }

        
    }
}
