namespace Module_2_1_2_Net_WinFormsApp
{
    partial class StartForm
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
            this.Text = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Text
            // 
            this.Text.AutoSize = true;
            this.Text.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Text.Location = new System.Drawing.Point(34, 94);
            this.Text.Name = "Text";
            this.Text.Size = new System.Drawing.Size(155, 28);
            this.Text.TabIndex = 0;
            this.Text.Text = "Enter user name:";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(191, 95);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(205, 27);
            this.textBox.TabIndex = 1;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(237, 128);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(94, 29);
            this.SubmitButton.TabIndex = 2;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 245);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.Text);
            this.Name = "StartForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label Text;
        private TextBox textBox;
        private Button SubmitButton;
    }
}