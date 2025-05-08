using System.Windows;
using TradeExec.Views;

namespace TradeExec
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new LoginView();
        }

        public void NavigateToDashboard()
        {
            MainContent.Content = new DashboardView();
            this.Width = 950;
            this.Height = 585;
        }
    }
}