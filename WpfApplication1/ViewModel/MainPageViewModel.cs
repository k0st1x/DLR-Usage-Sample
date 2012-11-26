using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApplication1.HostingContext;

namespace WpfApplication1 {
    class MainPageViewModel : INotifyPropertyChanged {
        readonly IEnumerable<IHostingContext> hostingContexts = HostingContextFactory.CreateHostingContexts();
        IHostingContext selectedLanguage;
        string code;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Code {
            get { return code; }
            set {
                code = value;
                RaisepropertyChanged();
            }
        }

        public IHostingContext SelectedLanguage {
            get { return selectedLanguage; }
            set {
                selectedLanguage = value;
                RaisepropertyChanged();
            }
        }

        public IEnumerable<IHostingContext> Languages {
            get { return hostingContexts; }
        }

        public MainPageViewModel(Canvas canvas) {
            selectedLanguage = hostingContexts.FirstOrDefault();
            PasteSampleCommand = new DelegateCommand(PasteSample);
            ExecuteCommand = new DelegateCommand(Execute);
        }

        public ICommand PasteSampleCommand { get; private set; }
        public ICommand ExecuteCommand { get; private set; }

        void PasteSample() {
            Code = selectedLanguage.SampleCode;
        }

        void Execute() {
            selectedLanguage.Execute(Code);
        }

        void RaisepropertyChanged([CallerMemberName] string propertyName = "") {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
