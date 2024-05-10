using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeskUI.Core;
using DeskUI.Home;
using DeskUI.Logining;
using DeskUI.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace DeskUI
{
    public partial class MainWindowVM : BaseViewModel
    {
        
        [ObservableProperty]
        private Visibility secondNavLogoVisibility=Visibility.Hidden;
        [ObservableProperty]
        private Visibility loadingVisibility= Visibility.Visible;
        [ObservableProperty]
        private Visibility signInButtonVisibility = Visibility.Hidden;
        [ObservableProperty]
        private Visibility previousButtonVisibility = Visibility.Hidden;
        [ObservableProperty]
        private Visibility optionButtonVisibility = Visibility.Hidden;
        [ObservableProperty]
        private UserControl selectedPage;
        [ObservableProperty]
        private Thickness leftMarginLogo = new Thickness(20,0,10,0) ;
        [ObservableProperty]
        private Theme theme;

        public event EventHandler StartLoadingEvent;
        public event EventHandler StopLoadingEvent;
        private string themeselected = "Dark";
        public ThemeServices themeServices = new ThemeServices() ;
        public MainWindowVM(Theme theme) : base(theme)
        {
            
            SelectedPage = new WelcomePage();
            var t = new ThemeServices();
            Theme = t.GetTheme(themeselected);
            Load();
            
        }
        public void StartLoading()
        {
            StartLoadingEvent?.Invoke(this, EventArgs.Empty);
        }
        public void StopLoading()
        {
            StopLoadingEvent?.Invoke(this, EventArgs.Empty);
        }
        public void Load()
        {
            

            // Create a DispatcherTimer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(7);
            timer.Tick += (sender, e) =>
            {
                // Stop the timer
                timer.Stop();
                themeServices.GetTheme("White");
                Theme = themeServices.ActualTheme;
                StopLoading();
               
                SecondNavLogoVisibility = Visibility.Visible;
                SignInButtonVisibility = Visibility.Visible;// Navigate to the homepage
                SelectedPage = new HomePage();
                LoadingVisibility = Visibility.Hidden;
                
                
            };

            // Start the timer
            timer.Start();
        }
        [RelayCommand]
        public void SwitchToLogin()
        {

            SelectedPage = new LoginPage();
            SignInButtonVisibility = Visibility.Hidden;
            OptionButtonVisibility = Visibility.Visible;
            LeftMarginLogo = new Thickness(60, 0, 10, 0);
            PreviousButtonVisibility = Visibility.Visible;
            themeServices.GetTheme("Dark");
            Theme = themeServices.ActualTheme;
        }
        [RelayCommand]
        public void BackToHome()
        {
            SelectedPage = new HomePage();
            SignInButtonVisibility = Visibility.Visible;
            OptionButtonVisibility = Visibility.Hidden;
            LeftMarginLogo = new Thickness(20, 0, 10, 0);
            PreviousButtonVisibility = Visibility.Hidden;
            themeServices.GetTheme("White");
            Theme = themeServices.ActualTheme;
        }
    }
    public  class ThemeServices
    {
        public ThemeServices()
        {
            ActualTheme = GetTheme("Dark");
        }
        public Theme ActualTheme { get; set; } 
        public  List<Theme> Themes = new List<Theme> {
         new Theme("Black","White","White","Black","Dark") , new Theme("White","Black","Black","White", "Light") 
        };
        public Theme GetTheme(string themeName)
        {
            var theme = Themes.FirstOrDefault(b => b.ThemeName == themeName);
            ActualTheme = theme;
            return theme;
        }
        public Theme GetTheme()
        {
            return ActualTheme;
        }
    }
}
