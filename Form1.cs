using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba_4
{
    public partial class Form1 : Form
    {
        List<Sweets> sweetsList = new List<Sweets>();
        public Form1()
        {
            InitializeComponent();
            ShowInfo(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.sweetsList.Clear();
            var rnd = new Random();
            for (var i = 0; i < 10; ++i)
            {
                switch (rnd.Next() % 3)
                {
                    case 0:
                        this.sweetsList.Add(Chocolate.Generate());
                        break;
                    case 1:
                        this.sweetsList.Add(Bakery.Generate());
                        break;
                    case 2:
                        this.sweetsList.Add(Fruits.Generate());
                        break;
                }
            }
            ShowInfo();
        }
       

        private void ShowInfo()
        {
            
            int chocolateCount = 0;
            int bakeryCount = 0;
            int fruitsCount = 0;

            richTextBox1.Clear();
            foreach (var sweets in this.sweetsList)
            {
                
                if (sweets is Chocolate) 
                {
                    chocolateCount += 1;
                }
                else if (sweets is Bakery)
                {
                    bakeryCount += 1;
                }
                else if (sweets is Fruits)
                {
                    fruitsCount += 1;
                }
                richTextBox1.Text += sweets.GetInfo() + "\n ";
            }

           
            txtInfo.Text = "Шоколад\tВыпечка\tФрукты"; 
            txtInfo.Text += "\n";
            txtInfo.Text += String.Format("{0}\t\t{1}\t\t{2}", chocolateCount, bakeryCount, fruitsCount);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.sweetsList.Count == 0)
            {
                txtOut.Text = "Пусто";
                return;
            }

            var sweets = this.sweetsList[0];
            this.sweetsList.RemoveAt(0);

            
            txtOut.Text = sweets.GetInfo();

            ShowInfo();
        }
    }
}
