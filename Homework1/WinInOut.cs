using System;
using System.Windows.Forms;
using System.Drawing;


namespace NO._5
{
    public class WinInOut:Form
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        TextBox txt1 = new TextBox();
        TextBox txt2 = new TextBox();
        Button btn = new Button();
        Label lbl = new Label();
       
        public void init()
        {
            this.Controls.Add(txt1);
            this.Controls.Add(txt2);
            this.Controls.Add(btn);
            this.Controls.Add(lbl);
            txt1.Dock = System.Windows.Forms.DockStyle.Top;
            txt2.Dock = System.Windows.Forms.DockStyle.Top;
            btn.Dock = System.Windows.Forms.DockStyle.Fill;
            lbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            btn.Text = "求乘积";
            lbl.Text = "结果显示";
            this.Size = new Size(400, 250);

            btn.Click += new System.EventHandler(button1_Click);
        }
        public void button1_Click(object sender,EventArgs e)
        {
            string a = txt1.Text;
            double c = double.Parse(a);
            string b = txt2.Text; 
            double d = double.Parse(b);
            double pro = c * d;
            lbl.Text = d + "乘积为" + pro;
        }
        static void Main()
        {
            WinInOut f = new WinInOut();
            f.Text = "WinInOut";
            f.init();
            Application.Run(f);
        }
    }
}
