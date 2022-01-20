using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFGestorDocumentos.ViewModels.Base
{
    public class Command<T> : ICommand
    {
        public Action<T> _execute;

        public Command(Action<T> execute)
        {
            _execute = execute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true; //modificar si queremos controlar
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke((T)parameter);
        }
    }

    public class Command : ICommand
    {
        public Action _execute;

        public Command(Action execute)
        {
            _execute = execute;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true; //cambiar si no debe poder ejecutar siempre
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke();
        }
    }
}
