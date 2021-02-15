
namespace WarArt
{
    partial class MainMenuScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuScreen));
            this.buttonMonitor = new System.Windows.Forms.Button();
            this.buttonResults = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonMonitor
            // 
            this.buttonMonitor.Location = new System.Drawing.Point(12, 12);
            this.buttonMonitor.Name = "buttonMonitor";
            this.buttonMonitor.Size = new System.Drawing.Size(140, 60);
            this.buttonMonitor.TabIndex = 0;
            this.buttonMonitor.Text = "Monitor";
            this.buttonMonitor.UseVisualStyleBackColor = true;
            this.buttonMonitor.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonResults
            // 
            this.buttonResults.Location = new System.Drawing.Point(12, 89);
            this.buttonResults.Name = "buttonResults";
            this.buttonResults.Size = new System.Drawing.Size(140, 60);
            this.buttonResults.TabIndex = 1;
            this.buttonResults.Text = "Results";
            this.buttonResults.UseVisualStyleBackColor = true;
            this.buttonResults.Click += new System.EventHandler(this.buttonResults_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(179, 12);
            this.label.MaximumSize = new System.Drawing.Size(600, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(590, 78);
            this.label.TabIndex = 2;
            this.label.Text = resources.GetString("label.Text");
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(12, 378);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(140, 60);
            this.buttonReset.TabIndex = 3;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MainMenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.label);
            this.Controls.Add(this.buttonResults);
            this.Controls.Add(this.buttonMonitor);
            this.Name = "MainMenuScreen";
            this.Text = "WarArt";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMonitor;
        private System.Windows.Forms.Button buttonResults;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button buttonReset;
    }
}