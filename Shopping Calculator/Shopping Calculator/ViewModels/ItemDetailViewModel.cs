using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Shopping_Calculator.Models;
using Xamarin.Forms;

namespace Shopping_Calculator.ViewModels {
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel {
        private string itemId;
        private string name;
        private float price;
        private int amount;
        private bool taxExempt;
        public string Id { get; set; }

        public string Name {
            get => name;
            set => SetProperty(ref name, value);
        }

        public float Price {
            get => price;
            set => SetProperty(ref price, value);
        }

        public int Amount {
            get => amount;
            set => SetProperty(ref amount, value);
        }

        public bool TaxExempt {
            get => taxExempt;
            set => SetProperty(ref taxExempt, value);
        }

        public string ItemId {
            get {
                return itemId;
            }
            set {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId) {
            try {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Name = item.Name;
                Price = item.Price;
                Amount = item.Amount;
                TaxExempt = item.TaxExempt;
            } catch (Exception) {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
