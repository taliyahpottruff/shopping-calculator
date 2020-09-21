using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping_Calculator.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shopping_Calculator.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage {
        public LoginPage() {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}