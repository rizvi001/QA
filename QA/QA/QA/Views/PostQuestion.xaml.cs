using System;
using System.Collections.Generic;
using QA.ViewModel;
using Xamarin.Forms;

namespace QA.Views
{	
	public partial class PostQuestion : ContentPage
	{
		protected PostQuestionViewModel PostQuestionVM;
		public PostQuestion ()
		{
			InitializeComponent ();
			BindingContext = PostQuestionVM = new PostQuestionViewModel(this.Navigation);

        }
	}
}

