using System.Windows.Forms;

namespace PuzzleSolver.ui
{
    partial class Home
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
            this.openfileBtn = new System.Windows.Forms.Button();
            this.ManhattanButton = new System.Windows.Forms.RadioButton();
            this.HammingButton = new System.Windows.Forms.RadioButton();
            this.sovleBtn = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // openfileBtn
            // 
            this.openfileBtn.BackColor = System.Drawing.Color.OrangeRed;
            this.openfileBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.openfileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openfileBtn.Location = new System.Drawing.Point(178, 56);
            this.openfileBtn.Name = "openfileBtn";
            this.openfileBtn.Size = new System.Drawing.Size(102, 51);
            this.openfileBtn.TabIndex = 0;
            this.openfileBtn.Text = "Open File";
            this.openfileBtn.UseVisualStyleBackColor = false;
            this.openfileBtn.Click += new System.EventHandler(this.openfileBtn_Click);
            // 
            // ManhattanButton
            // 
            this.ManhattanButton.AutoSize = true;
            this.ManhattanButton.ForeColor = System.Drawing.Color.White;
            this.ManhattanButton.Location = new System.Drawing.Point(259, 224);
            this.ManhattanButton.Name = "ManhattanButton";
            this.ManhattanButton.Size = new System.Drawing.Size(101, 24);
            this.ManhattanButton.TabIndex = 1;
            this.ManhattanButton.TabStop = true;
            this.ManhattanButton.Text = "Manhattan";
            this.ManhattanButton.UseVisualStyleBackColor = true;
            // 
            // HammingButton
            // 
            this.HammingButton.AutoSize = true;
            this.HammingButton.ForeColor = System.Drawing.Color.White;
            this.HammingButton.Location = new System.Drawing.Point(127, 224);
            this.HammingButton.Name = "HammingButton";
            this.HammingButton.Size = new System.Drawing.Size(96, 24);
            this.HammingButton.TabIndex = 2;
            this.HammingButton.TabStop = true;
            this.HammingButton.Text = "Hamming";
            this.HammingButton.UseVisualStyleBackColor = true;
            // 
            // sovleBtn
            // 
            this.sovleBtn.BackColor = System.Drawing.Color.OrangeRed;
            this.sovleBtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.sovleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sovleBtn.Location = new System.Drawing.Point(178, 296);
            this.sovleBtn.Name = "sovleBtn";
            this.sovleBtn.Size = new System.Drawing.Size(102, 51);
            this.sovleBtn.TabIndex = 3;
            this.sovleBtn.Text = "Solve";
            this.sovleBtn.UseVisualStyleBackColor = false;
            this.sovleBtn.Click += new System.EventHandler(this.sovleBtn_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.checkBox1.Location = new System.Drawing.Point(127, 141);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(51, 24);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "A *";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox2.Location = new System.Drawing.Point(259, 141);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(55, 24);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "BFS";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(487, 411);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.sovleBtn);
            this.Controls.Add(this.HammingButton);
            this.Controls.Add(this.ManhattanButton);
            this.Controls.Add(this.openfileBtn);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button openfileBtn;
        private RadioButton ManhattanButton;
        private RadioButton HammingButton;
        private Button sovleBtn;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
    }
}