using System.Configuration;
using System.Data;
using System.Windows;
using TradeExec.Services;

namespace TradeExec
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DataStore SharedDataStore { get; private set; }
        public static WebService SharedWebService { get; private set; }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SharedDataStore = new DataStore();
            SharedWebService = new WebService(SharedDataStore);

            await OpenAsync();
        }

        async Task OpenAsync()
        {
            await SharedWebService.StartAsync();
        }
    }

}
