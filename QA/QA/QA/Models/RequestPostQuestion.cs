using System;
namespace QA.Models
{
	public class RequestPostQuestion
	{
        public string question { get; set; }
        public string posted_By { get; set; }
        public DateTime posted_Date { get; set; }
        public string product_Id { get; set; }
    }

    public class ResponsePostQuestion
    {
        public ProductQuestions product_Questions { get; set; }
        public bool isValidateSuccess { get; set; }
        public object errorMsg { get; set; }
        public string successMsg { get; set; }
    }

    public class ProductQuestions
    {
        public string question { get; set; }
        public string posted_By { get; set; }
        public DateTime posted_Date { get; set; }
        public bool is_Approved { get; set; }
        public string product_Id { get; set; }
        public string id { get; set; }
    }
}

