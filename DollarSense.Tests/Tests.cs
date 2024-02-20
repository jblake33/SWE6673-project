using NUnit.Framework;

namespace Tests
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
        public void Test1_SelectLocation1()
        {
            // TODO: Allow user to select from a list of US cities and states
            Assert.Fail();
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
            // TODO: Allow the user to submit their inputs to calculate a cost-of-living value. 
            Assert.Fail();
        }
        [Test]
        public void Test6_Submit1L1S()
        {
            // TODO: If the user has entered neither a second location nor a second salary, do not calculate a second cost of living value. 
            Assert.Fail();
        }
        [Test]
        public void Test6_Submit1L2S()
        {
            // TODO: If the user has entered a second salary, but no second location, calculate a second cost of living value using the second salary and first location. 
            Assert.Fail();
        }
        [Test]
        public void Test6_Submit2L0S()
        {
            // TODO: (Proposed) If the user has entered two locations and no salary, calculate a percentage difference in the cost of living from location 1 to location 2. 
            Assert.Fail();
        }
        [Test]
        public void Test6_Submit2L1S()
        {
            // TODO: If the user has entered a second location, but no second salary, calculate a second cost of living value using the second location and first salary. 
            Assert.Fail();
        }
        [Test]
        public void Test6_Submit2L2S()
        {
            // TODO: If the user has entered a second location and second salary, calculate a second cost of living value using the second location and second salary. 
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
        [Test]
        public void Test9_CurrencyConversion()
        {
            // TODO: (Proposed) A single currency conversion, done as a proof-of-concept. 
            Assert.Fail();
        }
        #endregion
        #region System tests
        // Naming convention: Test_Desc, where:
        // Desc = brief description/name of test

        [Test]
        public void Test_DBConnection()
        {
            // TODO: Test the connection to our SQLite DB of data.
            Assert.Fail();
        }
        [Test]
        public void Test_APIConnection()
        {
            // TODO: Test the connection to the API we are using.
            Assert.Fail();
        }
        #endregion
    }
}