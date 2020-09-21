using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Shopping_Calculator.Models;
using Shopping_Calculator.ViewModels;

namespace Shopping_Calculator.Views {
    public partial class NewItemPage : ContentPage {
        public Item Item { get; set; }

        public NewItemPage() {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }

        private void PriceField_TextChanged(object sender, TextChangedEventArgs e) {
            char[] chars = e.NewTextValue.ToCharArray();
            int decimalIndex = -1;
            for (int i = 0; i < chars.Length; i++) {
                if (decimalIndex < 0) {
                    if (chars[i].Equals('.')) {
                        decimalIndex = i;
                    }
                } else {
                    if ((i - decimalIndex) > 2) {
                        ((Entry)sender).Text = e.OldTextValue;
                    }
                }
            }
        }
    }
}