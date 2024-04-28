using DollarSenseDB;
using DollarSenseUI.Data;
using System.Diagnostics;

namespace DollarSense.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        #region  Sprint 1 Reqs test cases
        // TODO: Rename tests with names that describe what is being tested
        // TODO: Add additional test cases using a wider variety of values
        // TODO: Add some extra tests for the currency converter and datastore
        // TODO: Clean up comments when finished
        [Test]
        public void Test_GetCostOfLiving_1Location_1Salary_Positive()
        {
            double actual = CoLCalculator.GetCostOfLiving("Georgia", 50000);
            Assert.Positive(actual);
        }
        [Test]
        public void Test_GetCostOfLiving_1Location_1Salary_NotLarge()
        {
            double actual = CoLCalculator.GetCostOfLiving("Georgia", 50000);
            Assert.LessOrEqual(actual, 100d);
        }
		[Test] // [Test] was missing
		public void Test_GetCostOfLiving_1Location_1Salary_Invalid()
		{
			double actual = CoLCalculator.GetCostOfLiving("asd", 50000);
			Assert.AreEqual(actual, -1d); // Changed to AreEqual() since Equals() cannot be used here
		}
		[Test]
        public void Test_GetCostOfLiving_1Location_2Salary_Positive()
        {
            double[] actual = CoLCalculator.GetCostOfLiving("Georgia", 50000, 40000);
            bool noNegatives = true;
            for (int i = 0; i < actual.Length; ++i)
            {
                if (actual[i] < 0d)
                {
                    noNegatives = false;
                    break;
                }
            }
            Assert.IsTrue(noNegatives);
        }
        [Test]
        public void Test_GetCostOfLiving_1Location_2Salary_NotLarge()
        {
            double[] actual = CoLCalculator.GetCostOfLiving("Georgia", 50000, 40000);
            bool noLargeVals = true;
            for (int i = 0; i < actual.Length; ++i)
            {
                if (actual[i] > 100d)
                {
                    noLargeVals = false;
                    break;
                }
            }
            Assert.IsTrue(noLargeVals);
        }
        [Test]
        public void Test_GetCostOfLiving_1Location_2Salary_Invalid()
        {
            double[] actual = CoLCalculator.GetCostOfLiving("asd", 1, 1);
            Assert.IsTrue(actual.Length == 2 && (actual[0].ToString() + actual[1].ToString() == "-1-1"));
        }
        [Test]
        public void Test_GetCostOfLiving_2Location_Positive()
        {
            double actual = CoLCalculator.GetCostOfLiving("Georgia", "New York");
            Assert.Positive(actual);
        }
        [Test]
        public void Test_GetCostOfLiving_2Location_NotLarge()
        {
            double actual = CoLCalculator.GetCostOfLiving("New York", "Georgia");
            Assert.LessOrEqual(actual, 100d);
        }
		[Test]
		public void Test_GetCostOfLiving_2Location_Invalid()
		{
			double actual = CoLCalculator.GetCostOfLiving("Georiga", "New York"); // Added a typo to Georgia
			// Assert.AreEqual(actual, -1d); // throwing warning
            Assert.That(actual, Is.EqualTo(-1d));
		}
		[Test]
        public void Test_GetCostOfLiving_2Location_1Salary_Positive()
        {
            double actual = CoLCalculator.GetCostOfLiving("Georgia", 50000, "New York");
            Assert.Positive(actual);
        }
		[Test]
		public void Test_GetCostOfLiving_2Location_1Salary_NotLarge()
		{
			double actual = CoLCalculator.GetCostOfLiving("New York", 60000, "Georgia"); // switched Georgia and New York, and also increased salary1 to 60000
			Assert.LessOrEqual(actual, 100d);
		}
		[Test]
        public void Test_GetCostOfLiving_2Location_1Salary_Invalid()
        {
            double actual = CoLCalculator.GetCostOfLiving("asd", 50, "11");
            Assert.AreEqual(actual, -1d);
        }
        [Test]
        public void Test_GetCostOfLiving_2Location_2Salary_Positive()
        {
            double[] actual = CoLCalculator.GetCostOfLiving("Georgia", 50000, "New York", 70000);
            bool noNegatives = true;
            for (int i = 0; i < actual.Length; ++i)
            {
                if (actual[i] < 0d)
                {
                    noNegatives = false;
                    break;
                }
            }
            Assert.IsTrue(noNegatives);
        }
        [Test]
        public void Test_GetCostOfLiving_2Location_2Salary_SameComparison()
        {
            double[] actual = CoLCalculator.GetCostOfLiving("Georgia", 1, "Georgia", 1);
            Assert.IsTrue(actual[1] == 1d && actual[0] == 1d);
        }
        [Test]
        public void Test_GetCostOfLiving_2Location_2Salary_NotLarge()
        {
            double[] actual = CoLCalculator.GetCostOfLiving("Georgia", 50000, "NewYork", 70000);
            bool noLargeVals = true;
            for (int i = 0; i < actual.Length; ++i)
            {
                if (actual[i] > 100d)
                {
                    noLargeVals = false;
                    break;
                }
            }
            Assert.IsTrue(noLargeVals);
        }
        [Test]
        public void Test_GetCostOfLiving_2Location_2Salary_Invalid()
        {
            double[] actual = CoLCalculator.GetCostOfLiving("asd", 50000, "New York", 70000);
            Assert.IsTrue(actual.Length == 2 && (actual[0].ToString() + actual[1].ToString() == "-1-1"));
        }
        [Test]
        public void Test9_CurrencyConversion_Positive()
        {
            double actual = CurrencyConverter.GetExchangeRate("EUR", "CNY");
            Assert.Positive(actual);
        }
        [Test]
        public void Test9_CurrencyConversion_SameComparison()
        {
            double actual = CurrencyConverter.GetExchangeRate("EUR", "EUR");
            Assert.AreEqual(actual, 1d);
        }
        [Test]
        public void Test9_CurrencyConversion_Invalid()
        {
            // TODO: (Proposed) A single currency conversion, done as a proof-of-concept. 
            double actual = CurrencyConverter.GetExchangeRate("no", "sir");
            Assert.AreEqual(actual, -1d);
        }
        #endregion
        #region UI tests
        // The UI tests have been moved to a separate BUnit suite under the DollarSenseUI.Tests project.
        /*
        [Test]
        public void Test1_SelectLocation1()
        {
            
        }
        [Test]
        public void Test2_SelectSalary1()
        {
            // TODO: Allow the user to enter a salary number. 
            Assert.Fail();
        }
        [Test]
        public void Test3_SelectLocation2()
        {
            // TODO: Allow the user to (optionally) select a second US city or state. 
            Assert.Fail();
        }
        [Test]
        public void Test4_SelectSalary2()
        {
            // TODO: Allow the user to (optionally) enter a second salary number. 
            Assert.Fail();
        }
        [Test]
        public void Test5_ClickSubmit()
        {

            Assert.Fail();
        }
        [Test]
        public void Test7_DisplaySuccess()
        {
            // TODO: (Proposed) If the user has entered two locations and no salary, calculate a percentage difference in the cost of living from location 1 to location 2. 
            Assert.Fail();
        }
        [Test]
        public void Test7_DisplayError()
        {
            // TODO: Display the first cost of living value to the user, or any errors. 
            Assert.Fail();
        }
        [Test]
        public void Test8_HideComparison()
        {
            // TODO: The comparison should be hidden if a second cost-of-living value was not calculated.
            Assert.Fail();
        }
        [Test]
        public void Test8_DisplayComparison()
        {
            // TODO: Display comparison information if a second cost-of-living value was calculated. 
            Assert.Fail();
        }
        */
        #endregion
        #region System tests
[Test]
public void Test_DBConnection()
{
    Assert.IsTrue(DataStore.CheckConnection());
}
[Test]
public void Test_ReadsCountryNames()
{
    var list = DataStore.GetCountryNames();
    Assert.IsTrue(list.Length > 0);
}
[Test]
public void Test_ReadsStateNames()
{
    var list = DataStore.GetUSStateNames();
    Assert.IsTrue(list.Length > 0);
}
[Test]
public void Test_ReadsCityNames()
{
    var list = DataStore.GetUSCityNames();
    Assert.IsTrue(list.Length > 0);
}
[Test]
public void Test_CountryNamesAreCommaSeparated()
{
    var list = DataStore.GetCountryNames();
    Assert.IsTrue(list.Split(',').Length > 1);
}
[Test]
public void Test_StateNamesAreCommaSeparated()
{
    var list = DataStore.GetUSStateNames();
    Assert.IsTrue(list.Split(',').Length > 1);
}
[Test]
public void Test_CityNamesAreCommaSeparated()
{
    var list = DataStore.GetUSCityNames();
    Assert.IsTrue(list.Split(',').Length > 1);
}
[Test]
public void Test_Reads5CountryDataValues()
{
    var data = DataStore.GetCountryData("France");
    Assert.IsTrue(data.Split(',').Length == 5);
}
[Test]
public void Test_Reads7StateDataValues()
{
    var data = DataStore.GetUSStateData("Alabama");
    Assert.IsTrue(data.Split(',').Length == 7);
}
[Test]
public void Test_Reads5CityDataValues()
{
    var data = DataStore.GetUSCityData("Milwaukee");
    Assert.IsTrue(data.Split(',').Length == 5);
}
[Test]
public void Test_5CountryDataValuesAreNumbers()
{
    const int dv = 5;
    var data = DataStore.GetCountryData("Germany");
    string[] dataArr = data.Split(',');
    bool numFlag = true;
    // data array must have this many data values
    if (dataArr.Length == dv)
    {
        for (int i = 0; i < dv; i++)
        {
            // all data values should be double numbers, otherwise it's invalid data
            if (!double.TryParse(dataArr[i], out double _))
            {
                numFlag = false;
            }
        }
    }
    else
    {
        numFlag = false;
    }
    Assert.IsTrue(numFlag);
}
[Test]
public void Test_7StateDataValuesAreNumbers()
{
    const int dv = 7;
    var data = DataStore.GetUSStateData("Colorado");
    string[] dataArr = data.Split(',');
    bool numFlag = true;
    // data array must have this many data values
    if (dataArr.Length == dv)
    {
        for (int i = 0; i < dv; i++)
        {
            // all data values should be double numbers, otherwise it's invalid data
            if (!double.TryParse(dataArr[i], out double _))
            {
                numFlag = false;
            }
        }
    }
    else
    {
        numFlag = false;
    }
    Assert.IsTrue(numFlag);
}
[Test]
public void Test_5CityDataValuesAreNumbers()
{
    const int dv = 5;
    var data = DataStore.GetUSCityData("Albequerque");
    string[] dataArr = data.Split(',');
    bool numFlag = true;
    // data array must have this many data values
    if (dataArr.Length == dv)
    {
        for (int i = 0; i < dv; i++)
        {
            // all data values should be double numbers, otherwise it's invalid data
            if (!double.TryParse(dataArr[i], out double _))
            {
                numFlag = false;
            }
        }
    }
    else
    {
        numFlag = false;
    }
    Assert.IsTrue(numFlag);
}
[Test]
public void Test_InvalidCountryDataReturnsEmpty()
{
    var data = DataStore.GetCountryData("s");
    Assert.IsTrue(data.Length == 0);
}
[Test]
public void Test_InvalidStateDataReturnsEmpty()
{
    var data = DataStore.GetUSStateData("w");
    Assert.IsTrue(data.Length == 0);
}
[Test]
public void Test_InvalidCityDataReturnsEmpty()
{
    var data = DataStore.GetUSCityData("e");
    Assert.IsTrue(data.Length == 0);
}
[Test]
public void Test_APIConnection()
{
    Assert.IsTrue(CurrencyConverter.CheckConnection());
}
        #endregion
    }
}
