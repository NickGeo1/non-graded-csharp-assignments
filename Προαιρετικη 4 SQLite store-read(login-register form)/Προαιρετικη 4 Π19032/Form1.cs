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
    public partial class Form1 : Form
    {
        int old_width;
        int old_height;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            old_width = this.Width;
            old_height = this.Height;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int w = this.Width - old_width;
            int h = this.Height - old_height;

            groupBox1.Size = new Size(groupBox1.Width + w, groupBox1.Height + h);
            
            button1.Location = new Point((groupBox1.Width / 2) - (button1.Width / 2), button1.Location.Y);
            button2.Location = new Point(button2.Location.X + w, button2.Location.Y + h);
            button3.Location = new Point(button3.Location.X, button3.Location.Y + h);

            old_width = this.Width;
            old_height = this.Height;
                         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            this.Hide();
        }
    }
}
