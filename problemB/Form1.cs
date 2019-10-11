using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace problemB {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        List<KeyValuePair<double, double>> list = new List<KeyValuePair<double, double>>();
        List<List<KeyValuePair<double, double>>> group = new List<List<KeyValuePair<double, double>>>();
        int[] groupRecord = new int[1000];

        private void Button1_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "(*.txt)|*.txt";
            ofd.ShowDialog();
            String path = ofd.FileName;
            StreamReader sr = new StreamReader(path);
            string line;
            int index = 0;
            line = sr.ReadLine();
            while ((line = sr.ReadLine()) != null) {
                String[] split = line.Split(' ');
                listBox1.Items.Add(index);
                listBox2.Items.Add(split[0]);
                listBox3.Items.Add(split[1]);
                list.Add(new KeyValuePair<double, double>(Convert.ToDouble(split[0]), Convert.ToDouble(split[1])));
                index++;
            }
            for(int i = 0; i < 3; i++) {
                group.Add(new List<KeyValuePair<double, double>>());
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            for(int i = 0; i < list.Count; i++) {
                group[i%3].Add(list[i]);
                groupRecord[i] = i%3;
            }
            for(int r = 0; r < 200; r++) {
                KeyValuePair<double,double>[] average = new KeyValuePair<double, double>[3];
                for(int i = 0; i < 3; i++) {
                    average[i] = getGroupA(group[i]);
                    Console.WriteLine(average[i]);
                }
                for(int i = 0; i < list.Count; i++) {
                    int a = placeGroup(average, list[i]);
                    int b = groupRecord[i];
                    group[b].Remove(list[i]);
                    group[a].Add(list[i]);
                    groupRecord[i] = a;
                }
            }
            for(int i = 0; i < list.Count; i++) {
                String str = i + "在第" + groupRecord[i] + "組";
                listBox4.Items.Add(str);
            }
            for(int i = 0; i < 3; i++) {
                TextBox text = (TextBox)this.Controls["textBox" + (1 + i)];
                for(int j = 0; j < list.Count; j++) {
                    if(groupRecord[j] == i) {
                        text.Text += Convert.ToString(j).PadRight(4, ' ') + Convert.ToString(list[i].Key).PadRight(4, ' ') + Convert.ToString(list[i].Value).PadRight(4, ' ') + Environment.NewLine;
                    }
                }
            }
        }

        private KeyValuePair<double, double> getGroupA(List<KeyValuePair<double, double>> list) {
            double a = 0, b = 0;
            for(int i = 0; i < list.Count; i++) {
                a += list[i].Key;
                b += list[i].Value;
            }
            return new KeyValuePair<double, double>(a/(list.Count*1.0), b/(list.Count*1.0));
        }

        private int placeGroup(KeyValuePair<double, double>[] aver, KeyValuePair<double, double> data) {
            double d = Double.MaxValue;
            int group = 0;
            for (int i = 0; i < 3; i++) {
                double a = aver[i].Key - data.Key;
                double b = aver[i].Value - data.Value;
                double c = Math.Sqrt(a * a + b * b);
                if(c < d) {
                    group = i;
                    d = c;
                }
            }
            return group;
        }
    }
}//finish at 174min