using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFGestorDocumentos.Services;
using WPFGestorDocumentos.ViewModel.Base;
using WPFGestorDocumentos.ViewModels.Base;

namespace WPFGestorDocumentos.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly ILoginService loginService;

        private string? _username;

        private string? _password;

        private ICommand loginCommand;

        public LoginViewModel()
        {
            loginCommand = new Command(PerformDoLoginCommand);
            loginService = CustomDependencyService.Get<LoginService>();
        }


        public string? Username
        {
            get => _username;
            set
            {
                _username = value;
                RaiseProperty();
            }
        }

        public ICommand DoLoginCommand => loginCommand;

        public string? Password
        {
            get => _password;
            set
            {
                _password = value;
                RaiseProperty();
            }
        }
        private void PerformDoLoginCommand()
        {
            loginService.DoLogin(Username, Password);
        }
    }
}
