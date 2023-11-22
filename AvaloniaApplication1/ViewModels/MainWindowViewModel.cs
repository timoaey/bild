using gavmeaw.ViewModels;
using gavmeaw.Views;
namespace gavmeaw.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _BildingUserControl = new ComponentsUserControl();
            _BildingUserControl.DataContext = new ComponentsUserControlViewModel();
        }

        public ComponentsUserControl _BildingUserControl { get; set; }
    }
}