using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TradeExec.Models;
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

        public ObservableCollection<AccountViewModel> Accounts { get; } = new();
        private Dictionary<string, string> _strategies = StrategyStore.LoadStrategies();

        private string _usernameText;
        public string UsernameText
        {
            get => _usernameText;
            set { _usernameText = value; OnPropertyChanged(); }
        }

        static async Task RequestAllAccountsAsync()
        {
            var cmd = CommandModel.CreateQueryAcct("*");
            await App.SharedWebService.SendCommandAsync(cmd);
        }

        public DashboardViewModel()
        {
            App.SharedDataStore.SnapshotUpdated += OnSnapshotUpdated;
            _ = RequestAllAccountsAsync();


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
        private void OnSnapshotUpdated(string account, AccountSnapshot snapshot)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var existing = Accounts.FirstOrDefault(a => a.Account == account);
                if (existing != null)
                {
                    existing.UpdateSnapshot(snapshot);
                }
                else
                {
                    var strategy = _strategies.TryGetValue(account, out var s) ? s : "";

                    var vm = new AccountViewModel(snapshot, strategy);

                    vm.PropertyChanged += (_, e) =>
                    {
                        if (e.PropertyName == nameof(AccountViewModel.Strategy))
                        {
                            _strategies[account] = vm.Strategy;
                            StrategyStore.SaveStrategies(_strategies);
                        }
                    };

                    Accounts.Add(vm);
                }
            });
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
