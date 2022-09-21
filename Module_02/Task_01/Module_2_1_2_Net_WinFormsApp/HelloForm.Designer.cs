namespace Module_2_1_2_Net_WinFormsApp
{
    partial class HelloForm
    {
        private Label HelloMsg;
        public HelloForm(string userName)
        {
            InitializeComponent();
            HelloMsg.Text = $"Hello, {userName}";
        }
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
            this.HelloMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HelloMsg
            // 
            this.HelloMsg.AutoSize = true;
            this.HelloMsg.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HelloMsg.Location = new System.Drawing.Point(61, 79);
            this.HelloMsg.Name = "HelloMsg";
            this.HelloMsg.Size = new System.Drawing.Size(0, 28);
            this.HelloMsg.TabIndex = 0;
            this.HelloMsg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HelloForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 195);
            this.Controls.Add(this.HelloMsg);
            this.Name = "HelloForm";
            this.Text = "HelloForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}