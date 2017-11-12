using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Controls;
using ServiceCenter.BL.Common;
using ServiceCenter.UI.Infrastructure.Interfaces;
using ServiceCenter.UI.Infrastructure.ViewModel;

namespace ServiceCenter.UI.Shell
{
    public class LoginWindowViewModel : BaseDialogViewModel
    {
        private readonly ILoginSetCredentialsService _credentialsService;
        private readonly IWcfLoginService _wcfLoginService;

        public LoginWindowViewModel(ILoginSetCredentialsService credentialsService, IWcfLoginService wcfLoginService)
        {
            _credentialsService = credentialsService;
            _wcfLoginService = wcfLoginService;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        

        public override async void OkClick(object o)
        {
            var pas = o as PasswordBox;
            if (pas == null) throw new InvalidOperationException();
            Password = pas.Password;
            _credentialsService.SetCredentials(UserName, Password);
            try
            {
                IsBusy = true;
                var isLogged = await _wcfLoginService.IsLogged();
                if (isLogged) base.OkClick(o);
                else LoginFailed();
            }
            catch
            {
                LoginFailed();
            }
            finally
            {
                IsBusy = false;
            }
        }
        private void LoginFailed() { }
        
    }
}
