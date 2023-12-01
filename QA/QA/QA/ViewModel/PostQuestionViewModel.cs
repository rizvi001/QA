using System;
using Acr.UserDialogs;
using Plugin.Connectivity;
using System.Threading.Tasks;
using Xamarin.Forms;
using QA.Models;

namespace QA.ViewModel
{
	public class PostQuestionViewModel : BaseViewModel
	{
        #region Constructor
        public PostQuestionViewModel(INavigation nav)
		{
            Navigation = nav;
			PostQuestion = new Command(PostQuestionAsync);
            MoveBack = new Command(BackAsync);
        }
        #endregion

        #region Properties
        private string _Question;
        public string Question
        {
            get { return _Question; }
            set
            {
                if (_Question != value)
                {
                    _Question = value;
                    OnPropertyChanged("Question");
                }
            }
        }
        #endregion

        #region Command
        public Command PostQuestion { get; set; }
        public Command MoveBack { get; set; }

        #endregion

        #region Method
        public async void BackAsync()
        {
            await Navigation.PopModalAsync();
        }



        public async void PostQuestionAsync()
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
                            RequestPostQuestion productQuestions = new RequestPostQuestion()
                            {
                                question = Question,
                                posted_By= "68302899-e8b0-46b5-b94d-a4494174cb56",
                                posted_Date = DateTime.Now,
                                product_Id = "6b3255d6-572d-481e-be8e-f06ef7f52bac"
                            };



                            await _businessCode.PostQuestion(productQuestions,
                            async (resobj) =>
                            {
                                Device.BeginInvokeOnMainThread(async () =>
                                {
                                    var requestList = (resobj as ResponsePostQuestion);

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
                                    var errorResponse = (objj as ResponsePostQuestion);
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
                var q = Question + " ";
                Question = q;
                Question = Question.Trim();
            }
            catch (Exception ex)
            {

            }

            if(string.IsNullOrEmpty(Question))
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.AlertAsync("Please write your question.");
                return false;
            }
            return true;
            
        }

        #endregion
    }
}

