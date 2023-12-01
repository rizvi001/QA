using System;
using System.Collections.Generic;

namespace QA.Models
{
	public class QAResponseModel
	{
            public string questionId { get; set; }
            public string question { get; set; }
            public DateTime date { get; set; }
            public bool approved { get; set; }
            public string customerId { get; set; }
            public string productId { get; set; }
            public string name { get; set; }
            public string approvedBy { get; set; }
            public List<MProductQuestionAnswer> m_ProductQuestion_Answers { get; set; }
    }
    public class MProductQuestionAnswer
    {
        public string answerId { get; set; }
        public string question_Id { get; set; }
        public string question { get; set; }
        public string replyCustomerid { get; set; }
        public DateTime replied_Date { get; set; }
        public bool is_Approved { get; set; }
        public string answers { get; set; }
        public string name { get; set; }
        public int answerLike { get; set; }
        public int disLike { get; set; }
    }
    
}

