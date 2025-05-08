using System.Windows.Controls;
using System.Windows.Media.Animation;
using TradeExec.ViewModels;

namespace TradeExec.Views
{
    public partial class LoginView : UserControl
    {
        private LoginViewModel _vm;
        public LoginView()
        {
            InitializeComponent();
            _vm = new LoginViewModel(new Services.AuthService());
            this.DataContext = _vm;

            _vm.OnModeSwitched += AnimateFormModeSwitch;
        }
        private void AnimateFormModeSwitch()
        {
            var sb = (Storyboard)this.Resources["FadeTextStoryboard"];
            sb.Begin();
        }
    }
}
