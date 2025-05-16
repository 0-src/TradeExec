using System.Windows;
using TradeExec.Services;
using TradeExec.ViewModels;
using TradeExec.Views;
using TradeExec.Models;
using System.Diagnostics;


namespace TradeExec
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AuthService _authService = new AuthService();
        private WebService _webService;
        private DataStore _dataStore;

        public MainWindow()
        {
            InitializeComponent();

            MainContent.Content = new LoginView();

            DebugCommands();
        }

        public void NavigateToNgrokSetup(UserAccount user)
        {
            MainContent.Content = new NgrokSetupView
            {
                DataContext = new NgrokSetupViewModel(user, _authService)
            };
        }

        public async void DebugCommands()
        {
            _dataStore = new DataStore();
            _webService = new WebService(_dataStore);

            var cmd1 = CommandModel.CreateQueryAcct("Sim101");
            var cmd2 = CommandModel.CreateQueryAcct("*");

            await _webService.StartAsync();
            Debug.WriteLine("RAN?!");

            await _webService.SendCommandAsync(cmd1);
        }

        public void NavigateToDashboard()
        {
            MainContent.Content = new DashboardView();
            this.Width = 950;
            this.Height = 585;
        }

        protected override void OnClosed(EventArgs e)
        {
            _webService?.Dispose();
            base.OnClosed(e);
        }
    }
}