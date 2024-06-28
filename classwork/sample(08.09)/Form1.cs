using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sample_08._09_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //long Sum(long a, long b)
        //{
        //    long sum = 0;
        //    for (long i = a; i < b; i++)
        //    {
        //        sum += i;
        //    }
        //    return sum; 
        //}

        //void SomeOperation()
        //{
        //    for (int i = 0; i < 10000; i++)
        //    {
        //        Text = i.ToString();
        //    }
        //}

        //async void SomeOperationAsync()
        //{
        //    await Task.Run(() => SomeOperation());
        //}

        //async Task<long> SumAsync(long a, long b)
        //{
        //    return await Task<long>.Run(() => Sum(a, b));
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //SomeOperationAsync();
            //MessageBox.Show("Main");    
            //long res = await SumAsync(1, 2000000000);
            //textBox1.Text = res.ToString();
            //var request = WebRequest.Create("https://www.google.com/");
            //request.Timeout = 2000;
            //request.Method = "GET";

            ////Варіант1
            //request.BeginGetResponse((asyncResult) =>
            //{
            //    var response = (HttpWebResponse)request.EndGetResponse(asyncResult);
            //    textBox1.Invoke(new Action(() =>
            //    {
            //        textBox1.Text = response.Headers.ToString();
            //    }));

            //}, null);

            //Варіант 3
            
        }
    }
}
