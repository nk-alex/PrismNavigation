namespace PrismNavigation.ViewModels;

public class MainPageViewModel : ViewModelBase
{
    #region " Navigation "
    private INavigationService _navigationService;
    #endregion

    #region " Dialog "
    IPageDialogService _dialogService;
    #endregion

    #region " Back Tap "
    private bool backAlreadyTapped = false;
    private DelegateCommand _backCommand;

    public DelegateCommand BackCommand =>
        _backCommand ?? (_backCommand = new DelegateCommand(ExecuteBackCommand));

    private async void ExecuteBackCommand()
    {
        if (backAlreadyTapped)
        {
            return;
        }

        backAlreadyTapped = true;

        await NavigationService.GoBackAsync();

        await Task.Delay(1000);
        backAlreadyTapped = false;
    }
    #endregion

    public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
    {
        _navigationService = navigationService;
        _dialogService = dialogService;
    }
}
