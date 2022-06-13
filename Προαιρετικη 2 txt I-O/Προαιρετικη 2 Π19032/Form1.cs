using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Προαιρετικη_2_Π19032
{
    public partial class Student_Management : Form
    {
        public static List<Student> st_list = new List<Student>();

        public Student_Management()
        {
            InitializeComponent();
        }

        public static String Search_File(String name, String filename, String what_to_find, StreamReader sr)
        {
            
            StringBuilder sb = new StringBuilder(null);

            while (sb.ToString() != name)
            {
                sb.Clear();
                sb.Append(sr.ReadLine());
            }
            if (what_to_find.Equals("AM"))
            {               
                return sr.ReadLine();

            }else if (what_to_find.Equals("age"))
            {
                sr.ReadLine();
                return sr.ReadLine();
            }
            else
            {
                sr.ReadLine();
                sr.ReadLine();
                return sr.ReadLine();
            }
        }

        static void AddUsers(String filename)
        {
            
            StreamReader sr = new StreamReader(filename);

            try
            {
                String All = sr.ReadToEnd();
                if (All.Equals("")|| All.Equals(" ")) //If file is empty add 4 Students
                {
                    Student s1 = new Student("Pavlos", "p22333", 21, "Computer Science");
                    Student s2 = new Student("Maria", "p26789", 20, "Maritime Studies");
                    Student s3 = new Student("Giannhs", "p26700", 20, "Maritime Studies");
                    Student s4 = new Student("Dimitra", "p23549", 22, "Economic Studies");

                    st_list.AddRange(new Student[] { s1, s2, s3, s4 });

                    StringBuilder sb = new StringBuilder(null);

                    sr.Close();
                    StreamWriter sw = new StreamWriter(filename);

                    foreach (Student s in st_list)
                    {                  
                        sb.Append(s.name);
                        sb.Append(Environment.NewLine);
                        sb.Append(s.am);
                        sb.Append(Environment.NewLine);
                        sb.Append(s.age);
                        sb.Append(Environment.NewLine);
                        sb.Append(s.dep);
                        if (!s.name.Equals("Dimitra"))
                        {
                            sb.Append(Environment.NewLine);
                            sb.Append(Environment.NewLine);
                        }
                        sw.Write(sb);
                        sb.Clear();
                    }

                    sw.Close();
                    MessageBox.Show("'" + filename + "' file successfully loaded and 4 Students were added!");
                }
                else //Else keep it as is
                {
                    sr.Close();
                    MessageBox.Show("'"+filename+"' file successfully loaded!");
                    return;
                }
            }
            catch (IOException ex)
            {
                sr.Close();
                MessageBox.Show(ex.Message);
            }          
        }

        private void Student_Management_Load(object sender, EventArgs e)
        {
            AddUsers("Students.txt");
            textBox1.Text = "Students.txt";
                     
        }

                

  

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Please add your students txt file!");
            }
            
            else
            {
                Student_Details sd = new Student_Details(textBox1.Text);
                sd.Show();
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Please add your students txt file in order to add a new student!");
            }
            else
            {
                Add_student adds = new Add_student(textBox1.Text);
                adds.Show();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                Student_Management.AddUsers(textBox1.Text);
            }
            else
            {
                MessageBox.Show("Please select your Students txt file!");
                textBox1.Text = "";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class Student
    {
        public String name;
        public String am;
        public int age;
        public String dep;

        public Student (String n, String am, int a, String d)
        {
            this.name = n;
            this.am = am;
            this.age = a;
            this.dep = d;
        }

     }

}
