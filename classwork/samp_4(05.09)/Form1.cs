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

namespace samp_4_05._09_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ThreadFunction(object obj)
        {
            Semaphore semaphore = obj as Semaphore;
            semaphore.WaitOne();
            DialogResult dialogResult = MessageBox.Show($"Thread Start: {Thread.CurrentThread.ManagedThreadId}");

            if (dialogResult == DialogResult.OK)
                semaphore.Release();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Thread 
        }
    }
}
