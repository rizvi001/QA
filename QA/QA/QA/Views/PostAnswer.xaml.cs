using System;
using System.Collections.Generic;
using QA.Models;
using QA.ViewModel;
using Xamarin.Forms;

namespace QA.Views
{	
	public partial class PostAnswer : ContentPage
	{
		protected PostAnswerViewModel PostAnswerVM;
		public PostAnswer (QAResponseModel qAresponseModel)
		{
			InitializeComponent();
			BindingContext = PostAnswerVM = new PostAnswerViewModel(this.Navigation);
			PostAnswerVM.Questionid =qAresponseModel.questionId;
			PostAnswerVM.Productid = qAresponseModel.productId;
			
        }
	}
}

