using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace problemC {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) {
            Random random = new Random();
            for (int i = 0; i <= 1; i++) {
                TextBox t1 = (TextBox)this.Controls["textBox" + (i * 2 + 1)];
                TextBox t2 = (TextBox)this.Controls["textBox" + (i * 2 + 2)];
                int neg = random.Next(0, 2);
                int number = random.Next(0, 128);
                number *= (neg == 0 ? 1 : -1);
                t1.Text = convert(number);
                //t2.Text = Convert.ToString(number);
            }
        }

        public String convert(int number) {
            String result = "";
            if (number >= 0) {
                result = Convert.ToString(number, 2).PadLeft(7, '0');
                return "0" + result;
            }
            else {
                number = Math.Abs(number);
                number = number ^ 127;
                number += 1;
                result = Convert.ToString(number, 2).PadLeft(7,'0');
                return "1" + result;
            }
        }

        public int convertToNumber(String str) {
            string build = str.Substring(str.Length - 7);
            Console.WriteLine(build);
            int a = Convert.ToInt32(build, 2);
            if (str[0] == '0') {
                return a;
            }
            else {
                if(a == 0) {
                    return -128;
                }
                a -= 1;
                return -(a ^ 127);
            }
        }

        public string add(string a1, string a2) {
            int carry = 0;
            string result = "";
            for(int i = 7; i >= 0; i--) {
                Console.WriteLine(a1[i] + "," + a2[i]);
                if(a1[i] == '0' && a2[i] == '0' && carry == 0) {
                    result = 0 + result;
                }
                else if(a1[i] == '0' && a2[i] == '1' && carry == 0) {
                    result = 1 + result;
                    carry = 0;
                }
                else if(a1[i] == '1' && a2[i] == '0' && carry == 0) {
                    result = 1 + result;
                    carry = 0;
                }
                else if(a1[i] == '1' && a2[i] == '1' && carry == 0) {
                    result = 0 + result;
                    carry = 1;
                }
                else if (a1[i] == '0' && a2[i] == '1' && carry == 1) {
                    result = 0 + result;
                    carry = 1;
                }
                else if (a1[i] == '1' && a2[i] == '0' && carry == 1) {
                    result = 0 + result;
                    carry = 1;
                }
                else if (a1[i] == '1' && a2[i] == '1' && carry == 1) {
                    result = 1 + result;
                    carry = 1;
                }else if(a1[i] == '0' && a2[i] == '0' && carry == 1) {
                    result = 1 + result;
                    carry = 0;
                }
            }
            result.Reverse();
            return result;
        }

        private void Button2_Click(object sender, EventArgs e) {
            string a = textBox1.Text;
            string b = textBox3.Text;
            textBox5.Text = add(a, b);
        }

        private void Button3_Click(object sender, EventArgs e) {
            int a = convertToNumber(textBox1.Text);
            int b = convertToNumber(textBox3.Text);
            int c = convertToNumber(textBox5.Text);
            textBox2.Text = convertToNumber(textBox1.Text).ToString();
            textBox4.Text = convertToNumber(textBox3.Text).ToString();
            textBox6.Text = convertToNumber(textBox5.Text).ToString();
            if(a + b != c) {
                if(a > 0 && b > 0 && c < 0) {
                    textBox7.Text = "溢位";
                    textBox8.Text = "溢位";
                }
                else if(a < 0 && b < 0 && c >= 0){
                    textBox7.Text = "不足位";
                    textBox8.Text = "不足位";
                }
            }
        }
    }
}//finish at 136min
