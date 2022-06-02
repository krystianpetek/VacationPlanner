using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace VacationPlannerWPFApp.Command
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public RelayCommand(Action<object> exec, Func<object, bool> canExec)
        {
            if (exec == null)
                throw new ArgumentNullException(nameof(exec));
            _execute = exec;
            _canExecute = canExec;
        }

        public bool CanExecute(object? parameter)
        {
            if (_canExecute == null) return true;

            return _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}
