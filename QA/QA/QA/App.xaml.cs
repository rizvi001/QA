using System;
using GalaSoft.MvvmLight.Ioc;
using QA.BusinessCode;
using QA.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QA
{
    public partial class App : Application
    {
        private static Autofac.IContainer _container;
        protected readonly IBusinessCode _businessCode;
        public App ()
        {
            InitializeComponent();
            AppSetup appSetup = new AppSetup();
            _container = appSetup.CreateContainer();
            _businessCode = SimpleIoc.Default.GetInstance<IBusinessCode>();
            //MainPage = new Views.PostQuestion();
            MainPage = new Views.QandA();
            //MainPage = new Views.AllAnswer();
            //MainPage = new Views.PostAnswer();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

