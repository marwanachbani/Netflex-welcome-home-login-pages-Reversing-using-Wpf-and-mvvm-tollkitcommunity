using DeskUI.Home;
using DeskUI.Styles;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DeskUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            var t = new ThemeServices();
            var theme = t.ActualTheme;
            DataContext = new MainWindowVM(theme);
            
            var vm = new MainWindowVM(theme);
            vm.StartLoadingEvent += Vm_StartLoadingEvent;
            vm.StopLoadingEvent += Vm_StopLoaidngEvent;
            InitializeComponent();
            StartLoading();



        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
        public void StartLoading()
        {
            Storyboard animation = (Storyboard)Resources["NetflixLoadingAnimation"];
            animation.Begin(this);
        }
        public void FinishLoading()
        {
            Storyboard animation = (Storyboard)Resources["NetflixLoadingAnimation"];
            animation.Stop(this);
        }
        private void MenuToggle_Click(object sender, RoutedEventArgs e)
        {
            if (menuToggle.IsChecked == true)
            {
                // Show your menu here
                menuToggle.ContextMenu.IsOpen = true;
            }
            else
            {
                // Hide your menu here
                menuToggle.ContextMenu.IsOpen = false;
                
            }
        }
        private void Vm_StartLoadingEvent(object sender, EventArgs e)
        {
            // Call the StartLoading method in MainWindow
            StartLoading();
        }
        private void Vm_StopLoaidngEvent(object sender, EventArgs e)
        {
            // Call the StartLoading method in MainWindow
            FinishLoading();
        }
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            // Handle the click event for the "Settings" menu item
            MessageBox.Show("Settings clicked!");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void menuToggle_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            menuToggle.IsChecked = true;
        }

        private void menuToggle_ContextMenuClosed(object sender, RoutedEventArgs e)
        {
           
        }

        private void menuToggle_ContextMenuClosed(object sender, ContextMenuEventArgs e)
        {
            menuToggle.IsChecked = false;
        }
    }
}