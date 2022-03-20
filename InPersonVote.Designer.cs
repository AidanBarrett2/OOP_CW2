
namespace CW2
{
    partial class InPersonVote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InPersonVote));
            this.Candidate4 = new System.Windows.Forms.Button();
            this.Candidate2 = new System.Windows.Forms.Button();
            this.Candidate1 = new System.Windows.Forms.Button();
            this.Candidate3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Candidate4
            // 
            resources.ApplyResources(this.Candidate4, "Candidate4");
            this.Candidate4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Candidate4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.Candidate4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Candidate4.Name = "Candidate4";
            this.Candidate4.UseVisualStyleBackColor = false;
            this.Candidate4.Click += new System.EventHandler(this.Candidate4_Click);
            // 
            // Candidate2
            // 
            resources.ApplyResources(this.Candidate2, "Candidate2");
            this.Candidate2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Candidate2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.Candidate2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Candidate2.Name = "Candidate2";
            this.Candidate2.UseVisualStyleBackColor = false;
            this.Candidate2.Click += new System.EventHandler(this.Candidate2_Click);
            // 
            // Candidate1
            // 
            resources.ApplyResources(this.Candidate1, "Candidate1");
            this.Candidate1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Candidate1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.Candidate1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.Candidate1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Candidate1.Name = "Candidate1";
            this.Candidate1.UseVisualStyleBackColor = false;
            this.Candidate1.Click += new System.EventHandler(this.Candidate1_Click);
            // 
            // Candidate3
            // 
            resources.ApplyResources(this.Candidate3, "Candidate3");
            this.Candidate3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Candidate3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.Candidate3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Candidate3.Name = "Candidate3";
            this.Candidate3.UseVisualStyleBackColor = false;
            this.Candidate3.Click += new System.EventHandler(this.Candidate3_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Name = "label1";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label2.Name = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label3.Name = "label3";
            // 
            // InPersonVote
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Candidate4);
            this.Controls.Add(this.Candidate2);
            this.Controls.Add(this.Candidate1);
            this.Controls.Add(this.Candidate3);
            this.Name = "InPersonVote";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Candidate4;
        private System.Windows.Forms.Button Candidate2;
        private System.Windows.Forms.Button Candidate1;
        private System.Windows.Forms.Button Candidate3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}