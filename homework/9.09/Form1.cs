using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9._09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Add("ProcessName", 200);
            listView1.Columns.Add("Priority", 100);
            listView1.Columns.Add("Id", 50);
            listView1.Columns.Add("Threads", 70);

          
            RefreshProcessList();
        }
        private void RefreshProcessList()
        {
            // Отримання списку всіх процесів
            Process[] processes = Process.GetProcesses();

            // Отримання списку процесів, які не відображаються в ListView
            var notDisplayedProcesses = listView1.Items.Cast<ListViewItem>()
                .Select(item => int.Parse(item.SubItems[2].Text))
                .Except(processes.Select(p => p.Id));

            // Видалення з ListView процесів, які більше не існують
            foreach (var processId in notDisplayedProcesses)
            {
                listView1.Items.RemoveAt(listView1.Items.IndexOfKey(processId.ToString()));
            }

            // Додавання до ListView нових процесів
            foreach (var process in processes)
            {
                if (listView1.Items.Find(process.Id.ToString(), false).Length == 0)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        process.ProcessName,
                        process.BasePriority.ToString(),
                        process.Id.ToString(),
                        process.Threads.Count.ToString()
                    });
                    item.Name = process.Id.ToString();
                    listView1.Items.Add(item);
                }
            }
        }  

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Отримуємо ID вибраного процесу
                string processId = listView1.SelectedItems[0].SubItems[2].Text;

                // Знаходимо процес за ID та вбиваємо його
                Process process = Process.GetProcessById(int.Parse(processId));
                process.Kill();

                // Видаляємо вибраний елемент з ListView
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Виберіть процес для завершення.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshProcessList();
        }
    }
}
