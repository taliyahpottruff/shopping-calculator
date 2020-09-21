using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Shopping_Calculator.Models;
using Shopping_Calculator.Views;
using Shopping_Calculator.ViewModels;
using Shopping_Calculator.Services;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace Shopping_Calculator.Views {
    public partial class ItemsPage : ContentPage {
        ItemsViewModel _viewModel;

        public ItemsPage() {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();

            ((ObservableCollection<Item>)ItemsListView.ItemsSource).CollectionChanged += ItemsPage_CollectionChanged;

            SetTotal(_viewModel.DataStore);
        }

        private void ItemsPage_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            SetTotal(_viewModel.DataStore);
        }

        private async void SetTotal(IDataStore<Item> dataStore) {
            float total = 0f;
            foreach (var item in await dataStore.GetItemsAsync()) {
                total += item.TaxedPrice;
            }
            TotalDisplay.Text = $"Total: {total.ToString("C")}";
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}