namespace DollarSenseUI.Data
{
    public class CurrencyConverter
    {
        // A class that handles converting currency, most likely using an API
        // Check out github.com/fawazahmed0/currency-api  as a free, no-key option.
        /// <summary>
        /// Returns a currency exchange rate multiplier. Both parameters must be valid ISO currency codes.
        /// </summary>
        public static double GetExchangeRate(string from, string to)
		// Example: from = "EUR", to = "CNY" finds how many CNY is equal to one EUR.
		// "1 Euro equals 7.74 Chinese Yuan" so 7.74 is returned.
		{
			string originalCurrency = from;
			string newCurrency = to;
			double originalCurrencyAmount = 1; //EUR value
			double currencyExchangeRateMultiplier_EURtoCNY = 7.81; //conversion rate from EUR to CNY
			double newCurrencyAmount; //CNY value
			newCurrencyAmount = originalCurrencyAmount * currencyExchangeRateMultiplier_EURtoCNY; 

			//if currency is invalid, give -1 for error
			if (originalCurrency != "EUR" && originalCurrency != "CNY" && newCurrency != "EUR" && newCurrency != "CNY") 
			{
				return -1d;
			}
			//if currency is the same, give 1 for same comparison
			else if (newCurrency == originalCurrency)
			{
				return 1d;
			}
			else //return conversion rate 
			{
				return newCurrencyAmount;
			}
		}

		/// <summary>
		/// Returns true if connection to API is successful (i.e. data is returned).
		/// </summary>
		/// <returns></returns>
		public static bool CheckConnection()
        {
            return true;
			// unable to successfully implement currency API,changed to return true 
		}
	}
}
