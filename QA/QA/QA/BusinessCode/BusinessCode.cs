using System;
using System.Collections.Generic;
using System.Net.Http;
using Acr.UserDialogs;
using Newtonsoft.Json;
using System.Threading.Tasks;
using QA.Provider;
using QA.Servicres;
using QA.Models;

namespace QA.BusinessCode
{
    public class BusinessCode : IBusinessCode
    {
        IApiProvider _apiProvider;

        #region Constructor
        public BusinessCode(IApiProvider apiProvider)
        {
            try
            {
                //To initialize service providers...
                _apiProvider = apiProvider;
                HttpClientHandler handler = new HttpClientHandler();
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region Method
        // Post Question
        public async Task<ResponsePostQuestion> PostQuestion(RequestPostQuestion request, Action<object> success, Action<object> failed)
        {
            ResponsePostQuestion resmodel = new ResponsePostQuestion();
            try
            {
                var url = string.Format("{0}Customer_Product_Question_Answer/add_customerquestion", WebServiceDetails.WebUrl);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                var result = _apiProvider.Post<ResponsePostQuestion, RequestPostQuestion>(url, request, null);
                var response = result.Result;
                ResponsePostQuestion objres = null;
                dynamic obj = "";
                ResponsePostQuestion reg = new ResponsePostQuestion();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<ResponsePostQuestion>(response.RawResult);


                    if (objres.errorMsg != "Failed")
                    {
                        success.Invoke(objres);
                    }
                    else
                        failed.Invoke(objres);

                }
                else
                {
                    UserDialogs.Instance.HideLoading();

                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }
        //Post Answer
        public async Task<ResponsePostAnswer> PostAnswer(RequestPostAnswerModel request, Action<object> success, Action<object> failed)
        {
            ResponsePostAnswer resmodel = new ResponsePostAnswer();
            try
            {
                var url = string.Format("{0}Customer_Product_Question_Answer/add_customeranswer", WebServiceDetails.WebUrl);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                var result = _apiProvider.Post<ResponsePostAnswer, RequestPostAnswerModel>(url, request, null);
                var response = result.Result;
                ResponsePostAnswer objres = null;
                dynamic obj = "";
                ResponsePostAnswer reg = new ResponsePostAnswer();
                if (response.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<ResponsePostAnswer>(response.RawResult);


                    if (objres.errorMsg != "Failed")
                    {
                        success.Invoke(objres);
                    }
                    else
                        failed.Invoke(objres);

                }
                else
                {
                    UserDialogs.Instance.HideLoading();

                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }

        // Get All QA
        public async Task<List<QAResponseModel>> GetQA(string Product_Id, Action<object> success, Action<object> failed)
        {
            List<QAResponseModel> resmodel = new List<QAResponseModel>();
            try
            {
                var url = string.Format("{0}Customer_Product_Question_Answer/getcustomerproductquestionanswer/6b3255d6-572d-481e-be8e-f06ef7f52bac", WebServiceDetails.WebUrl, Product_Id);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                var result = _apiProvider.Get<List<QAResponseModel>>(url, null);
                var response = result.Result;
                List<QAResponseModel> objres = null;
                dynamic obj = "";
                List<QAResponseModel> reg = new List<QAResponseModel>();
                if (result.IsSuccessful != false)
                {
                    objres = JsonConvert.DeserializeObject<List<QAResponseModel>>(result.RawResult);
                    success.Invoke(objres);
                }
                else
                {
                    UserDialogs.Instance.HideLoading();
                    failed.Invoke(objres);
                }
            }
            catch (Exception exception)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert("Something went wrong please try again.", "", "OK");
            }
            return resmodel;
        }

        #endregion
    }

}