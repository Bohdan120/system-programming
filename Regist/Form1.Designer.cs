namespace Regist
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewRegistry = new System.Windows.Forms.TreeView();
            this.listViewValues = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewRegistry
            // 
            this.treeViewRegistry.Location = new System.Drawing.Point(12, 12);
            this.treeViewRegistry.Name = "treeViewRegistry";
            this.treeViewRegistry.Size = new System.Drawing.Size(187, 156);
            this.treeViewRegistry.TabIndex = 0;
            this.treeViewRegistry.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewRegistry_AfterSelect);
            // 
            // listViewValues
            // 
            this.listViewValues.HideSelection = false;
            this.listViewValues.Location = new System.Drawing.Point(236, 12);
            this.listViewValues.Name = "listViewValues";
            this.listViewValues.Size = new System.Drawing.Size(540, 407);
            this.listViewValues.TabIndex = 1;
            this.listViewValues.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(38, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 54);
            this.button1.TabIndex = 2;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listViewValues);
            this.Controls.Add(this.treeViewRegistry);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewRegistry;
        private System.Windows.Forms.ListView listViewValues;
        private System.Windows.Forms.Button button1;
    }
}

