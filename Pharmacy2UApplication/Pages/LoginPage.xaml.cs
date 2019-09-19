using Pharm2UAnimations;
using Pharmacy2UApplication.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Pharmacy2UApplication
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePageAnimation
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.AnimateOutAsync();

            Console.WriteLine(TreeHelperExtensions.WriteLogicalTree(this));
            Console.WriteLine(TreeHelperExtensions.WriteVisualTree(this));
        }
    }
}
