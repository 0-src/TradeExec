using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TradeExec.Services;

namespace TradeExec.ViewModels
{
    public class AccountViewModel : INotifyPropertyChanged
    {

        public ICommand DeleteCommand { get; }

        public string Account => Snapshot.Account;
        public string Balance => Snapshot.Balance;
        public string NetLiq => Snapshot.NetLiq;
        public string Unrealized => Snapshot.Unrealized;
        public string Realized => Snapshot.Realized;
        public string ConnectionStatus => Snapshot.ConnectionStatus;

        public AccountSnapshot Snapshot { get; private set; }

        public void UpdateSnapshot(AccountSnapshot snapshot)
        {
            Snapshot = snapshot;
            NotifyAll();
        }

        // Editable by user
        private string _strategy;
        public string Strategy
        {
            get => _strategy;
            set { _strategy = value; OnPropertyChanged(); }
        }

        private bool _isActive = true;
        public bool IsActive
        {
            get => _isActive;
            set { _isActive = value; OnPropertyChanged(); }
        }
        public Action<AccountViewModel> OnDeleteRequested { get; set; }

        public AccountViewModel(AccountSnapshot snapshot, string initialStrategy = "DEMO")
        {
            Snapshot = snapshot;
            Strategy = initialStrategy;

            DeleteCommand = new RelayCommand(() => OnDeleteRequested?.Invoke(this));
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private void NotifyAll()
        {
            OnPropertyChanged(nameof(Account));
            OnPropertyChanged(nameof(Balance));
            OnPropertyChanged(nameof(NetLiq));
            OnPropertyChanged(nameof(Unrealized));
            OnPropertyChanged(nameof(Realized));
            OnPropertyChanged(nameof(ConnectionStatus));
        }
    }
}
