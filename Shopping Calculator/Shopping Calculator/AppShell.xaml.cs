using System;
using System.Collections.Generic;
using Shopping_Calculator.ViewModels;
using Shopping_Calculator.Views;
using Xamarin.Forms;

namespace Shopping_Calculator {
    public partial class AppShell : Xamarin.Forms.Shell {
        public AppShell() {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
