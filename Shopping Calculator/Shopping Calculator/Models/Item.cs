using System;

namespace Shopping_Calculator.Models {
    public class Item {
        // Properties
        public string Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Amount { get; set; }
        public bool TaxExempt { get; set; }

        // Getters
        public float TaxedPrice {
            get => (float) Math.Round(Price * Amount * (TaxExempt ? 1f : 1.13f) * 100f) / 100f;
        }

        // Helpers
        public string AmountAndPrice { get => $"{Amount} @ {Price.ToString("C")}"; }
        public string TaxedPriceDisplay { get => TaxedPrice.ToString("C"); }
    }
}