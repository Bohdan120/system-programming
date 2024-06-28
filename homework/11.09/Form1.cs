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

namespace _11._09
{
    public partial class Form1 : Form
    {
        private bool generating = false;
        private Thread numberThread;
        private Thread letterThread;
        private Thread symbolThread;
        private void GenerateLetters(object obj)
        {
            TextBox textBox = obj as TextBox;
            Random random = new Random();
            string letters = "abcdefghijklmnopqrstuvwxyz";
            while (generating)
            {
                textBox.Invoke(new Action(() => textBox.Text += letters[random.Next(letters.Length)]));
                Thread.Sleep(25);
            }
        }
        private void GenerateNumbers(object obj)
        {
            TextBox textBox = obj as TextBox;
            Random random = new Random();
            while (generating)
            {
                textBox.Invoke(new Action(() => textBox.Text += random.Next(10).ToString()));
                Thread.Sleep(25);
            }
        }
        private void GenerateSymbols(object obj)
        {
            TextBox textBox = obj as TextBox;
            Random random = new Random();
            string symbols = "!@#$%^&*()";
            while (generating)
            {
                textBox.Invoke(new Action(() => textBox.Text += symbols[random.Next(symbols.Length)]));
                Thread.Sleep(25);
            }
        }

        private void StartThreads()
        {
            generating = true;

            numberThread = new Thread(() => GenerateNumbers(textBox1));
            letterThread = new Thread(() => GenerateLetters(textBox2));
            symbolThread = new Thread(() => GenerateSymbols(textBox3));

            

            numberThread.Start();
            letterThread.Start();
            symbolThread.Start();
        }
        private void StopThreads()
        {
            generating = false;
            numberThread.Join();
            letterThread.Join();
            symbolThread.Join();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (generating)
            {
                StopThreads();
                button1.Text = "Generate";
            }
            else
            {
                StartThreads();
                button1.Text = "Stop";
            }
        }
    }
}
