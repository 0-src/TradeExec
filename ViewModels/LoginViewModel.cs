using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace TradeExec.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private bool _isLoginMode = true;

        private string _username;
        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string FormTitle => _isLoginMode ? "Login" : "Create new account.";
        public string FormSubtitle => _isLoginMode ? "START TRADING" : "START A NEW ACCOUNT";
        public string ActionButtonText => _isLoginMode ? "Login" : "Create Account";

        public ICommand SubmitCommand { get; }
        public ICommand ToggleModeCommand { get; }


        public LoginViewModel()
        {
            SubmitCommand = new RelayCommand(Submit);
            ToggleModeCommand = new RelayCommand(ToggleMode);
        }

        private void Submit()
        {
            if (_isLoginMode)
            {
                System.Diagnostics.Debug.WriteLine($"[LOGIN] {Username} / {Password}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"[CREATE] {Username} / {Password}");
            }
        }

        public Action OnModeSwitched;
        private void ToggleMode()
        {
            _isLoginMode = !_isLoginMode;
            OnPropertyChanged(nameof(FormTitle));
            OnPropertyChanged(nameof(FormSubtitle));
            OnPropertyChanged(nameof(ActionButtonText));

            OnModeSwitched?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
