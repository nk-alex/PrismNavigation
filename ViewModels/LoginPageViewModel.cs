using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PrismNavigation.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region " Navigation "
        private INavigationService _navigationService;
        #endregion

        #region " Dialog "
        IPageDialogService _dialogService;
        #endregion

        #region " Login Tap "
        private bool loginAlreadyTapped = false;
        private DelegateCommand _loginCommand;

        public DelegateCommand LoginTapCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand(ExecuteLoginCommand));

        private async void ExecuteLoginCommand()
        {
            if (loginAlreadyTapped)
            {
                return;
            }

            loginAlreadyTapped = true;

            await NavigationService.NavigateAsync("/MainPage");

            await Task.Delay(1000);
            loginAlreadyTapped = false;
        }
        #endregion

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
        }
    }
}
