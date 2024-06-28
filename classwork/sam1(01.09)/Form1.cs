using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sam1_01._09_
{
    public partial class Form1 : Form
    {
        public delegate void MyDel();
        int counter;

        public Form1()
        {
            InitializeComponent();
        }

        //Функція зворотнього виклику
        public void TesWhile()
        {
            while(true)
            {
                this.Text = counter++.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyDel d1 = TesWhile;
            d1.BeginInvoke(null, null);
            MessageBox.Show("END");
        }
    }
}
