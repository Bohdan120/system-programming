using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sample_15._09_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }
        DateTime lastDate;
        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey currentUserKey = Registry.CurrentUser; RegistryKey MyWindowSettings = null;
            try
            {
                MyWindowSettings = currentUserKey.OpenSubKey("MyProgramTrialTime", true);
                lastDate = Convert.T    oDateTime(MyWindowSettings.GetValue("TrialTime").ToString());
            }
            catch
            {
                MyWindowSettings = currentUserKey.CreateSubKey("MyProgramTrialTime"); lastDate = DateTime.Now.AddSeconds(10);
                MyWindowSettings.SetValue("TrialTime", lastDate.ToString());
            }
            this.Text = $"Ваша пробна версія дійсна до: {lastDate.ToString()}";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now >= lastDate)
            {
                timer1.Stop(); MessageBox.Show("Закінчилася пробна версія!!!!");
                this.Close();
            }
        }
    }
}
