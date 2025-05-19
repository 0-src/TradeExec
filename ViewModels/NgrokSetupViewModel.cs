using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TradeExec.Models;
using TradeExec.Services;

namespace TradeExec.ViewModels
{
    public class NgrokSetupViewModel : INotifyPropertyChanged
    {
        private string _ngrokUrl;
        public string NgrokUrl
        {
            get => _ngrokUrl;
            set
            {
                _ngrokUrl = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveAndContinueCommand { get; }

        public event Action OnContinueRequested;
        private readonly UserAccount _user;
        private readonly AuthService _authService;

        public NgrokSetupViewModel(UserAccount user, AuthService authService)
        {
            _user = user;
            _authService = authService;

            NgrokUrl = Properties.Settings.Default.NgrokWebhookUrl;
            SaveAndContinueCommand = new RelayCommand(SaveAndContinue);
        }


        private async void SaveAndContinue()
        {
            if (string.IsNullOrWhiteSpace(NgrokUrl))
                return;

            Properties.Settings.Default.NgrokWebhookUrl = NgrokUrl;
            Properties.Settings.Default.Save();

            await _authService.AuthNgrok(_user.Username, NgrokUrl);
            OnContinueRequested?.Invoke();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
