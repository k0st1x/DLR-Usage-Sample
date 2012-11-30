using System;
using System.Windows.Input;

namespace WpfApplication1 {
    public class DelegateCommand : ICommand {
        readonly Action action;

        public DelegateCommand(Action action) {
            this.action = action;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter) {
            action();
        }
    }
}
