using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static os_project.Form2;

namespace os_project
{

    public partial class Form4 : Form
    {
        class CFifo
        {
            public int num;
            public int[] arr;

        }
        int f = 0;
        List<CFifo> opt = new List<CFifo>();
        public int[] arr;
        int n;
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            validate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ct = 0;
            string s = textBox1.Text;
            if (s == " " || s == "")
            {
                MessageBox.Show("Please enter a number");
                textBox1.Text = "";

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
                if (ct == s.Length && f==2)
                {
                    FIFO();
                }
                else
                {
                    if (f != 2)
                    {
                        MessageBox.Show("Please press Add");

                    }
                }

            }
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        void validate ()
        {
            int ct = 0;
            string s = textBox1.Text;
            if (s == " " || s == "")
            {
                MessageBox.Show("Please enter a number");
                textBox1.Text = "";

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
                    s= textBox1.Text;
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Please enter only numbers");
                    textBox1.Text = "";
                }

            }
        }
        void FIFO()
        {
          
            string s = textBox1.Text;
            arr = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                arr[i] = (int)Char.GetNumericValue(s[i]);

            }

            HashSet<int> ss = new HashSet<int>(n);
            Queue indexes = new Queue();

            // Start from initial page
            int page_faults = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                // Check if the set can hold more pages
                if (ss.Count < n)
                {
                    // Insert it into set if not present
                    // already which represents page fault
                    if (!ss.Contains(arr[i]))
                    {
                        ss.Add(arr[i]);

                        // increment page fault
                        page_faults++;

                        // Push the current page into the queue
                        indexes.Enqueue(arr[i]);
                    }
                }
                else
                {
                    // Check if current page is not already
                    // present in the set
                    if (!ss.Contains(arr[i]))
                    {
                        //Pop the first page from the queue
                        int val = (int)indexes.Peek();

                        indexes.Dequeue();

                        // Remove the indexes page
                        ss.Remove(val);

                        // insert the current page
                        ss.Add(arr[i]);

                        // push the current page into
                        // the queue
                        indexes.Enqueue(arr[i]);

                        // Increment page faults
                        page_faults++;
                    }
                }
            }
            this.label1.Text ="PAGE FAULT: "+  page_faults;
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            int ct = 0;

            string k = textBox2.Text;

            if (k == " " || k == "")
            {
                MessageBox.Show("Please enter a number");
                textBox2.Text = "";
            }
            else
            {

                for (int i = 0; i < k.Length; i++)
                {
                    if (k[i] == '0' || k[i] == '1' || k[i] == '2' || k[i] == '3' || k[i] == '4' || k[i] == '5' || k[i] == '6' || k[i] == '7' || k[i] == '8' || k[i] == '9')
                    {
                        ct++;
                    }
                }
                if(ct == k.Length)
                {
                    n = int.Parse(textBox2.Text);
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Please enter only numbers");
                    textBox2.Text = "";
                }
            }

          
        }
        static bool search(int key, List<int> fr)
        {
            for (int i = 0; i < fr.Count; i++)
            {
                if (fr[i] == key)
                    return true;
            }
            return false;
        }
        static int predict(int[] pg, List<int> fr, int pn, int index)
        {

            // Store the index of pages which are going
            // to be used recently in future
            int res = -1;
            int farthest = index;
            for (int i = 0; i < fr.Count; i++)
            {
                int j;
                for (j = index; j < pn; j++)
                {
                    if (fr[i] == pg[j])
                    {
                        if (j > farthest)
                        {
                            farthest = j;
                            res = i;
                        }
                        break;
                    }
                }

                // If a page is never referenced in future,
                // return it.
                if (j == pn)
                    return i;
            }

            // If all of the frames were not in future,
            // return any of them, we return 0. Otherwise
            // we return res.
            return (res == -1) ? 0 : res;
        }

        void OPT()
        {
            this.label1.Text = "";
           string s = textBox1.Text;
            arr = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                arr[i] = (int)Char.GetNumericValue(s[i]);

            }
            List<int> fr = new List<int>();

            // Traverse through page reference array
            // and check for miss and hit.
            int hit = 0;
            for (int i = 0; i < s.Length; i++)
            {

                // Page found in a frame : HIT
                if (search(arr[i], fr))
                {
                    hit++;
                    continue;
                }

                // Page not found in a frame : MISS

                // If there is space available in frames.
                if (fr.Count < n)
                    fr.Add(arr[i]);

                // Find the page to be replaced.
                else
                {
                    int j = predict(arr, fr, s.Length, i + 1);
                    fr[j] = arr[i];
                }
            }
            this.label1.Text = "PAGE FAULT: " + (arr.Length - hit) + "";
        }
        private void button3_Click(object sender, EventArgs e)
        {


            int ct = 0;
            string s = textBox1.Text;
            if (s == " " || s == "")
            {
                MessageBox.Show("Please enter a number");
                textBox1.Text = "";

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
                if (ct == s.Length && f==2)
                {
                    OPT();
                }
                else
                {
                    if (f != 2)
                    {
                        MessageBox.Show("Please press Add");

                    }
                }

            }


         
            //for(int i=0;i<opt.Count;i++) { 
            //    if(i==0)
            //    {
            //        opt[i].arr[i] = opt[i].num;

            //    }
            //    else if(i<frames)
            //    {
            //        opt[i].arr = opt[i - 1].arr;
            //        opt[i].arr[] = opt[i].num;
            //    }


            //}
            //for(int i=0;i<frames;i++ )
            //{

            //}
        }
        void LRU()
        {
            this.label1.Text = "";
            string s = textBox1.Text;
            arr = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                arr[i] = (int)Char.GetNumericValue(s[i]);

            }
            HashSet<int> ss = new HashSet<int>(n);

            // To store least recently used indexes
            // of pages.
            Dictionary<int,
                       int> indexes = new Dictionary<int,
                                                     int>();

            // Start from initial page
            int page_faults = 0;
            for (int i = 0; i < s.Length; i++)
            {
                // Check if the set can hold more pages
                if (ss.Count < n)
                {
                    // Insert it into set if not present
                    // already which represents page fault
                    if (!ss.Contains(arr[i]))
                    {
                        ss.Add(arr[i]);

                        // increment page fault
                        page_faults++;
                    }

                    // Store the recently used index of
                    // each page
                    if (indexes.ContainsKey(arr[i]))
                        indexes[arr[i]] = i;
                    else
                        indexes.Add(arr[i], i);
                }

                // If the set is full then need to
                // perform lru i.e. remove the least
                // recently used page and insert
                // the current page
                else
                {
                    // Check if current page is not
                    // already present in the set
                    if (!ss.Contains(arr[i]))
                    {
                        // Find the least recently used pages
                        // that is present in the set
                        int lru = int.MaxValue, val = int.MinValue;

                        foreach (int itr in ss)
                        {
                            int temp = itr;
                            if (indexes[temp] < lru)
                            {
                                lru = indexes[temp];
                                val = temp;
                            }
                        }

                        // Remove the indexes page
                        ss.Remove(val);

                        //remove lru from hashmap
                        indexes.Remove(val);

                        // insert the current page
                        ss.Add(arr[i]);

                        // Increment page faults
                        page_faults++;
                    }

                    // Update the current page index
                    if (indexes.ContainsKey(arr[i]))
                        indexes[arr[i]] = i;
                    else
                        indexes.Add(arr[i], i);
                }

            }
            this.label1.Text += "PAGE FAULT: " + page_faults;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ct = 0;
            string s = textBox1.Text;
            if (s == " " || s == "")
            {
                MessageBox.Show("Please enter a number");
                textBox1.Text = "";

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
                if (ct == s.Length && f==2)
                {
                    LRU();
                   
                }
                else
                {
                    if (f != 2)
                    {
                        MessageBox.Show("Please press Add");

                    }
                }

            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            int ct = 0;

            string k = textBox2.Text;

            if (k == " " || k == "")
            {
                MessageBox.Show("Please enter a number");
                textBox2.Text = "";
            }
            else
            {

                for (int i = 0; i < k.Length; i++)
                {
                    if (k[i] == '0' || k[i] == '1' || k[i] == '2' || k[i] == '3' || k[i] == '4' || k[i] == '5' || k[i] == '6' || k[i] == '7' || k[i] == '8' || k[i] == '9')
                    {
                        ct++;
                    }
                }
                if (ct == k.Length)
                {
                    n = int.Parse(textBox2.Text);
                    f ++;
                }
                else
                {
                    MessageBox.Show("Please enter only numbers");
                    textBox2.Text = "";
                }
            }



            ct = 0;
            string s = textBox1.Text;
            if (s == " " || s == "")
            {
                MessageBox.Show("Please enter a number");
                textBox1.Text = "";

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
                    f++;
                }
                else
                {
                    MessageBox.Show("Please enter only numbers");
                    textBox1.Text = "";
                }

            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();

            form1.ShowDialog();
            this.Close();
        }
    }

}


