﻿namespace MainWindow
{
    partial class Playing
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(573, 155);
            button1.Name = "button1";
            button1.Size = new Size(95, 43);
            button1.TabIndex = 0;
            button1.Text = "Назад";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(693, 155);
            button2.Name = "button2";
            button2.Size = new Size(95, 43);
            button2.TabIndex = 1;
            button2.Text = "Вперед";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(629, 215);
            button3.Name = "button3";
            button3.Size = new Size(105, 42);
            button3.TabIndex = 2;
            button3.Text = "Закінчити (перевірити)";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Playing
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 192);
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Playing";
            Text = "This is Sudoku!";
            FormClosing += Playing_FormClosing;
            FormClosed += Playing_FormClosed;
            Load += Playing_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
    }
}