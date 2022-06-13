using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Προαιρετικη_2_Π19032
{
    public partial class Add_student : Form
    {
        static String filename;

        public Add_student()
        {
            InitializeComponent();
        }

        public Add_student(String filename)
        {
            InitializeComponent();
            Add_student.filename = filename;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String sname = textBox1.Text;
            String sam = textBox2.Text;
            String sage = textBox3.Text;
            String sdep = textBox4.Text;

            StreamReader sr = new StreamReader(Add_student.filename);
            String filetxt = sr.ReadToEnd();

            bool b = true;

            if (sname.Equals(""))
            {
                MessageBox.Show("Please insert the student's name");
                b = false;

            }

            if (sam.Equals(""))
            {
                MessageBox.Show("Please insert the student's am");
                b = false;

            }
            else if (!sam.StartsWith("p") || sam.Length < 6)
            {
                MessageBox.Show("Incorrect student am");
                b = false;

            }
            else if (filetxt.Contains(sam))
            {
                MessageBox.Show("There is already a student with this am");
                b = false;

            }

            try
            {
                int intsage = int.Parse(sage);

                if (intsage < 18)
                {
                    MessageBox.Show("Please insert a valid age");
                    b = false;
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Please insert a valid age");
                b = false;
            }

            sr.Close();

            if (b)
            {
                StreamWriter sw = File.AppendText(Add_student.filename);
                String details = Environment.NewLine + Environment.NewLine + sname + Environment.NewLine + sam + Environment.NewLine + sage + Environment.NewLine + sdep;
                sw.Write(details);
                sw.Close();
                MessageBox.Show("Successfully added " + sname + "to file!");
            }
        }
    }
}
