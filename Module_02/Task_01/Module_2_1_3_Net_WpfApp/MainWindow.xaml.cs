using System.Windows;

namespace Module_2_1_3_Net_WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var userName = TextBox.Text;
            HelloWindow sayHelloWindow = new(userName);
            sayHelloWindow.Show();
        }
    }
}
