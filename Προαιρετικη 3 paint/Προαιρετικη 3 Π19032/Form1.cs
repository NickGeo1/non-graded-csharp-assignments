using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Προαιρετικη_3_Π19032
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p;
        bool freestyle= false;
        int fsx, fsy;
        int selection = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            p = new Pen(Color.Black);

            pictureBox5.ImageLocation = "step4.jpg";
            pictureBox4.ImageLocation = "index.png";
            pictureBox3.ImageLocation = "index1.png";
            pictureBox2.ImageLocation = "images.png";
            pictureBox1.ImageLocation = "images1.jpg";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selection = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selection = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selection = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selection = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                p.Color = colorDialog1.Color;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            p.Width = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            p.Width = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            p.Width = 3;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            fsx = e.X;
            fsy = e.Y;

            if (selection==1)
                freestyle = true;
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (freestyle)
            {
                g.DrawLine(p, fsx, fsy, e.X, e.Y);
                fsx = e.X;
                fsy = e.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (selection)
            {
                case 1:
                    freestyle = false;
                    break;

                case 2:
                    g.DrawLine(p, fsx, fsy, e.X, e.Y);
                    break;

                case 3:
                    int height = e.Y - fsy;
                    int width = e.X - fsx;

                    if (height >= 0 && width >= 0)
                        g.DrawRectangle(p, fsx, fsy, width, height);

                    else if (height < 0 && width >= 0)
                        g.DrawRectangle(p, fsx, e.Y, width, -height);

                    else if (height < 0 && width < 0)
                        g.DrawRectangle(p, e.X, e.Y, -width, -height);

                    else
                        g.DrawRectangle(p, e.X, fsy, -width, height);

                    break;

                case 4:
                    g.DrawEllipse(p, fsx, fsy, e.X - fsx, e.Y - fsy);
                    break;
            }
        }      
    }
}