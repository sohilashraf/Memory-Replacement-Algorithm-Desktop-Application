using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace os_project
{
    public partial class Form3 : Form
    {
        
        class actor
        {
            public int x, y, w, h,n;
        }
       
          List<actor> Prorec = new List<actor>();
        List<actor> Prowait = new List<actor>();

        public Form3()
        {
            InitializeComponent();
           
            this.Size = new System.Drawing.Size(1000, 800);
            this.Paint += Form3_Paint;
           
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            if(Form2.instance.df ==1)
            {
                drawsenceFirstFit();
            }
            if (Form2.instance.df == 2 || Form2.instance.df == 3)
            {
                drawsenceBestFit();
            }

        }
        void firstfit()
        {
            this.Text = " First Fit";

            int fw = 0;
            for (int i = 0; i < Form2.instance.pro.Count; i++)
            {
                for (int j = 0; j < Form2.instance.par.Count; j++)
                {
                    if (Form2.instance.par[j].nn >= Form2.instance.pro[i].n)
                    {
                        
                        actor pnn = new actor();
                        pnn.x= Form2.instance.par[j].px;
                        pnn.y = Form2.instance.par[j].y ;
                        pnn.w = Form2.instance.par[j].w / 5;
                        pnn.h = Form2.instance.par[j].h;
                        Form2.instance.par[j].px += pnn.w+5;
                        pnn.n = Form2.instance.pro[i].n;
                        fw = 1;
                        Form2.instance.par[j].nn -= Form2.instance.pro[i].n;
                        Prorec.Add(pnn);
                        break;

                    }
                }
                if(fw==0)
                {
                    actor pnn = new actor();
                    pnn.n = Form2.instance.pro[i].n;
                    Prowait.Add(pnn);
                    
                }
                fw = 0;
            }

        }
       
        void bestfit()
        {
            this.Text = " Best Fit";

            int fw = 0;
            int pos=0;
            for (int i = 0; i < Form2.instance.pro.Count; i++)
            {
                
                int min = 100000;

                for (int j = 0; j < Form2.instance.par.Count; j++)
                {
                    if(Form2.instance.par[j].nn > Form2.instance.pro[i].n)
                    {
                        if(Form2.instance.par[j].nn<min)
                        {
                            fw = 1;

                            pos = j;
                            min = Form2.instance.par[j].nn;
                        }
                    }


                   
                }
                if (fw == 0)
                {
                    actor pnn = new actor();
                    pnn.n = Form2.instance.pro[i].n;
                    Prowait.Add(pnn);

                }
                else
                {
                    actor pnn = new actor();
                    pnn.x = Form2.instance.par[pos].px;
                    pnn.y = Form2.instance.par[pos].y;
                    pnn.w = Form2.instance.par[pos].w / 5;
                    pnn.h = Form2.instance.par[pos].h;
                    Form2.instance.par[pos].px += pnn.w + 5;
                    pnn.n = Form2.instance.pro[i].n;
                    fw = 1;
                    Form2.instance.par[pos].nn -= Form2.instance.pro[i].n;
                    Prorec.Add(pnn);

                }
                fw = 0;
            }
        }

        void WosrtFit()
        {
            this.Text = " Worst Fit";
            int fw = 0;
            int pos = 0;
            for (int i = 0; i < Form2.instance.pro.Count; i++)
            {

                int max = -100000;

                for (int j = 0; j < Form2.instance.par.Count; j++)
                {
                    if (Form2.instance.par[j].nn > Form2.instance.pro[i].n)
                    {
                        if (Form2.instance.par[j].nn > max)
                        {
                            fw = 1;

                            pos = j;
                            max = Form2.instance.par[j].nn;
                        }
                    }



                }
                if (fw == 0)
                {
                    actor pnn = new actor();
                    pnn.n = Form2.instance.pro[i].n;
                    Prowait.Add(pnn);

                }
                else
                {
                    actor pnn = new actor();
                    pnn.x = Form2.instance.par[pos].px;
                    pnn.y = Form2.instance.par[pos].y;
                    pnn.w = Form2.instance.par[pos].w / 5;
                    pnn.h = Form2.instance.par[pos].h;
                    Form2.instance.par[pos].px += pnn.w + 5;
                    pnn.n = Form2.instance.pro[i].n;
                    fw = 1;
                    Form2.instance.par[pos].nn -= Form2.instance.pro[i].n;
                    Prorec.Add(pnn);

                }
                fw = 0;
            }
        }
        
        private void Form3_Load(object sender, EventArgs e)
        {
            int x = 20;
            int y = 200;
            for (int i = 0; i < Form2.instance.par.Count; i++)
            {
                Form2.instance.par[i].w = 200/* + (Form2.instance.par[i].n / 10)*/;
                Form2.instance.par[i].h = 100;
                Form2.instance.par[i].x = x;
                Form2.instance.par[i].y = y;
                Form2.instance.par[i].px = x +5;
                Form2.instance.par[i].nn = Form2.instance.par[i].n;
                

                x += Form2.instance.par[i].w+10;
                

            }
            this.Size = new System.Drawing.Size(x +50, 400);

            if(Form2.instance.df==1)
            {
                firstfit();
                drawsenceFirstFit();

            }
            if (Form2.instance.df == 2)
            {
                bestfit();
                drawsenceBestFit();

            }

            if (Form2.instance.df == 3)
            {
                WosrtFit();
                drawsenceBestFit();
            }




        }
        void drawsenceFirstFit()
        {
            Graphics g  = this.CreateGraphics();
            g.Clear(Color.FromArgb(170, 200, 167));
           
            for (int i = 0; i < Form2.instance.par.Count; i++)
            { SolidBrush b = new SolidBrush(Color.FromArgb(39, 37, 55));
              g.FillRectangle(b, Form2.instance.par[i].x, Form2.instance.par[i].y, Form2.instance.par[i].w, Form2.instance.par[i].h);
                g.DrawString(Form2.instance.par[i].n + "", new Font("system", 20), Brushes.White, Form2.instance.par[i].x + Form2.instance.par[i].w / 2 -10, Form2.instance.par[i].y - 50);
                if(Form2.instance.par[i].n != Form2.instance.par[i].nn)
                    g.DrawString(Form2.instance.par[i].nn + "", new Font("system", 20), Brushes.White, Form2.instance.par[i].x + Form2.instance.par[i].w / 2 - 10, Form2.instance.par[i].y + Form2.instance.par[i].h +20);

            }

            for (int i = 0; i < Prorec.Count; i++)
            {
                SolidBrush b = new SolidBrush(Color.FromArgb(186, 144, 198));
                g.FillRectangle(b, Prorec[i].x, Prorec[i].y, Prorec[i].w, Prorec[i].h);
                g.DrawString(Prorec[i].n + "", new Font("system", 15), Brushes.White, Prorec[i].x + Prorec[i].w / 2 - 20, Prorec[i].y + Prorec[i].h/2);
            }
            int y = 40;
            if(Prowait.Count>0)
            {
                g.DrawString("Processes Must Wait: ", new Font("system", 20), Brushes.Gray, 20, y);
                y += 30;
                for (int i = 0; i < Prowait.Count; i++)
                {
                    g.DrawString(Prowait[i].n + "", new Font("system", 20), Brushes.White, 20, y);
                    y += 30;
                }
            }
            
        }

        void drawsenceBestFit()
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.FromArgb(170, 200, 167));

            for (int i = 0; i < Form2.instance.par.Count; i++)
            {
                SolidBrush b = new SolidBrush(Color.FromArgb(39, 37, 55));
                g.FillRectangle(b, Form2.instance.par[i].x, Form2.instance.par[i].y, Form2.instance.par[i].w, Form2.instance.par[i].h);
                g.DrawString(Form2.instance.par[i].n + "", new Font("system", 20), Brushes.White, Form2.instance.par[i].x + Form2.instance.par[i].w / 2 - 10, Form2.instance.par[i].y - 50);
                if (Form2.instance.par[i].n != Form2.instance.par[i].nn)
                    g.DrawString(Form2.instance.par[i].nn + "", new Font("system", 20), Brushes.White, Form2.instance.par[i].x + Form2.instance.par[i].w / 2 - 10, Form2.instance.par[i].y + Form2.instance.par[i].h + 20);

            }
            
            for (int i = 0; i < Prorec.Count; i++)
            {
                SolidBrush b = new SolidBrush(Color.FromArgb(186, 144, 198));
                g.FillRectangle(b, Prorec[i].x, Prorec[i].y, Prorec[i].w, Prorec[i].h);
                g.DrawString(Prorec[i].n + "", new Font("system", 15), Brushes.White, Prorec[i].x + Prorec[i].w / 2 - 20, Prorec[i].y + Prorec[i].h / 2);
            }







            int y = 40;
            if (Prowait.Count > 0)
            {
                g.DrawString("Processes Must Wait: ", new Font("system", 20), Brushes.Gray, 20, y);
                y += 30;
                for (int i = 0; i < Prowait.Count; i++)
                {
                    g.DrawString(Prowait[i].n + "", new Font("system", 20), Brushes.White, 20, y);
                    y += 30;
                }
            }
           

        }

    }
}
