using System.Windows;

namespace Module_2_1_3_Net_WpfApp
{
    public partial class HelloWindow : Window
    {
        public HelloWindow(string userName)
        {
            UserNameVM userNameVm = new()
            {
                UserName = $"Hello, {userName}"
            };

            DataContext = userNameVm;
            InitializeComponent();
        }
    }
}
