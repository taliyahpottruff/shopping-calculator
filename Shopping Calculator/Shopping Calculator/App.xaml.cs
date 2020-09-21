using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Shopping_Calculator.Services;
using Shopping_Calculator.Views;

namespace Shopping_Calculator {
    public partial class App : Application {

        public App() {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart() {
        }

        protected override void OnSleep() {
        }

        protected override void OnResume() {
        }
    }
}
