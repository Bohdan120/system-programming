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

namespace _06._09
{
    class MyThread
    {
        public void ThreadFunc(object obj)
        {
            ListBox listBox = obj as ListBox;
            for (int i = 0; i <= 10; i++)
            {
                listBox.Invoke(new Action(() => listBox.Items.Add(i)));
            }
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new MyThread().ThreadFunc);
          
            thread.Start(listBox1);
        }
    }
}
