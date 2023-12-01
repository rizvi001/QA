using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using QA.Models;
using QA.ViewModel;
using Xamarin.Forms;

namespace QA.Views
{	
	public partial class QandA : ContentPage
	{
		protected QandAViewModel QandAVM;
        
        private ObservableCollection<QAsModel> users;
        public ObservableCollection<QAsModel> Users
        {
            get { return users; }
            set
            {
                if (users != value)
                {
                    users = value;
                    OnPropertyChanged();
                }
            }
        }
        public QandA ()
		{
			try
			{ 
				InitializeComponent();
				BindingContext = QandAVM = new QandAViewModel(this.Navigation);
			}
			catch (Exception ex)
			{

			}
		}
        protected override void OnAppearing()
        {
			QandAVM.DisplayQAAsync();
        }

          
        private void CustomEntry_TextChanged(Object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(e.NewTextValue))
            {
             MQuestion.ItemsSource = QandAVM.MProductQuestionAnswer;
            }
            else
            {
                MQuestion.ItemsSource = QandAVM.MProductQuestionAnswer.Where(x => x.question.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
            }
        }

        async void TapGestureRecognizer_Tapped(Object sender, EventArgs e)
        {
            QAResponseModel qAs = (sender as Label).BindingContext as QAResponseModel;
            await Navigation.PushModalAsync(new Views.AllAnswer(qAs));
        }
    }

}


