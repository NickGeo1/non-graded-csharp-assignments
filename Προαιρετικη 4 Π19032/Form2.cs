using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.Data.SQLite;

namespace Προαιρετικη_4_Π19032
{
    public partial class Form2 : Form
    {
        string image;

        int old_width;
        int old_height;

        bool show_f1 = true;

        Regex rgx_for_email = new Regex("^[a-zA-Z0-9]+@[a-zA-Z]+[.](com|gr)$"); //regex for email

        delegate void del();

        Thread t1; //thread that checks if the register button has to be enabled or disabled       

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            old_width = this.Width;
            old_height = this.Height;

            t1 = new Thread(check_Button);
            t1.Start();
            
            label7.Text = "Insert email"; 
            label8.Text = "Insert username"; 
            label9.Text = "Passwords does not match";
            label10.Text = "Insert password";

            pictureBox1.ImageLocation = "images/avatar1.png";
            pictureBox2.ImageLocation = "images/avatar2.png";
            pictureBox3.ImageLocation = "images/avatar3.png";

            image = pictureBox1.ImageLocation;
        }
        private void Form2_Resize(object sender, EventArgs e)
        {
            int w = this.Width - old_width;
            int h = this.Height - old_height;

            button1.Location = new Point(button1.Location.X + w, button1.Location.Y + h);

            pictureBox2.Location = new Point(this.Width / 2 - pictureBox2.Width / 2, pictureBox2.Location.Y);
            pictureBox1.Location = new Point(pictureBox2.Location.X - 177, pictureBox1.Location.Y);
            pictureBox3.Location = new Point(pictureBox2.Location.X + 177, pictureBox3.Location.Y);

            textBox1.Location = new Point(this.Width / 2 - textBox1.Width / 2, textBox1.Location.Y);
            textBox2.Location = new Point(this.Width / 2 - textBox2.Width / 2, textBox2.Location.Y);
            textBox3.Location = new Point(this.Width / 2 - textBox3.Width / 2, textBox3.Location.Y);
            textBox4.Location = new Point(this.Width / 2 - textBox4.Width / 2, textBox4.Location.Y);

            label7.Location = new Point(textBox4.Location.X + 213, label7.Location.Y);
            label8.Location = new Point(textBox1.Location.X + 213, label8.Location.Y);
            label9.Location = new Point(textBox3.Location.X + 213, label9.Location.Y);
            label10.Location = new Point(textBox2.Location.X + 213, label10.Location.Y);

            label2.Location = new Point(this.Width / 2 - label2.Width / 2, label2.Location.Y);
            label3.Location = new Point(this.Width / 2 - label3.Width / 2, label3.Location.Y);
            label4.Location = new Point(this.Width / 2 - label4.Width / 2, label4.Location.Y);
            label5.Location = new Point(this.Width / 2 - label5.Width / 2, label5.Location.Y);
            label6.Location = new Point(this.Width / 2 - label6.Width / 2, label6.Location.Y);

            radioButton1.Location = new Point(pictureBox1.Location.X - 20, radioButton1.Location.Y);
            radioButton2.Location = new Point(pictureBox2.Location.X - 20, radioButton2.Location.Y);
            radioButton3.Location = new Point(pictureBox3.Location.X - 20, radioButton3.Location.Y);

            old_width = this.Width;
            old_height = this.Height;
        }

        private void enable_Button()
        {
            button1.Enabled = true;
        }
        private void disable_Button()
        {
            button1.Enabled = false;
        }

        private void check_Button()
        {
            del enable = enable_Button;
            del disable = disable_Button;

            while (true)
            {
                if (label7.Text.Equals("") && label8.Text.Equals("") &&
                               label9.Text.Equals("") && label10.Text.Equals(""))
                {
                    button1.Invoke(enable);
                }
                else
                {
                    button1.Invoke(disable);
                }
            }
           
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Contains(" "))
            {
                label8.Text = "Invalid username.It cannot contain any space\ncharacters";

            }else if(textBox1.Text.Equals(""))
            {
                label8.Text = "Insert username";               
            }
            else
            {
                label8.Text = "";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {          
            if (textBox2.Text.Equals(""))
            {
                label10.Text = "Insert password";
            }
            else
            {               
                label10.Text = "";
            }

            if (textBox2.Text.Equals(textBox3.Text) && !textBox2.Text.Equals(""))
                label9.Text = "";
            else
                label9.Text = "Passwords does not match";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!textBox3.Text.Equals(textBox2.Text) || textBox3.Text.Equals(""))
            {
                label9.Text = "Passwords does not match";
            }
            else
            {
                label9.Text = "";
            }
        }
        
        private void textBox4_TextChanged(object sender, EventArgs e)
        {            
            if (textBox4.Text.Equals(""))
            {
                label7.Text = "Insert email";
            }           
            else if (!rgx_for_email.IsMatch(textBox4.Text))
            {
                label7.Text = "Invalid email format";
            }
            else
            {
                label7.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source=Users.db;Version=3;";
            SQLiteConnection conn = new SQLiteConnection(connectionstring);

            conn.Open();
            SQLiteCommand cmd1 = new SQLiteCommand("Select Username,Email from Users where Email=@email or Username=@name", conn);
            cmd1.Parameters.AddWithValue("@email", textBox4.Text);
            cmd1.Parameters.AddWithValue("@name", textBox1.Text);
            SQLiteDataReader reader = cmd1.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("There is already a user with this email or/and username!");
            }
            else
            {
                SQLiteCommand cmd2 = new SQLiteCommand("INSERT INTO Users(Username,Password,Email,avatar,times) VALUES(@name,@pass,@email,@avatar,@times)", conn);
                cmd2.Parameters.AddWithValue("@email", textBox4.Text);
                cmd2.Parameters.AddWithValue("@name", textBox1.Text);
                cmd2.Parameters.AddWithValue("@pass", textBox2.Text);
                cmd2.Parameters.AddWithValue("@avatar", image);
                cmd2.Parameters.AddWithValue("@times", 1);
        
                cmd2.ExecuteNonQuery();
                MessageBox.Show(textBox1.Text + " has been successfuly registered.Details have been stored into database!");

                new Form4(textBox1.Text, textBox2.Text, textBox4.Text, image, 1).Show();
                show_f1 = false;
                this.Close();
            }
                                
            conn.Close();

        }       

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            image = pictureBox1.ImageLocation;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            image = pictureBox2.ImageLocation;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            image = pictureBox3.ImageLocation;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            t1.Abort();
            if(show_f1)
                Application.OpenForms[0].Show();
        }
    }
}
