using System.ComponentModel;
using Xamarin.Forms;
using Shopping_Calculator.ViewModels;

namespace Shopping_Calculator.Views {
    public partial class ItemDetailPage : ContentPage {
        public ItemDetailPage() {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}