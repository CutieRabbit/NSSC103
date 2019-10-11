using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problemF {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) {
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            int z = Convert.ToInt32(textBox3.Text);
            int ans = 1;
            for(int i = 0; i < y; i++) {
                ans *= x;
                ans %= z;
            }
            ans %= z;
            label4.Text = "餘數=" + ans;
        }

        private void Button2_Click(object sender, EventArgs e) {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label4.Text = "餘數=";
        }

        private void Button3_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }
    }
}//finish at 33min