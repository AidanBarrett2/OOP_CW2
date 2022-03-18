
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
            this.Candidate4 = new System.Windows.Forms.Button();
            this.Candidate2 = new System.Windows.Forms.Button();
            this.Candidate1 = new System.Windows.Forms.Button();
            this.Candidate3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Candidate4
            // 
            this.Candidate4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Candidate4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.Candidate4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Candidate4.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Candidate4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Candidate4.Location = new System.Drawing.Point(603, 152);
            this.Candidate4.Name = "Candidate4";
            this.Candidate4.Size = new System.Drawing.Size(132, 70);
            this.Candidate4.TabIndex = 22;
            this.Candidate4.Text = "Ernest Brown";
            this.Candidate4.UseVisualStyleBackColor = false;
            // 
            // Candidate2
            // 
            this.Candidate2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Candidate2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.Candidate2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Candidate2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Candidate2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Candidate2.Location = new System.Drawing.Point(228, 152);
            this.Candidate2.Name = "Candidate2";
            this.Candidate2.Size = new System.Drawing.Size(132, 70);
            this.Candidate2.TabIndex = 21;
            this.Candidate2.Text = "Archibald Sinclair";
            this.Candidate2.UseVisualStyleBackColor = false;
            // 
            // Candidate1
            // 
            this.Candidate1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Candidate1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.Candidate1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.Candidate1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Candidate1.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Candidate1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Candidate1.Location = new System.Drawing.Point(48, 152);
            this.Candidate1.Name = "Candidate1";
            this.Candidate1.Size = new System.Drawing.Size(132, 70);
            this.Candidate1.TabIndex = 20;
            this.Candidate1.Text = "Winston Churchill";
            this.Candidate1.UseVisualStyleBackColor = false;
            // 
            // Candidate3
            // 
            this.Candidate3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.Candidate3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.Candidate3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Candidate3.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Candidate3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Candidate3.Location = new System.Drawing.Point(417, 152);
            this.Candidate3.Name = "Candidate3";
            this.Candidate3.Size = new System.Drawing.Size(132, 70);
            this.Candidate3.TabIndex = 19;
            this.Candidate3.Text = "Clement Attlee";
            this.Candidate3.UseVisualStyleBackColor = false;
            // 
            // InPersonVote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Candidate4);
            this.Controls.Add(this.Candidate2);
            this.Controls.Add(this.Candidate1);
            this.Controls.Add(this.Candidate3);
            this.Name = "InPersonVote";
            this.Text = "InPersonVote";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Candidate4;
        private System.Windows.Forms.Button Candidate2;
        private System.Windows.Forms.Button Candidate1;
        private System.Windows.Forms.Button Candidate3;
    }
}