using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cayley

{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double th_right = 30 * Math.PI / 180;
        double th_left = 20 * Math.PI / 180;
        double per_right = 0.6;
        double per_left = 0.7;
        double k = 0.8;
        public Form1()
        {
            InitializeComponent();
            this.AutoScaleBaseSize = new Size(6, 14);
            this.ClientSize = new Size(800, 600);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = e.Graphics;
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);

        }



        private void drawCayleyTree(int n,
                double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x0 + k * leng * Math.Cos(th);
            double y2 = y0 + k * leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            drawLine(x0, y0, x2, y2);
            drawCayleyTree(n - 1, x1, y1, per_right * leng, th + th_right);

            drawCayleyTree(n - 1, x2, y2, per_left * leng, th - th_left);
        }
        private void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(
                Pens.Blue,
                (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            per_left = Convert.ToDouble(textBox1.Text);
            per_right = Convert.ToDouble(textBox2.Text);
            k = Convert.ToDouble(textBox3.Text);
            th_left = Convert.ToDouble(textBox4.Text) * Math.PI / 180;
            th_right = Convert.ToDouble(textBox5.Text) * Math.PI / 180;
            this.Invalidate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
