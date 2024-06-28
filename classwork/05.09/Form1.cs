using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05._09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() =>
            {
                textBox1.Invoke(new Action(() => { textBox1.Text = "Pv221"; }));               

            });
            thread.Start(); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
          
                    listBox1.Invoke(new Action(() =>
                    {
                        for (int i = 0; i <= 10; i++)
                        {
                            listBox1.Items.Add(i);
                        }
                    }));
                
            }).Start();
        }
    }
}
