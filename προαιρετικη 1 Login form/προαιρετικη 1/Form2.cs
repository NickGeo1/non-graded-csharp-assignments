using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace προαιρετικη_1
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(String un, String pass, String age, String email, String reg_num, String adrs, String dep)
        {
            InitializeComponent();
            textBox1.Text = un;
            textBox2.Text = reg_num ;
            textBox3.Text = age;
            textBox4.Text = email;
            textBox5.Text = adrs;
            textBox6.Text = dep;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
