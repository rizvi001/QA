using System;
using QA.Models;
using Xamarin.Forms;

namespace QA.ViewModel
{
	public class AllAnswerViewModel : BaseViewModel
    {
        #region Constructor
        public AllAnswerViewModel(INavigation nav)
		{
			Navigation = nav;
			AnswerCommand = new Command(AnswerAsync);

		}
        #endregion
        #region Command
        public Command AnswerCommand { get; set; }
        #endregion
        #region Properties
        private QAResponseModel _qAResponseModel;
        public QAResponseModel qAResponseModel
		{
			get { return _qAResponseModel; }
			set
			{
				if(_qAResponseModel != value)
				{
					_qAResponseModel = value;
					OnPropertyChanged("qAResponseModel");
                }
			}
		}
        #endregion
        #region Method

        public async void AnswerAsync()
		{
			await Navigation.PushModalAsync(new Views.PostAnswer(qAResponseModel));
		}
		public void RefreshPage()
		{
			
		}
        #endregion
    }
}

