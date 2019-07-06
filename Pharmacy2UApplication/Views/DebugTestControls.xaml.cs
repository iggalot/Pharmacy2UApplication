
using System.Windows;
using System.Windows.Controls;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Interaction logic for DebugTestControls.xaml
    /// </summary>
    public partial class DebugTestControls : UserControl
    {
        public DebugTestControls()
        {
            InitializeComponent();
        }

        private void SwitchPageTestButton_Click(object sender, RoutedEventArgs e)
        {
            if (IoC.Get<ApplicationViewModel>().CurrentPage == ApplicationPage.Login)
                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.OrderInformationPage);
            else
                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);
        }
    }
}
