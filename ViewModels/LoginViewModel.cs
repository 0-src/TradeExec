using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TradeExec.Services;

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

        public bool UsernameHasError
        {
            get => _usernameHasError;
            set { _usernameHasError = value; OnPropertyChanged(); }
        }
        private bool _usernameHasError;

        public bool PasswordHasError
        {
            get => _passwordHasError;
            set { _passwordHasError = value; OnPropertyChanged(); }
        }
        private bool _passwordHasError;

        private readonly AuthService _authService;

        public string FormTitle => _isLoginMode ? "Login" : "Create new account.";
        public string FormSubtitle => _isLoginMode ? "START TRADING" : "START A NEW ACCOUNT";
        public string ActionButtonText => _isLoginMode ? "Login" : "Create Account";

        public ICommand SubmitCommand { get; }
        public ICommand ToggleModeCommand { get; }


        public LoginViewModel(AuthService authService)
        {
            _authService = authService;
            SubmitCommand = new RelayCommand(async () => await SubmitAsync());
            ToggleModeCommand = new RelayCommand(ToggleMode);
        }

        private async Task TriggerErrorFlags()
        {
            UsernameHasError = true;
            PasswordHasError = true;
            await Task.Delay(10);
            UsernameHasError = false;
            PasswordHasError = false;

        }

        private async Task SubmitAsync()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                UsernameHasError = string.IsNullOrWhiteSpace(Username);
                PasswordHasError = string.IsNullOrWhiteSpace(Password);
                return;
            }

            bool success;

            if (_isLoginMode)
            {
                success = _authService.Login(Username, Password);

                if (!success)
                {
                    await TriggerErrorFlags();
                }
            }
            else
            {
                success = await _authService.CreateAccountAsync(Username, Password);

                if (!success)
                {
                    await TriggerErrorFlags();
                }
            }

            if (success)
            {
                // Navigate to Dashboard
                Application.Current.Dispatcher.Invoke(() =>
                {
                    var main = (MainWindow)Application.Current.MainWindow;
                    main.NavigateToDashboard();
                });
            }
            else
            {
                Debug.WriteLine("Login or account creation failed.");
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
