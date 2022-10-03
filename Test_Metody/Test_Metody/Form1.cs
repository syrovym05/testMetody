using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Metody
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rnd = new Random();
        List<int> seznamCisel = new List<int>();
        List<string> seznamZnaku = new List<string>();        
        List<string> specialni = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDown1.Value;            
            seznamCisel.Clear();            
            seznamZnaku.Clear();
            specialni.Clear();

            textBox1.Text = "";
            int znak;
            string slovo = "";
            bool provedlose = false;
            int pocet = 0;

            for (int i = 0; i < n; i++)
            {
                znak = rnd.Next(32, 128);
                textBox1.Text += (char)znak;
                if (znak >= '0' && znak <= '9')
                {
                    seznamCisel.Add(znak - 48);
                } 

                if((znak >= 'a' && znak <= 'z')||(znak >= 'A' && znak <='Z') || znak == ' ')
                {
                    if (znak == 'a' || znak == 'e') pocet++;
                    if (znak == ' ')
                    {
                        seznamZnaku.Add(slovo);
                        slovo = "";
                        provedlose = true;
                    }
                    else
                    {
                        slovo += (char)znak;
                    }                                                            
                }
                
                if (!((znak >= 'a' && znak <= 'z') || (znak >= 'A' && znak <= 'Z') || znak == ' ' || (znak>='0' && znak <= '9' )))
                {
                    specialni.Add(((char)znak).ToString());
                }

            }
            seznamZnaku.Add(slovo);
            if (provedlose == false)
            {
                //seznamZnaku.Add(slovo);
                label8.Text = "Ne";
            }
            else
            {
                label8.Text = "Ano";
            }

            label9.Text = "" + pocet;
           
            

            VypisList(seznamZnaku, listBox1);
            VypisList(specialni, listBox2);

            VypisList(seznamCisel, listBox3);        //pro ověření medianu
           


            double median;  // 123455
            seznamCisel.Sort();
            if (seznamCisel.Count > 0)
            {
                if (seznamCisel.Count % 2 == 1)
                {
                    median = (double)seznamCisel[(seznamCisel.Count - 1) / 2];

                }
                else   // 1234                
                {
                    median = ((double)seznamCisel[seznamCisel.Count / 2] + (double)seznamCisel[(seznamCisel.Count / 2) - 1]) / 2;

                }
                
                MessageBox.Show("Median: " + median);
            }

            
        }


        private void VypisList(List<string> list, ListBox listBox)
        {
            listBox.Items.Clear();

            foreach(string s in list)
            {
                listBox.Items.Add(s);
            }            
        }

        private void VypisList(List<int> list, ListBox listBox)
        {
            listBox.Items.Clear();

            foreach (int i  in list)
            {
                listBox.Items.Add(i);
            }
        }
    }
}
