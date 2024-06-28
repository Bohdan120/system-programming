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

namespace _13._09_Sample_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                RegistryKey currentKeyUser = Registry.CurrentUser; RegistryKey MyWindowSettings = currentKeyUser.OpenSubKey("MyWindowSettings");
                int x = Convert.ToInt32(MyWindowSettings.GetValue("X"));
                int y = Convert.ToInt32(MyWindowSettings.GetValue("Y"));
                int width = Convert.ToInt32(MyWindowSettings.GetValue("Width")); int height = Convert.ToInt32(MyWindowSettings.GetValue("Height"));
                int r = Convert.ToInt32(MyWindowSettings.GetValue("ColorR"));
                int g = Convert.ToInt32(MyWindowSettings.GetValue("ColorG")); int b = Convert.ToInt32(MyWindowSettings.GetValue("ColorB"));
                int windowState = Convert.ToInt32(MyWindowSettings.GetValue("WindowState"));
                this.Location = new Point(x, y);
                this.Width = width; this.Height = height;
                this.BackColor = Color.FromArgb(r, g, b);
                this.WindowState = (FormWindowState)windowState;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey currentKeyUser = Registry.CurrentUser;
            RegistryKey MyWindowSettings = currentKeyUser.CreateSubKey("MyWindowSettings");
            if (this.WindowState != FormWindowState.Minimized) MyWindowSettings.SetValue("WindowState", this.WindowState, RegistryValueKind.DWord);
            if (this.WindowState == FormWindowState.Normal)
            {
                MyWindowSettings.SetValue("X", this.Location.X, RegistryValueKind.DWord);
                MyWindowSettings.SetValue("Y", this.Location.Y);
                MyWindowSettings.SetValue("Width", this.Width); MyWindowSettings.SetValue("Height", this.Height);
                MyWindowSettings.SetValue("ColorR", this.BackColor.R, RegistryValueKind.DWord);
                MyWindowSettings.SetValue("ColorG", this.BackColor.G, RegistryValueKind.DWord); 
                MyWindowSettings.SetValue("ColorB", this.BackColor.B, RegistryValueKind.DWord);
            }
            currentKeyUser.Close();
            MyWindowSettings.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = this.ForeColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK) this.BackColor = colorDialog1.Color;
        }
    }
}