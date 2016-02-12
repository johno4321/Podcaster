namespace Podcaster
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
            this.SubscriptionsTreeView = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SubscriptionsTreeView
            // 
            this.SubscriptionsTreeView.Location = new System.Drawing.Point(12, 12);
            this.SubscriptionsTreeView.Name = "SubscriptionsTreeView";
            this.SubscriptionsTreeView.Size = new System.Drawing.Size(340, 349);
            this.SubscriptionsTreeView.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(478, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 373);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SubscriptionsTreeView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView SubscriptionsTreeView;
        private System.Windows.Forms.Button button1;

    }
}

