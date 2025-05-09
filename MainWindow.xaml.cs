using System.Windows;
using TradeExec.Services;
using TradeExec.ViewModels;
using TradeExec.Views;

namespace TradeExec
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AuthService _authService = new AuthService();

        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new LoginView();
        }

        public void NavigateToNgrokSetup(UserAccount user)
        {
            MainContent.Content = new NgrokSetupView
            {
                DataContext = new NgrokSetupViewModel(user, _authService)
            };
        }

        public void NavigateToDashboard()
        {
            MainContent.Content = new DashboardView();
            this.Width = 950;
            this.Height = 585;
        }
    }
}