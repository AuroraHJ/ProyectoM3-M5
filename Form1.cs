using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private static string[] palabra;

        public Form1()
        {
            InitializeComponent();
        }



        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK){

                //Aqui va el codigo para abrir y leer el archivo

                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            Host();
        }
        
        private void Host()
        {
            FileStream fs = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(textBox1.Text);

            String linia;
            linia = sr.ReadLine();
            while (linia.Equals("</Hosts>"))
            {
                linia = sr.ReadLine();

                if (linia.Equals("</Fullname>"))
                {
                    comboBox2.Items.Add(GetELementData(linia));
                    linia = sr.ReadLine();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.CheckFileExists) {
                ReadFile();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1 == null || comboBox2 == null)
            {
                MessageBox.Show("No has seleccionado ningun dato");
            }
            
                
        }

        private void ReadFile()
        {
            
            FileStream fs = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(textBox1.Text);

            String linia; 
            linia = sr.ReadLine();
            List<string> Lista = new List<string>();
            List<string> Lista2 = new List<string>();
            while (!linia.Equals("</SolidarityAtHome>"))
            {
                linia = sr.ReadLine();

                if(linia.Equals("<Hosts>") || linia.Equals("<Foods>") || linia.Equals("<Refugees>") || linia.Equals("<FoodsDelivered>"))
                {
                    comboBox1.Items.Add(GetElementName(linia));
                    linia = sr.ReadLine();
                }
            }
            
        }
        private static string [] Splitcaracter(string cadena)
        {
            
             string[] palabra = cadena.Split('<', '>');
            
                
            
            return palabra;
        }

        private static string GetElementName(string cadena)
        {
            string[] paraula;

            string elementname;

            paraula = Splitcaracter(cadena);

            elementname = paraula[1];

            return elementname;
        }

        private static string GetELementData(string cadena)
        {
            string[] paraula;

            string posicion;

            paraula = Splitcaracter(cadena);

            posicion = paraula[2];

            return posicion;
        }
    }
}
