using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeskUI.Core;
using DeskUI.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DeskUI.Logining
{
    public partial class LoginPageVM : BaseViewModel
    {
        [ObservableProperty]
        private Visibility userHolderVisibility;
        [ObservableProperty]
        private Visibility passwordHolderVisibility;
        [ObservableProperty]
        private bool loginButtonEnability = false;
        [ObservableProperty]
        private string focusedUserTextBorder;
        [ObservableProperty]
        private string focusedPasswordTextBorder;
        [ObservableProperty]
        private string focusedUserTextBackground;
        [ObservableProperty]
        private string focusedPasswordTextBackgorund;
        [ObservableProperty]
        private string focusedUserTextForeground;
        [ObservableProperty]
        private string focusedPasswordTextForeground;
        [ObservableProperty]
        private string userName;
        [ObservableProperty]
        private string password;
        public LoginPageVM(Theme theme) : base(theme)
        {
            DefaultPasswordText();
            DefaultUserText();
        }
        public void OnUserTextFocused()
        {
            FocusedUserTextBackground = "White";
            
            FocusedUserTextForeground = "Black";
            UserHolderVisibility = Visibility.Hidden;
            

        }
        public void DefaultUserText()
        {
            FocusedUserTextBackground = "Black";
            
            FocusedUserTextForeground = "White";
            if (string.IsNullOrEmpty(UserName))
            {
                UserHolderVisibility = Visibility.Visible;
            }
            if (string.IsNullOrEmpty(Password))
            {
                PasswordHolderVisibility = Visibility.Visible;
            }

        }
        public void OnPasswordFocused()
        {
            FocusedPasswordTextBackgorund = "White";
            FocusedPasswordTextForeground = "Black";
            PasswordHolderVisibility = Visibility.Hidden;

            // Hide the username placeholder when focusing on the password box
            UserHolderVisibility = Visibility.Hidden;
        }
        public void DefaultPasswordText()
        {
            FocusedPasswordTextBackgorund = "Black";
            
            FocusedPasswordTextForeground = "White";
            if(string.IsNullOrEmpty(Password))
            {
                PasswordHolderVisibility = Visibility.Visible;
            }
            if (string.IsNullOrEmpty(UserName))
            {
                UserHolderVisibility = Visibility.Visible;
            }
            else
            {
                PasswordHolderVisibility = Visibility.Hidden;
            }

        }
        public void OnTextChanged()
        {
            UserName = UserName?.Trim();  // Trim the input to remove leading and trailing spaces

            if (string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(UserName))
            {
                PasswordHolderVisibility = Visibility.Visible;
                UserHolderVisibility = Visibility.Visible;
                LoginButtonEnability = false;
            }
            if (string.IsNullOrEmpty(UserName))
            {
                OnUserTextFocused();
            }
            if (string.IsNullOrEmpty(Password))
            {
                PasswordHolderVisibility = Visibility.Visible;
            }
            
            else
            {
                PasswordHolderVisibility = Visibility.Hidden;
                UserHolderVisibility = Visibility.Hidden;
                if (Password.Length >= 4 && UserName.Length >= 4)
                {
                    LoginButtonEnability = true;
                   
                }
                if (Password.Length >= 4 || UserName.Length >= 4)
                {
                    LoginButtonEnability = false;
                 
                }
                else
                {
                    LoginButtonEnability = false;
                }
            }
        }
        public void OnPasswordChanged()
        {
            if (string.IsNullOrEmpty(Password))
            {
                PasswordHolderVisibility = Visibility.Visible;
            }
            else
            {
                OnPasswordFocused();
            }

            if (string.IsNullOrEmpty(UserName))
            {
                UserHolderVisibility = Visibility.Visible;
            }
            else
            {
                UserHolderVisibility = Visibility.Hidden;
            }

            if (Password.Length >= 4 && UserName.Length >= 4)
            {
                LoginButtonEnability = true;
                PasswordHolderVisibility = Visibility.Hidden;
                UserHolderVisibility = Visibility.Hidden;
            }
            else
            {
                LoginButtonEnability = false;
            }
        }
        [RelayCommand]
        public void CreateAccount()
        {

        }
        [RelayCommand]
        public void ForgotPassword()
        {

        }
        [RelayCommand]
        public void AccessToDatabase()
        {

        }
    }
}
