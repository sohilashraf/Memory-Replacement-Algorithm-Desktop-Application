using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace os_project
{
    // PARTIONS AND PROCRSSES
    public partial class Form2 : Form
    {
        int flag = 0, flag2 = 0;
        public class actor
        {
            public int n,nn,px,fw=0;
            public int x, y, w, h;
        }
        public int df = 0;
        public static Form2 instance;

       public List<actor> par = new List<actor>();
        public List<actor> pro = new List<actor>();

        public Form2()
        {
            InitializeComponent();
            instance = this;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(flag==0&&par.Count>0)
            {
                par.Clear();
              
                flag = 1;
            }
            int ct = 0;
            string s = textBox1.Text;
            if(s==" " || s=="")
            {
                MessageBox.Show("Please enter a number");
                textBox1.Text = "";

            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '0' || s[i] == '1' || s[i] == '2' || s[i] == '3' || s[i] == '4' || s[i] == '5' || s[i] == '6' || s[i] == '7' || s[i] == '8' || s[i] =='9')
                    {
                        ct++;
                    }
                }
                if(ct== s.Length)
                {
                    actor pnn = new actor();
                    pnn.n = int.Parse(s);
                    par.Add(pnn);
                    textBox1.Text = "";
                }
                else {
                    MessageBox.Show("Please enter only numbers");
                    textBox1.Text = "";
                }

            }


            flag = 1;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flag2 == 0 && pro.Count > 0)
            {
               
                pro.Clear();
               
                flag2 = 1;
            }
            int ct = 0;
            string s = textBox2.Text;
            if (s == " " || s=="")
            {
                MessageBox.Show("Please enter a number");
                textBox2.Text = "";

            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '0' || s[i] == '1' || s[i] == '2' || s[i] == '3' || s[i] == '4' || s[i] == '5' || s[i] == '6' || s[i] == '7' || s[i] == '8' || s[i] == '9')
                    {
                        ct++;
                    }
                }
                if (ct == s.Length)
                {
                    actor pnn = new actor();
                    pnn.n = int.Parse(s);
                    pro.Add(pnn);
                    textBox2.Text = "";

                }
                else
                {
                    MessageBox.Show("Please enter only numbers");
                    textBox2.Text = "";

                }

            }
            flag2 = 1;
        }
       // FIRST FIT
        private void button3_Click(object sender, EventArgs e)
        {
            flag = 0;
            flag2 = 0;
            df = 1;
            Form3 form3 = new Form3();

            form3.ShowDialog();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            flag = 0;
            flag2 = 0;
            df = 2;
            Form3 form3 = new Form3();

            form3.ShowDialog();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();

            form1.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            flag = 0;
            flag2 = 0;
            df = 3;
            Form3 form3 = new Form3();

            form3.ShowDialog();
        }
    }
}
