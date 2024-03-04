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
        // Naming convention: Test<REQID>_Desc, where:
        // REQID = number given to requirement in the plan,
        // Desc = brief description/name of test
        [Test]
        public void Test6_Submit1L1S_Positive()
        {
            double actual = CoLCalculator.GetCostOfLiving("Georgia", 50000);
            Assert.Positive(actual);
        }
        [Test]
        public void Test6_Submit1L1S_NotLarge()
        {
            double actual = CoLCalculator.GetCostOfLiving("Georgia", 50000);
            Assert.LessOrEqual(actual, 100d);
        }
        public void Test6_Submit1L1S_Invalid()
        {
            double actual = CoLCalculator.GetCostOfLiving("asd", 50000);
            Assert.Equals(actual, -1d);
        }
        [Test]
        public void Test6_Submit1L2S_Positive()
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
        public void Test6_Submit1L2S_NotLarge()
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
        public void Test6_Submit1L2S_Invalid()
        {
            double[] actual = CoLCalculator.GetCostOfLiving("asd", 1, 1);
            Assert.IsTrue(actual.Length == 2 && (actual[0].ToString() + actual[1].ToString() == "-1-1"));
        }
        [Test]
        public void Test6_Submit2L0S_Positive()
        {
            double actual = CoLCalculator.GetCostOfLiving("Georgia", "New York");
            Assert.Positive(actual);
        }
        [Test]
        public void Test6_Submit2L0S_NotLarge()
        {
            double actual = CoLCalculator.GetCostOfLiving("New York", "Georgia");
            Assert.LessOrEqual(actual, 100d);
        }
        [Test]
        public void Test6_Submit2L0S_Invalid()
        {
            double actual = CoLCalculator.GetCostOfLiving("Georgia", "New York");
            Assert.AreEqual(actual, -1d);
        }
        [Test]
        public void Test6_Submit2L1S_Positive()
        {
            double actual = CoLCalculator.GetCostOfLiving("Georgia", 50000, "New York");
            Assert.Positive(actual);
        }
        [Test]
        public void Test6_Submit2L1S_NotLarge()
        {
            double actual = CoLCalculator.GetCostOfLiving("Georgia", 50000, "New York");
            Assert.LessOrEqual(actual, 100d);
        }
        [Test]
        public void Test6_Submit2L1S_Invalid()
        {
            double actual = CoLCalculator.GetCostOfLiving("asd", 50, "11");
            Assert.AreEqual(actual, -1d);
        }
        [Test]
        public void Test6_Submit2L2S_Positive()
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
        public void Test6_Submit2L2S_SameComparison()
        {
            double[] actual = CoLCalculator.GetCostOfLiving("Georgia", 1, "Georgia", 1);
            Assert.IsTrue(actual[1] == 1d && actual[0] == 1d);
        }
        [Test]
        public void Test6_Submit2L2S_NotLarge()
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
        public void Test6_Submit2L2S_Invalid()
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
        // Naming convention: Test_Desc, where:
        // Desc = brief description/name of test

        [Test]
        public void Test_DBConnection()
        {
            Assert.IsTrue(DataStore.CheckConnection());
        }
        [Test]
        public void Test_APIConnection()
        {
            Assert.IsTrue(CurrencyConverter.CheckConnection());
        }
        #endregion
    }
}