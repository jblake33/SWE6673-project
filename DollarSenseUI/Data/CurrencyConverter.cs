namespace DollarSenseUI.Data
{
    public class CurrencyConverter
    {
        // A class that handles converting currency, most likely using an API
        // Check out github.com/fawazahmed0/currency-api  as a free, no-key option.
        /// <summary>
        /// Returns a currency exchange rate multiplier. Both parameters must be valid ISO currency codes.
        /// </summary>
        internal static double GetExchangeRate(string from, string to)
        {
            // Example: from = "EUR", to = "CNY" finds how many CNY is equal to one EUR.
            // "1 Euro equals 7.74 Chinese Yuan" so 7.74 is returned.
            return 0;
        }
    }
}
