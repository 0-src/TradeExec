using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using TradeExec.Services;
using TradeExec.Views.DashboardPages;

namespace TradeExec.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private UserControl _currentPage;
        public UserControl CurrentPage
        {
            get => _currentPage;
            set { _currentPage = value; OnPropertyChanged(); }
        }

        private string _activePage;
        public string ActivePage
        {
            get => _activePage;
            set
            {
                _activePage = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowDashboardCommand { get; }
        public ICommand ShowAccountsCommand { get; }
        public ICommand ShowServerCommand { get; }
        public ICommand ShowSupportCommand { get; }

        private string _usernameText;
        public string UsernameText
        {
            get => _usernameText;
            set { _usernameText = value; OnPropertyChanged(); }
        }

        public DashboardViewModel()
        {


            CurrentPage = new DashboardHomeView();
            ActivePage = "Dashboard";
            
            UsernameText = SessionManager.CurrentUser?.Username ?? "Guest";

            ShowDashboardCommand = new RelayCommand(() =>
            {
                CurrentPage = new DashboardHomeView();
                ActivePage = "Dashboard";
            });

            ShowAccountsCommand = new RelayCommand(() =>
            {
                CurrentPage = new AccountsView();
                ActivePage = "Accounts";
            });

            ShowServerCommand = new RelayCommand(() =>
            {
                CurrentPage = new ServerView();
                ActivePage = "Server";
            });

            ShowSupportCommand = new RelayCommand(() =>
            {
                CurrentPage = new SupportView();
                ActivePage = "Support";
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
