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

namespace Dátum
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string kivFile = openFileDialog1.FileName;
                string szovegg = File.ReadAllText(kivFile);
                string[] adat = szovegg.Split(';');
                textBox1.Text = adat[0];
                richTextBox1.Text = adat[1];
                dateTimePicker1.Text= adat[2];
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Nem adtál meg nevet!");
                return;
            }
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Nem adtál meg szöveget!");
                return;
            }
            saveFileDialog1.Filter = "Szöveg fájl|*.txt| Vesszővel tagolt szövegfájl (*.csv) |*.csv|minden fájl|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string szoveg = string.Join(";", textBox1.Text, richTextBox1.Text, dateTimePicker1.Value);
                string kFile = saveFileDialog1.FileName;
                File.WriteAllText(kFile, szoveg);
                MessageBox.Show("A kiválasztott fájl:" + kFile);
                textBox1.Text = "";
                richTextBox1.Text = "";

            }
            else
            {
                MessageBox.Show("Nincs kiválasztva!");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
