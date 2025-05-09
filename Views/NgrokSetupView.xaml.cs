using System.Windows;
using System.Windows.Controls;
using TradeExec.ViewModels;

namespace TradeExec.Views
{
    public partial class NgrokSetupView : UserControl
    {
        public NgrokSetupView()
        {
            InitializeComponent();

            Loaded += (_, __) =>
            {
                if (DataContext is NgrokSetupViewModel vm)
                {
                    vm.OnContinueRequested += () =>
                    {
                        var main = (MainWindow)Application.Current.MainWindow;
                        main.NavigateToDashboard();
                    };
                }
            };
        }
    }

}
