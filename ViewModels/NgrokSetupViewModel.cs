using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

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

        public NgrokSetupViewModel()
        {
            NgrokUrl = Properties.Settings.Default.NgrokWebhookUrl;
            SaveAndContinueCommand = new RelayCommand(SaveAndContinue);
        }

        private void SaveAndContinue()
        {
            if (string.IsNullOrWhiteSpace(NgrokUrl))
                return;

            Properties.Settings.Default.NgrokWebhookUrl = NgrokUrl;
            Properties.Settings.Default.Save();

            OnContinueRequested?.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
