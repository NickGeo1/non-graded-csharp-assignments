using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proairetiki5
{
    public partial class Form1 : Form
    {
        int start_x;
        int start_y;

        int old_width;
        int old_height;
        
        bool move;

        static List<Control> PictureboxList = new List<Control>();
        static List<Point> pbstartpoints = new List<Point>();
        static List<Point> pboldpoints = new List<Point>(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            foreach (Control c in this.Controls)
            {
                if (c is PictureBox)
                    PictureboxList.Add(c);
            }

            foreach (PictureBox p in PictureboxList)
            {
                p.MouseDown += new MouseEventHandler(pb_mouseDown);
                p.MouseMove += new MouseEventHandler(pb_mouseMove);
                p.MouseUp += new MouseEventHandler(pb_mouseUp);

                pbstartpoints.Add(p.Location);
            }

            setpb();
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            BackgroundImage = null;

            setpb();
        }
        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            old_width = this.Width;
            old_height = this.Height;

            pboldpoints.Clear();

            foreach (PictureBox p in PictureboxList)
            {
                pboldpoints.Add(p.Location);
            }            
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            BackgroundImage = Image.FromFile("images/cb.jpg");
        }

        private void resetGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            float f = 0;
            String last;

            for (int i = 0; i < PictureboxList.Count; i++)
            {
                f = float.Parse(PictureboxList[i].Tag.ToString());
                PictureboxList[i].Top = (int)(f * (this.Height - 37));

                last = PictureboxList[i].Name.Substring(PictureboxList[i].Name.Length - 1);
                PictureboxList[i].Left = (this.Width - 16) * int.Parse(last.ToString()) / 8;

                pbstartpoints[i] = new Point(PictureboxList[i].Left, PictureboxList[i].Top);
            }
        }

        private void setpb() {

            float f = 0;
            String last;

            for (int i=0; i<PictureboxList.Count; i++)
            {
                PictureboxList[i].Size = new Size((this.Width - 37) / 8, (this.Height - 37) / 8);

                if(PictureboxList[i].Top == pbstartpoints[i].Y && PictureboxList[i].Left == pbstartpoints[i].X)
                {
                    f = float.Parse(PictureboxList[i].Tag.ToString());
                    PictureboxList[i].Top = (int)(f * (this.Height - 37));
                
                    last = PictureboxList[i].Name.Substring(PictureboxList[i].Name.Length - 1);
                    PictureboxList[i].Left = (this.Width - 16) * int.Parse(last.ToString()) / 8;

                    pbstartpoints[i] = new Point(PictureboxList[i].Left, PictureboxList[i].Top);
                }
                else
                {
                    PictureboxList[i].Location = new Point(pboldpoints[i].X * this.Width / old_width, pboldpoints[i].Y * this.Height / old_height);    
                    pboldpoints[i] = PictureboxList[i].Location;
                }               
            }
            old_width = this.Width;
            old_height = this.Height;
        }

        private void pb_mouseDown(object sender, MouseEventArgs e) {

            move = true;

            start_x = e.X;
            start_y = e.Y;
        }

        private void pb_mouseMove(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).BringToFront();
            if (move)
            {
                ((PictureBox)sender).Location = new Point(((PictureBox)sender).Location.X + e.X - start_x, ((PictureBox)sender).Location.Y + e.Y - start_y);
            }
        }

        private void pb_mouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }           
    }
}
