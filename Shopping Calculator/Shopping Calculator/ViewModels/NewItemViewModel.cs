using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Shopping_Calculator.Models;
using Xamarin.Forms;

namespace Shopping_Calculator.ViewModels {
    public class NewItemViewModel : BaseViewModel {
        private string name;
        private float price;
        private int amount = 1;
        private bool taxExempt;

        public NewItemViewModel() {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave() {
            return !String.IsNullOrWhiteSpace(name);
        }

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

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel() {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave() {
            Item newItem = new Item() {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Price = Price,
                Amount = Amount,
                TaxExempt = TaxExempt
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
