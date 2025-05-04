using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
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

        public ICommand ShowDashboardCommand { get; }
        public ICommand ShowAccountsCommand { get; }
        public ICommand ShowServerCommand { get; }
        public ICommand ShowSupportCommand { get; }

        public DashboardViewModel()
        {
            CurrentPage = new DashboardHomeView();

            ShowDashboardCommand = new RelayCommand(() => CurrentPage = new DashboardHomeView());
            ShowAccountsCommand = new RelayCommand(() => CurrentPage = new AccountsView());
            ShowServerCommand = new RelayCommand(() => CurrentPage = new ServerView());
            ShowSupportCommand = new RelayCommand(() => CurrentPage = new SupportView());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
