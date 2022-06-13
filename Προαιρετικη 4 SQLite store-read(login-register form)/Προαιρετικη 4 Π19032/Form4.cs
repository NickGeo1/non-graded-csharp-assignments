using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Προαιρετικη_4_Π19032
{
    public partial class Form4 : Form
    {
        String username;
        String password;
        String email;
        String image;
        int times;

        public Form4(String username, String password, String email, String image, int times)
        {
            InitializeComponent();
            this.username = username;
            this.password = password;
            this.email = email;
            this.image = image;
            this.times = times;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = image;

            label3.Text = "Welcome " + username +"!";
            label2.Text = "Email: "+ email;
            label4.Text = "Password: " + password;
            label6.Text = times.ToString();
        }

        private void Form4_Resize(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(this.Width / 2 - pictureBox1.Width / 2, pictureBox1.Location.Y);

            label1.Location = new Point(pictureBox1.Location.X/2 - label1.Width/2, label1.Location.Y);
            label2.Location = new Point(label1.Location.X, label2.Location.Y);
            label4.Location = new Point(label1.Location.X, label4.Location.Y);
            label5.Location = new Point((this.Width + pictureBox1.Location.X + pictureBox1.Width - label5.Width)/2, label5.Location.Y);
            label6.Location = new Point(label5.Location.X, label6.Location.Y);
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[0].Show();
        }

        
    }
}
