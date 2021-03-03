namespace AreYouTheOne
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
            this.AddMatchButton = new System.Windows.Forms.Button();
            this.ProbabilitiesLabel = new System.Windows.Forms.Label();
            this.QuitButton = new System.Windows.Forms.Button();
            this.AddMatchTextBox = new System.Windows.Forms.TextBox();
            this.AddPartialSolutionTextBox = new System.Windows.Forms.TextBox();
            this.AddPartialSolutionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddMatchButton
            // 
            this.AddMatchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddMatchButton.Location = new System.Drawing.Point(12, 12);
            this.AddMatchButton.Name = "AddMatchButton";
            this.AddMatchButton.Size = new System.Drawing.Size(150, 60);
            this.AddMatchButton.TabIndex = 0;
            this.AddMatchButton.Text = "Add Match";
            this.AddMatchButton.UseVisualStyleBackColor = true;
            this.AddMatchButton.Click += new System.EventHandler(this.AddMatchButton_Click);
            // 
            // ProbabilitiesLabel
            // 
            this.ProbabilitiesLabel.BackColor = System.Drawing.Color.White;
            this.ProbabilitiesLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProbabilitiesLabel.Location = new System.Drawing.Point(8, 142);
            this.ProbabilitiesLabel.Name = "ProbabilitiesLabel";
            this.ProbabilitiesLabel.Size = new System.Drawing.Size(1119, 326);
            this.ProbabilitiesLabel.TabIndex = 1;
            // 
            // QuitButton
            // 
            this.QuitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitButton.Location = new System.Drawing.Point(977, 12);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(150, 60);
            this.QuitButton.TabIndex = 2;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // AddMatchTextBox
            // 
            this.AddMatchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddMatchTextBox.Location = new System.Drawing.Point(168, 29);
            this.AddMatchTextBox.Name = "AddMatchTextBox";
            this.AddMatchTextBox.Size = new System.Drawing.Size(88, 26);
            this.AddMatchTextBox.TabIndex = 3;
            // 
            // AddPartialSolutionTextBox
            // 
            this.AddPartialSolutionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPartialSolutionTextBox.Location = new System.Drawing.Point(168, 96);
            this.AddPartialSolutionTextBox.Name = "AddPartialSolutionTextBox";
            this.AddPartialSolutionTextBox.Size = new System.Drawing.Size(175, 26);
            this.AddPartialSolutionTextBox.TabIndex = 4;
            // 
            // AddPartialSolutionButton
            // 
            this.AddPartialSolutionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPartialSolutionButton.Location = new System.Drawing.Point(12, 79);
            this.AddPartialSolutionButton.Name = "AddPartialSolutionButton";
            this.AddPartialSolutionButton.Size = new System.Drawing.Size(150, 60);
            this.AddPartialSolutionButton.TabIndex = 5;
            this.AddPartialSolutionButton.Text = "Add Sol\'n";
            this.AddPartialSolutionButton.UseVisualStyleBackColor = true;
            this.AddPartialSolutionButton.Click += new System.EventHandler(this.AddPartialSolutionButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 477);
            this.Controls.Add(this.AddPartialSolutionButton);
            this.Controls.Add(this.AddPartialSolutionTextBox);
            this.Controls.Add(this.AddMatchTextBox);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.ProbabilitiesLabel);
            this.Controls.Add(this.AddMatchButton);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddMatchButton;
        private System.Windows.Forms.Label ProbabilitiesLabel;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.TextBox AddMatchTextBox;
        private System.Windows.Forms.TextBox AddPartialSolutionTextBox;
        private System.Windows.Forms.Button AddPartialSolutionButton;
    }
}

