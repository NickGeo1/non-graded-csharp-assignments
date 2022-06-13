using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace προαιρετικη_1
{
    class User
    {
        public String username;
        public String password;
        public String email;
        public String age;
        public String registration_number;
        public String address;
        public String department;

        public User(String un, String pass, String age, String email, String reg_num, String adrs, String dep)
        {
            this.username = un;
            this.password = pass;
            this.age = age;
            this.email = email;
            this.registration_number = reg_num;
            this.address = adrs;
            this.department = dep;
        }
    }
    public partial class Form1 : Form
    {
         
         List<User> user_list = new List<User>();

        public Form1()
        {
            InitializeComponent();
        }
  

        private void Form1_Load(object sender, EventArgs e)
        {
            User u1 = new User("Nikolaos", "egg123", "21", "nikolas@anything.com", "34567", "alkiviadou 23", "Computer Science");
            User u2 = new User("Dimitris", "sofa456", "20", "jim@anything.com", "99002", "aristeas 13", "Maritime studies");
            User u3 = new User("Georgios", "food999", "22", "george@anything.com", "95672", "zakinthou 153", "Maritime studies");
            User u4 = new User("Markos", "funny546", "19", "markos100@anything.com", "38472", "limnou 40", "Industrial Administration and Technology");
            User u5 = new User("Aleksandra", "stardust200", "22", "aleksia@anything.com", "19227", "Dimitriadoy 28", "Economic Studies ");

            user_list.Add(u1);
            user_list.Add(u2);
            user_list.Add(u3);
            user_list.Add(u4);
            user_list.Add(u5);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (User u in user_list)
            {
                if (u.username.Equals(textBox1.Text) && u.password.Equals(textBox2.Text)
                && u.email.Equals(textBox3.Text))
                {
                    MessageBox.Show("Successfull login!");
                    Form2 f2 = new Form2(u.username, u.password, u.age, u.email, u.registration_number, u.address, u.department);
                    f2.Show();
                    return;
                }
            }

            MessageBox.Show("Invalid User Details!");
        }

        
    }
}
