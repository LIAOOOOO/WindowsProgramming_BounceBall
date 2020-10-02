using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace s1063513_HW5
{
    public partial class Form1 : Form
    {
        Rectangle rect, r1;
        Color c;
        Brush b1, b2;
        Point pos = new Point();
        Point ball = new Point(100, 100);
        Timer _timer = new Timer();

        int vectorX = 1, vectorY = -2, sum = 0;

        public Form1()
        {
            InitializeComponent();
            rect = new Rectangle(0, 50, 200, 200);
            r1 = new Rectangle(100, 250, 25, 10);
            timer2.Interval = 1000; 
            timer1.Enabled = true;
            timer2.Interval = 1000;
            timer1.Interval = 10;
            timer2.Enabled = true;
            sum = 0;
            vectorX = 1; vectorY = -2;
            ball = new Point(100, 100);
            timer2.Start();
            timer1.Start();
            toolStripStatusLabel1.Text = "0";
            toolStripStatusLabel2.Text = "Playing!";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            c = Color.Red;
            toolStripButton1.Checked = true;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = false;
            this.Invalidate();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            c = Color.Green;
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = true;
            toolStripButton3.Checked = false;
            this.Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            sum++;
            toolStripStatusLabel1.Text = sum.ToString();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Interval = 1000;
            timer1.Interval = 10;
            timer2.Enabled = true;
            sum = 0;
            vectorX = 1; vectorY = -2;
            ball = new Point(100, 100);
            timer2.Start();
            timer1.Start();
            toolStripStatusLabel1.Text = "0";
            toolStripStatusLabel2.Text = "Playing!";
            this.Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 175)
                pos = new Point(e.X, 250);
            else
                pos = new Point(175, 250);
            r1 = new Rectangle(pos.X, 250, 25, 10);
            this.Invalidate();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            c = Color.Blue;
            toolStripButton1.Checked = false;
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = true;
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, rect); 
            Graphics g1 = this.CreateGraphics();
            b1 = new SolidBrush(c);
            b2 = new SolidBrush(Color.Red);
            g1.FillEllipse(b1, ball.X, ball.Y, 10, 10);
            g1.FillRectangle(b2, r1);

        }


       

        private void Form1_Load(object sender, EventArgs e)
        {
            c = Color.Red;
            toolStripStatusLabel1.Text = "0";
            toolStripStatusLabel2.Text = "Playing!";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (sum % 5 == 0 && sum > 0)
            {
                sum++;
                if (vectorY > 0)
                    vectorY += 1;
                else
                    vectorY -= 1;
                if (vectorX > 0)
                    vectorX += 1;
                else
                    vectorX -= 1;
            }
            if (ball.X >= 200 || ball.X <= 0)
            {
                vectorX = -vectorX;
            }
            if (ball.Y >= 300 || ball.Y <= 50)
            {
                vectorY = -vectorY;

            }
            if (ball.X >= pos.X && ball.X <= pos.X + 25 && ball.Y >= pos.Y && ball.Y <= pos.Y + 10)
            {
                vectorY = -vectorY;
            }
            if (ball.Y >= 260)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                toolStripStatusLabel2.Text = "Game over!";
                vectorX = 0;
                vectorY = 0;
            }
            ball.X = ball.X + vectorX;
            ball.Y = ball.Y + vectorY;
            this.Invalidate();
        }
    }
}
