using System;
using Acr.UserDialogs;
using Plugin.Connectivity;
using System.Threading.Tasks;
using Xamarin.Forms;
using QA.Models;
using QA.Views;

namespace QA.ViewModel
{
	public class PostAnswerViewModel : BaseViewModel
	{
        #region Constructor
        public PostAnswerViewModel(INavigation nav)
		{
            Navigation = nav;
			MoveBack = new Command(BackAsync);
            PostAnswer = new Command(PostAnswerAsync);
        }
        #endregion

        #region Command
        public Command PostAnswer { get; set; }
		public Command MoveBack { get; set; }
        #endregion

        #region Properties
        private QAResponseModel _CustomerId;
        public QAResponseModel CustomerId
        {
            get { return _CustomerId; }
            set
            {
                if (_CustomerId != value)
                {
                    _CustomerId = value;
                    OnPropertyChanged("CustomerId");

                }
            }
        }
        private QAResponseModel _qAResponseModel;
        public QAResponseModel qAResponseModel
        {
            get { return _qAResponseModel; }
            set
            {
                if (_qAResponseModel != value)
                {
                    _qAResponseModel = value;
                    OnPropertyChanged("qAResponseModel");

                }
            }
        }
        private string _Productid;
        public string Productid
        {
            get { return _Productid; }
            set
            {
                if (_Productid != value)
                {
                    _Productid = value;
                    OnPropertyChanged("Productid");
                }
            }
        }

        private string _Questionid;
        public string Questionid
        {
            get { return _Questionid; }
            set
            {
                if (_Questionid != value)
                {
                    _Questionid = value;
                    OnPropertyChanged("Questionid");
                }
            }
        }

        private string _Answer;
        public string Answer
        {
            get { return _Answer; }
            set
            {
                if (_Answer != value)
                {
                    _Answer = value;
                    OnPropertyChanged("Answer");
                }
            }
        }
        #endregion

        public async void BackAsync()
		{
			await Navigation.PopModalAsync();
		}

		public async void PostAnswerAsync()
		{
            try
            {
                if (!Validate()) return;

                UserDialogs.Instance.ShowLoading("loading", MaskType.Clear);
                if (CrossConnectivity.Current.IsConnected)
                {
                    await Task.Run(async () =>
                    {
                        if (_businessCode != null)
                        {
                            RequestPostAnswerModel productAnswer = new RequestPostAnswerModel()
                            {
                                answers = Answer,
                                replied_Date = DateTime.Now,
                                question_Id = Questionid,
                                replied_By = "68302899-e8b0-46b5-b94d-a4494174cb56",
                               product_Id = Productid
                               
                            };



                            await _businessCode.PostAnswer(productAnswer,
                            async (resobj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (resobj as ResponsePostAnswer);

                                    if (requestList != null)
                                    {
                                        try
                                        {
                                            UserDialog.Alert(requestList.successMsg);
                                            await Navigation.PopModalAsync();
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
                                    var errorResponse = (objj as ResponsePostAnswer);
                                    if (errorResponse != null)
                                    {
                                        UserDialog.HideLoading();
                                        UserDialog.Alert((string)errorResponse.errorMsg, "Alert", "Ok");
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
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool Validate()
        {
            try
            {
                var q = Answer + " ";
                Answer = q;
                Answer = Answer.Trim();
            }
            catch (Exception ex)
            {

            }
            
            if (string.IsNullOrEmpty(Answer))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Please write your answer.");
                return false;
            }
            return true;

        }





    }
}

