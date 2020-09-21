using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Shopping_Calculator.Models;
using Shopping_Calculator.Views;

namespace Shopping_Calculator.ViewModels {
    public class ItemsViewModel : BaseViewModel {
        private Item _selectedItem;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public float total;

        public ItemsViewModel() {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand() {
            IsBusy = true;

            try {
                Items.Clear();
                total = 0f;
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items) {
                    Items.Add(item);
                    total += item.TaxedPrice;
                }

                Debug.WriteLine(total);
            } catch (Exception ex) {
                Debug.WriteLine(ex);
            } finally {
                IsBusy = false;
            }
        }

        public void OnAppearing() {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem {
            get => _selectedItem;
            set {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj) {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item) {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}