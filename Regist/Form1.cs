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

namespace Regist
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
  

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateTreeView();
        }
        private void PopulateTreeView()
        {
            treeViewRegistry.Nodes.Clear();

            // Add the root keys to the tree view
            TreeNode hklmNode = new TreeNode("HKEY_LOCAL_MACHINE");
            hklmNode.Tag = Registry.LocalMachine;
            treeViewRegistry.Nodes.Add(hklmNode);

            TreeNode hkcuNode = new TreeNode("HKEY_CURRENT_USER");
            hkcuNode.Tag = Registry.CurrentUser;
            treeViewRegistry.Nodes.Add(hkcuNode);

            TreeNode hkcrNode = new TreeNode("HKEY_CLASSES_ROOT");
            hkcrNode.Tag = Registry.ClassesRoot;
            treeViewRegistry.Nodes.Add(hkcrNode);

            TreeNode hkuNode = new TreeNode("HKEY_USERS");
            hkuNode.Tag = Registry.Users;
            treeViewRegistry.Nodes.Add(hkuNode);

            TreeNode hkccNode = new TreeNode("HKEY_CURRENT_CONFIG");
            hkccNode.Tag = Registry.CurrentConfig;
            treeViewRegistry.Nodes.Add(hkccNode);

            // Expand the root node
            treeViewRegistry.Nodes[0].Expand();
        }

        private void treeViewRegistry_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listViewValues.Items.Clear();

            // Get the selected registry key
            RegistryKey selectedKey = (RegistryKey)e.Node.Tag;

            // Get the subkeys
            string[] subkeys = selectedKey.GetSubKeyNames();
            foreach (string subkey in subkeys)
            {
                listViewValues.Items.Add(subkey);
            }

            // Get the values
            string[] valueNames = selectedKey.GetValueNames();
            foreach (string valueName in valueNames)
            {
                string valueData = selectedKey.GetValue(valueName).ToString();
                listViewValues.Items.Add(new ListViewItem(new string[] { valueName, valueData }));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopulateTreeView();
        }
    }
    
}
