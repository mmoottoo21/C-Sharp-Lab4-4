using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Four_Files
{
    public partial class Form1 : Form
    {
        struct MySt
        {
            public string Name;
            public string Sername;
            public string First;
            public string Osenk;
        }
        public Form1()
        {
            InitializeComponent();
        }

        static bool IsNum(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c)) return false;
            }
            return true;
        }

        static bool IsString(string s)
        {
            foreach (char c in s)
            {
                if (Char.IsDigit(c)) return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0 || textBox4.TextLength == 0)
            {
                MessageBox.Show("Не корректное заполнение формы!");
            }
            else
            {
                MySt Val = new MySt();
                Val.Name = textBox1.Text;
                Val.Sername = textBox2.Text;
                Val.First = textBox3.Text;
                Val.Osenk = textBox4.Text;


                string path = @"All.txt";
                if (!File.Exists(path))
                {
                    MessageBox.Show("Файл создан");
                }
                using (StreamWriter sw = File.AppendText(path))
                {
                    string log = $"{Val.First} - За вступительные:{Val.Name} {Val.Sername}: {Val.Osenk}" + Environment.NewLine;
                    sw.Write(log);
                    sw.Close();
                    MessageBox.Show("Данные записаны в файл!");
                }
            }
            //Очистка всех текс боксов
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(GroupBox))
                    foreach (Control d in c.Controls)
                        if (d.GetType() == typeof(TextBox))
                            d.Text = string.Empty;

                if (c.GetType() == typeof(TextBox))
                    c.Text = string.Empty;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!IsString(textBox1.Text))
            {
                MessageBox.Show("Имя строка!");
                textBox1.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!IsString(textBox2.Text))
            {
                MessageBox.Show("Фамилия строка!");
                textBox2.Clear();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!IsNum(textBox3.Text))
            {
                MessageBox.Show("Оценка цифра!");
                textBox3.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", "All.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string pathout = @"All.txt";
            if (!File.Exists(pathout))
            {
                MessageBox.Show(" нет!");
            }
            using (var sr = new StreamReader(pathout))
            {
                var str = sr.ReadToEnd();
                textBox5.Text = str.ToString();
            }
        }
    }
}
