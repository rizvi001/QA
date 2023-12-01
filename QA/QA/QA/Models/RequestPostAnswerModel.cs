using System;
namespace QA.Models
{
    public class RequestPostAnswerModel
    {
        public string question_Id { get; set; }
        public string replied_By { get; set; }
        public DateTime replied_Date { get; set; }
        public string answers { get; set; }
        public string product_Id { get; set; }

    }
    public class ProductAnswer
    {
        public string question_Id { get; set; }
        public string replied_By { get; set; }
        public string product_Id { get; set; }
        public DateTime replied_Date { get; set; }
        public string answers { get; set; }
        public int like { get; set; }
        public int disLike { get; set; }
        public bool is_Approved { get; set; }
        public string id { get; set; }
    }
    public class ResponsePostAnswer
    {
        public ProductAnswer product_Answer { get; set; }
        public bool isValidateSuccess { get; set; }
        public object errorMsg { get; set; }
        public string successMsg { get; set; }
    }
}

