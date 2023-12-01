using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QA.Models;

namespace QA.BusinessCode
{
    public interface IBusinessCode
    {
        Task<ResponsePostAnswer> PostAnswer(RequestPostAnswerModel request, Action<object> success, Action<object> failed);
        Task<ResponsePostQuestion> PostQuestion(RequestPostQuestion request, Action<object> success, Action<object> failed);
        Task<List<QAResponseModel>> GetQA(string Product_Id, Action<object> success, Action<object> failed);
    }
}

