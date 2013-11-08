using System.Windows.Input;
using ApplicationStatusMonitor.Infrastructure;
using System.Windows.Controls;
using ServiceMonitorModule.ViewModel;

namespace ServiceMonitorModule.View
{
    /// <summary>
    /// Interaction logic for ServiceMonitorContentView.xaml
    /// </summary>
    public partial class ServiceMonitorContentView : UserControl, IView
    {
        public ServiceMonitorContentView(IServiceMonitorContentViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get
            {
                return (IViewModel) DataContext;
            }
            set
            {
                DataContext = value;
            }
        }

    }
}
