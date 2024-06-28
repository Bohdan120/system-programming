using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8._09
{
    public partial class Form1 : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_BASIC_INFORMATION
        {
            public IntPtr BaseAddress;
            public IntPtr AllocationBase;
            public uint AllocationProtect;
            public IntPtr RegionSize;
            public uint State;
            public uint Protect;
            public uint Type;
        }
        [DllImport("kernel32.dll")]
        public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

        private Process currentProcess;

        public Form1()
        {
            InitializeComponent();
            currentProcess = Process.GetCurrentProcess();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScanMemory();
        }
        private void ScanMemory()
        {
            IntPtr currentAddress = IntPtr.Zero;
            MEMORY_BASIC_INFORMATION memoryInfo;

            while (VirtualQueryEx(currentProcess.Handle, currentAddress, out memoryInfo, (uint)Marshal.SizeOf(typeof(MEMORY_BASIC_INFORMATION))) > 0)
            {
                listBox1.Items.Add($"Base Address: 0x{memoryInfo.BaseAddress.ToInt64():X16}, Region Size: {memoryInfo.RegionSize.ToInt64()} bytes");
                currentAddress = IntPtr.Add(memoryInfo.BaseAddress, (int)memoryInfo.RegionSize);

            }
        }
    }
}
