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

namespace samp_3_05._05_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ThreadFunction(object obj)
        {
            Mutex mutex = obj as Mutex;
            mutex.WaitOne();
            DialogResult dialogResult = MessageBox.Show($"Thread Start: {Thread.CurrentThread.ManagedThreadId}");
            
            if(dialogResult == DialogResult.OK)
                mutex.ReleaseMutex();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Thread[] threads = new Thread[5];
            Mutex mutex = new Mutex(false);
            
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(ThreadFunction);
                threads[i].Start(mutex);
            }
        }
    }
}
