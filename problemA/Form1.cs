using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSSC103 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs ee) {
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            double c = Convert.ToDouble(textBox3.Text);
            double d = Convert.ToDouble(textBox4.Text);
            double e = Convert.ToDouble(textBox5.Text);
            double f = Convert.ToDouble(textBox6.Text);
            if(a > 1 || b > 1 || c > 1 || d > 1 || e > 1 || f > 1) {
                textBox7.Text = "無解";
                return;
            }
            if (a < 0 || b < 0 || c < 0 || d < 0 || e < 0 || f < 0) {
                textBox7.Text = "無解";
                return;
            }
            textBox7.Text = String.Format("在臺北市的上班族遲到的機率為{0:0.000}", a * d + b * e + c * f);
        }

        private void Button2_Click(object sender, EventArgs ee) {
            double a = Convert.ToDouble(textBox1.Text);
            double b = Convert.ToDouble(textBox2.Text);
            double c = Convert.ToDouble(textBox3.Text);
            double d = Convert.ToDouble(textBox4.Text);
            double e = Convert.ToDouble(textBox5.Text);
            double f = Convert.ToDouble(textBox6.Text);
            if (a > 1 || b > 1 || c > 1 || d > 1 || e > 1 || f > 1) {
                textBox7.Text = "無解";
                return;
            }
            if (a < 0 || b < 0 || c < 0 || d < 0 || e < 0 || f < 0) {
                textBox7.Text = "無解";
                return;
            }
            textBox7.Text = String.Format("如果已知有一個人上班遲到，那他是自己開車上班的機率為{0}", (c*f) / (a * d + b * e + c * f));
        }

        private void Button3_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }
    }
}//finish at 12min