using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problemE {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        List<int> list = new List<int>();
        private void Button1_Click(object sender, EventArgs e) {
            textBox4.Text = "";
            list.Clear();
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            for(int i = a; i <= b; i++) {
                list.Add(i);
            }
            string data = textBox3.Text;
            data = data.Replace(',', ' ');
            string[] array = data.Split(' ');
            if (textBox3.Text != "") {
                for (int i = 0; i < array.Length; i++) {
                    list.Add(Convert.ToInt32(array[i]));
                }
            }
            make();
        }
        public void make() {
            for(int i = 0; i < list.Count; i++) {
                string str = Convert.ToString(list[i]);
                int total = 0;
                for (int j = 0; j < str.Length; j++) {
                    int value = (str[j] - '0')*(j+1);
                    total += value;
                }
                total %= 10;
                int[] array = { 0, 7, 4, 1, 8, 5, 2, 9, 6, 3 };
                str += array[total];
                str += "@antu.edu.tw";
                textBox4.Text += str + (i == (list.Count - 1) ? "" : ";");
            }
        }
    }
}//finish at 27min
