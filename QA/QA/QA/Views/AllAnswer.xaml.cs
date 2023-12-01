using QA.Models;
using QA.ViewModel;
using Xamarin.Forms;

namespace QA.Views
{	
	public partial class AllAnswer : ContentPage
	{

        protected AllAnswerViewModel AllAnswerVM;
        
        public AllAnswer(QAResponseModel qAs)
        {
            InitializeComponent();
            AllAnswerVM = new AllAnswerViewModel(Navigation);
            BindingContext = AllAnswerVM;
            AllAnswerVM.qAResponseModel = qAs;
        }

       

        async void ImageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

    }
}

