namespace Module_2_1_2_Net_WinFormsApp
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox.Text))
            {
                HelloForm helloForm = new(textBox.Text);
                helloForm.ShowDialog();
            }
        }
    }
}