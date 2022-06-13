using System;
using System.CodeDom.Compiler;
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
    public partial class Student_Details : Form
    {     
        static String filename;

        public Student_Details()
        {
            InitializeComponent();
        }

        public Student_Details(string filename)
        {
            InitializeComponent();
            Student_Details.filename = filename;

            StringBuilder names = new StringBuilder(null);
            StreamReader sr = new StreamReader(filename);

            try
            {
                int students = 0;

                while (!(sr.EndOfStream)) //while we are not already at the bottom of the file
                {
                    names.Append("     ");
                    names.Append(sr.ReadLine());                   
                    names.Append(Environment.NewLine);
                    students++;

                    for (int i = 0; i < 4; i++) //Go to next name and read it
                        sr.ReadLine();
                }

                richTextBox1.Text = names.ToString();
                label6.Text = "Number of students: " + students;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sr.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("")) 
            {                
                int i = 0;

                while (!richTextBox1.Lines[i].Equals(""))
                {
                    if (richTextBox1.Lines[i].Equals("     "+textBox1.Text))
                    {
                        StreamReader sr1 = new StreamReader(Student_Details.filename);
                        textBox2.Text = Student_Management.Search_File(textBox1.Text, Student_Details.filename, "AM", sr1);    //These functions are searching the file and they return the corresponding 
                        sr1.Close();                                                                           //AM,age or department depents on the name that the user gave

                        StreamReader sr2 = new StreamReader(Student_Details.filename);
                        textBox3.Text = Student_Management.Search_File(textBox1.Text, Student_Details.filename, "age", sr2); 
                        sr2.Close();

                        StreamReader sr3 = new StreamReader(Student_Details.filename);
                        textBox4.Text = Student_Management.Search_File(textBox1.Text, Student_Details.filename, "department", sr3);
                        sr3.Close();

                        return;
                    }

                    i++;
                }

                MessageBox.Show("Please insert a correct student's name");
            }
            else
            {
                MessageBox.Show("Please insert a student's name");
            }
        }

        private void Student_Details_Load(object sender, EventArgs e)
        {
            
        }
    }
}
