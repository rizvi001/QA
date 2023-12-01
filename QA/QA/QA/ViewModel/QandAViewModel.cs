using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Plugin.Connectivity;
using QA.Models;
using Xamarin.Forms;

namespace QA.ViewModel
{
	public class QandAViewModel : BaseViewModel
	{
        #region Constructor
        public QandAViewModel(INavigation navigation)
		{
            Navigation = navigation;
            PostQuestionCommand = new Command(GoToPostQuestion);
          
            DisplayQAAsync();
        }
        #endregion

        #region Command
        public Command PostQuestionCommand { get; set; }
       
        #endregion

        #region Properties
        private ObservableCollection<QAResponseModel> _mProductQuestionAnswer; 
        public ObservableCollection<QAResponseModel> MProductQuestionAnswer
        {
            get { return _mProductQuestionAnswer; }
            set
            {
                if(value != null)
                 _mProductQuestionAnswer = value;
                OnPropertyChanged("MProductQuestionAnswer");
            }
        }
        #endregion

        #region Method
        

        public async Task DisplayQAAsync()
        {
            try
            {
                //API call
                UserDialogs.Instance.ShowLoading("Loading...", MaskType.Clear);
                
                if (CrossConnectivity.Current.IsConnected)
                {
                    await Task.Run(async () =>
                    {
                        if (_businessCode != null)
                        {

                            string Product_Id = "6b3255d6-572d-481e-be8e-f06ef7f52bac";
                            await _businessCode.GetQA(Product_Id,
                            async (resobj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>

                                {
                                    var requestList = (resobj as List<QAResponseModel>);
                                    if (requestList != null)
                                    {
                                        try
                                        {
                                            if (requestList != null)
                                            {
                                              
                                                MProductQuestionAnswer = new ObservableCollection<QAResponseModel>(requestList);
                                                
                                                UserDialog.HideLoading();
                                            }
                                        }
                                        catch (Exception ex)
                                        { }
                                    }
                                    UserDialog.HideLoading();
                                });
                            }, (objj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var errorResponse = (objj as List<QAResponseModel>);
                                    if (errorResponse != null)
                                    {
                                        UserDialog.HideLoading();
                                        
                                    }
                                });
                            });
                        }
                    }).ConfigureAwait(false);
                }
                else
                {
                    UserDialogs.Instance.Loading().Hide();
                    await UserDialogs.Instance.AlertAsync("No Network Connection found, Please try again!", "Alert", "Okay");
                }
            }
            catch (Exception ex)
            { }
        }

        public async void GoToPostQuestion()
        {
            await Navigation.PushModalAsync(new Views.PostQuestion());

        }
        #endregion

    }
}

