using System;
using GalaSoft.MvvmLight.Ioc;
using QA.BusinessCode;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QA.ViewModel
{
	public class BaseViewModel : BindableObject
	{
        private INavigation _Navigation;
        public bool IsInitialized { get; set; }
        protected readonly IBusinessCode _businessCode;

        #region Constructor
        public BaseViewModel(INavigation navigation = null)
        {
            try
            {
                Navigation = navigation;
                BackCommand = new Command(OnBacksAsync);
                _businessCode = SimpleIoc.Default.GetInstance<IBusinessCode>();
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region  Properties
        public INavigation Navigation
        {
            get { return _Navigation; }
            set
            {
                if (_Navigation != value)
                {
                    _Navigation = value;
                    OnPropertyChanged("Navigation");
                }
            }
        }
        #endregion

        #region Commands
        public Command BackCommand { get; set; }
        #endregion

        #region Methods

        public async void OnBacksAsync()
        {
            await Navigation.PopModalAsync();
        }
        public Acr.UserDialogs.IUserDialogs UserDialog
        {
            get
            {
                return Acr.UserDialogs.UserDialogs.Instance;
            }
        }
        public async Task PushModalAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(page);
        }

        public async Task PopModalAsync()
        {
            if (Navigation != null)
                await Navigation.PopModalAsync();
        }

        public async Task PushAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(page);
        }

        public async Task PopAsync()
        {
            if (Navigation != null)
                await Navigation.PopModalAsync();
        }
        #endregion
    }
}

