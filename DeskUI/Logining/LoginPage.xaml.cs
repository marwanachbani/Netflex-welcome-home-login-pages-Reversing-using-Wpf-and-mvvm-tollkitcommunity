using DeskUI.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeskUI.Logining
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : UserControl
    {

        public static readonly DependencyProperty PasswordProperty =
    DependencyProperty.Register("Password", typeof(string), typeof(LoginPage), new PropertyMetadata(""));

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }
        public LoginPage()
        {
            var ser = new ThemeServices();
            var theme = ser.ActualTheme;
            DataContext = new LoginPageVM(theme); 
            InitializeComponent();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginPageVM viewModel)
            {
                if (sender is PasswordBox passwordBox)
                {
                    viewModel.Password = passwordBox.Password;
                    viewModel.OnPasswordChanged();
                }
            }
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataContext is LoginPageVM viewModel)
            {
                viewModel.OnTextChanged();
                
            }
        }



        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginPageVM vm)
            {
                vm.OnUserTextFocused();
                if (string.IsNullOrEmpty(vm.Password))
                {
                    vm.PasswordHolderVisibility = Visibility.Visible;
                }
                else
                {
                    vm.PasswordHolderVisibility = Visibility.Hidden;
                }
            }
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginPageVM vm)
            {
                vm.DefaultUserText();
                if (string.IsNullOrEmpty(vm.UserName))
                {
                    vm.UserHolderVisibility = Visibility.Visible;
                }
                else
                {
                    vm.UserHolderVisibility = Visibility.Hidden;
                }
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginPageVM vm)
            {
                vm.OnPasswordFocused();
                if (string.IsNullOrEmpty(vm.UserName))
                {
                    vm.UserHolderVisibility = Visibility.Visible;
                }
                else
                {
                    vm.UserHolderVisibility = Visibility.Hidden;
                }
            }
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginPageVM vm)
            {
                vm.DefaultPasswordText();
                if (string.IsNullOrEmpty(vm.Password))
                {
                    vm.PasswordHolderVisibility = Visibility.Visible;
                }
                else
                {
                    vm.PasswordHolderVisibility = Visibility.Hidden;
                }
            }
        }
        
    }
}
