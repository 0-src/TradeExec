using System.Windows.Controls;
using TradeExec.ViewModels;

namespace TradeExec.Views
{
    public partial class NgrokSetupView : UserControl
    {
        private readonly NgrokSetupViewModel _viewModel;

        public NgrokSetupView()
        {
            InitializeComponent();

            _viewModel = new NgrokSetupViewModel();
            _viewModel.OnContinueRequested += HandleContinue;

            DataContext = _viewModel;
        }

        private void HandleContinue()
        {
            // TODO: Replace this with actual navigation logic
            System.Diagnostics.Debug.WriteLine("Ngrok URL saved. Proceeding to Dashboard...");
        }
    }
}
