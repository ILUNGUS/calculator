using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Diagnostics;


namespace Calculator
{
    
    public partial class Form1 : Form
    {
        public bool a = false, b = false, iscluch = false, firstznak = true, m = false, ravno = false;
        public string znak, first, second;
        public double M;

        public Form1()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (!ravno)
            {
                double n = Convert.ToDouble(textBox1.Text);
                if (n == 0)
                {
                    textBox1.Text = "Деление на ноль невозможно";
                    textBox2.Text = "";
                    firstznak = true;

                }
                else
                {
                    n = 1 / n;
                    textBox1.Text = Convert.ToString(n);
                }
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text += ",";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(!ravno)
            {
                double n;
                n = Convert.ToDouble(textBox1.Text);
                n = -n;
                textBox1.Text = n.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!ravno)
            {
                double c, res;
                c = Convert.ToDouble(textBox1.Text);
                if (c < 0)
                {
                    textBox1.Text = "Неверный ввод";
                }
                else
                {
                    res = Math.Sqrt(c);
                    textBox1.Text = res.ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            M = Convert.ToDouble(textBox1.Text);
            a = true;
            m = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (m)
            {
                M -= Convert.ToDouble(textBox1.Text);
                a = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (m && !ravno)
            {
                textBox1.Text = Convert.ToString(M);
                a = true;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (!ravno)
            {
                second = textBox1.Text;
            }
            ravno = true;
            a = true;
            Operation(first, second, znak);
            firstznak = true;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (m)
            {
                M += Convert.ToDouble(textBox1.Text);
                a = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            firstznak = true;
            a = false;
            ravno=false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!firstznak && !ravno)
            {
                double n1;
                n1 = Convert.ToDouble(textBox1.Text);
                n1 /= 100;
                second = Convert.ToString(n1);
                textBox2.Text += " " + second;
                textBox1.Text = second;
                Operation(first, second,znak);
                b = true;

            }
        }

        public void  Operation(string z, string v, string c)
        {
            double res, n1, n2;
            n1 = Convert.ToDouble(z);
            n2 = Convert.ToDouble(v);
            if (c == "+")
            {
                res = n1 + n2;
                if (!ravno)
                {
                    first = Convert.ToString(res);
                    a = true;
                }
                else
                {
                    textBox2.Text = first + " " + znak + " " + second + " " + "=";
                    first = Convert.ToString(res);
                    textBox1.Text = first;
                    a= true;
                }


                
            }
            else if (c == "-")
            {
                res = n1 - n2;
                if (!ravno)
                {
                    first = Convert.ToString(res);
                    a = true;
                }
                else
                {
                    textBox2.Text = first + " " + znak + " " + second + " " + "=";
                    first = Convert.ToString(res);
                    textBox1.Text = first;
                    a = true;
                }



            }
            else if (c == "*")
            {
                res = n1 * n2;
                if (!ravno)
                {
                    first = Convert.ToString(res);
                    a = true;
                }
                else
                {
                    textBox2.Text = first + " " + znak + " " + second + " " + "=";
                    first = Convert.ToString(res);
                    textBox1.Text = first;
                    a = true;
                }



            }
            else if (c == "/")
            {
                if (n2 == 0)
                {
                    iscluch = true;
                    a = true;
                    first = "Деление на ноль невозможно";

                }
                else
                {
                    res = n1 / n2;

                    if (!ravno)
                    {
                        first = Convert.ToString(res);
                        a = true;
                    }
                    else
                    {
                        textBox2.Text = first + " " + znak + " " + second + " " + "=";
                        first = Convert.ToString(res);
                        textBox1.Text = first;
                        a = true;
                    }
                }



            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (textBox1.Text == "0")
                textBox1.Text = button.Text;
            else if(b)
            {
                textBox1.Text = button.Text;
                textBox2.Text = first + " " + znak;
                a = false;
                b = false;
            }
            else if (a)
            {
                if (!ravno)
                {
                    textBox1.Text = button.Text;
                    a = false;
                }
                else
                {
                    textBox1.Text = button.Text;
                    a = false;
                    textBox2.Text = "";
                    ravno = false;
                    first = "";
                    second = "";
                }
            }
            else
                textBox1.Text += button.Text;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            if (!ravno)
            {
                if (firstznak == false)
                {
                    Operation(first, textBox1.Text, znak);
                    if (iscluch != true)
                    {
                        znak = but.Text;
                        a = true;
                        textBox2.Text = first + " " + znak;
                        second = textBox1.Text;
                        textBox1.Text = first;
                    }
                    else
                    {
                        textBox1.Text = first;
                        textBox2.Text = "";
                        first = "";
                        a = true;
                        firstznak = true;
                        iscluch = false;
                    }
                }
                else
                {
                    first = textBox1.Text;
                    second = textBox1.Text;
                    firstznak = false;
                    znak = but.Text;
                    textBox2.Text = first + " " + znak;
                    a = true;
                }
            }
        }
    }
}
