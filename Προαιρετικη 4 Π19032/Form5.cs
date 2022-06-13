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
    public partial class Form5 : Form
    {
        int old_width;
        int old_height;

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            old_width = this.Width;
            old_height = this.Height;

            string connectionstring = "Data Source=Users.db;Version=3;";
            SQLiteConnection conn = new SQLiteConnection(connectionstring);

            conn.Open();

            SQLiteCommand cmd = new SQLiteCommand("Select * from Users",conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                richTextBox1.AppendText("Username: " + reader.GetString(0) + Environment.NewLine + "Email: " + reader.GetString(2) + Environment.NewLine +
                    "Avatar image path: " + reader.GetString(3) + Environment.NewLine + "Times visited: " + reader.GetInt32(4).ToString() + Environment.NewLine +
                    Environment.NewLine);
            }

            conn.Close();
        }

        private void Form5_Resize(object sender, EventArgs e)
        {
            int h = this.Height - old_height;
            int w = this.Width - old_width;

            richTextBox1.Size = new Size(richTextBox1.Width + w, richTextBox1.Height + h);

            old_width = this.Width;
            old_height = this.Height;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[0].Show();
        }
    }
}
