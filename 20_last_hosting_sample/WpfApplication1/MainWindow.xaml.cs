using System.Windows;
using WpfApplication1.HostingContext;

namespace WpfApplication1 {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            var configurer = new HostingContextConfigurer(canvas);
            var hostingContexts = HostingContextFactory.CreateHostingContexts(configurer);
            DataContext = new MainPageViewModel(hostingContexts);
        }
    }
}
