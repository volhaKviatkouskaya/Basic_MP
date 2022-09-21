using System.Windows;
using HelloLibrary;

namespace Module_2_1_3_Net_WpfApp
{
    public partial class HelloWindow : Window
    {
        public HelloWindow(string userName)
        {
            UserGreetingVM userGreetingVm = new()
            {
                UserGreeting = StringLibrary.ConcatenateString(userName)
            };

            DataContext = userGreetingVm;
            InitializeComponent();
        }
    }
}
