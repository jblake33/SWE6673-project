namespace DollarSenseUI.Data
{
    public class CoLCalculator
    {
        /// <summary>
        /// Accepts one location and annual salary value and returns a "cost of living" score.
        /// </summary>
        /// <param name="location1"></param>
        /// <param name="salary1"></param>
        /// <returns></returns>
        public static double GetCostOfLiving(string location1, int salary1)
        {
            // Requirement 6d
            // There's just one location and salary. Use these values and the cost of living data to determine
            // a "class standing" (e.g. Is $50000/yr in this city not enough / enough / well off? )
            return 0;
        }
        /// <summary>
        /// Accepts two locations and returns a percentage difference in cost of living from location 1 to location 2.
        /// </summary>
        /// <param name="location1"></param>
        /// <param name="location2"></param>
        /// <returns></returns>
        public static double GetCostOfLiving(string location1, string location2)
        {
            // (Proposed) Requirement 6e
            // There's two locations and no salary. Use these values and the cost of living data to determine
            // a percentage difference in cost of living from location1 to location2.
            return 0;
        }
        /// <summary>
        /// Accepts one location and two annual salary values and returns two "cost of living" scores.
        /// </summary>
        /// <param name="location1"></param>
        /// <param name="salary1"></param>
        /// <param name="salary2"></param>
        /// <returns></returns>
        public static double[] GetCostOfLiving(string location1, int salary1, int salary2)
        {
            // Requirement 6b
            // There's one location and two salaries. Use these values and the cost of living data to determine
            // A "class standing" for each salary in location 1.
            return new double[0];
        }
        /// <summary>
        /// Accepts two locations and one annual salary value and returns the expected salary to maintain the same
        /// cost of living in location 2.
        /// </summary>
        /// <param name="location1"></param>
        /// <param name="salary1"></param>
        /// <param name="location2"></param>
        /// <returns></returns>
        public static double GetCostOfLiving(string location1, int salary1, string location2)
        {
            // Requirement 6a
            // There's two locations and one salary. Use these values and the cost of living data to determine
            // The salary expected to be made in location 2 to maintain the cost of living in location 1.
            return 0;
        }
        /// <summary>
        /// Accepts two locations and two annual salary values and returns two "cost of living" scores.
        /// </summary>
        /// <param name="location1"></param>
        /// <param name="salary1"></param>
        /// <param name="location2"></param>
        /// <param name="salary2"></param>
        /// <returns></returns>
        public static double[] GetCostOfLiving(string location1, int salary1, string location2, int salary2)
        {
            // Requirement 6c
            // There's two locations and two salaries. Use these values and the cost of living data to determine
            // The cost of living/quality of life in location 1 with salary 1 and the cost of living/quality of
            // life in location 2 with salary 2.
            return new double[0];
        }

        /// <summary>
        /// Accepts a location and returns a char for which type of location it is. 'I' = international, 'C' = US City, 'S' = US state
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static char ClassifyLocation(string location)
        {
            return 'c';
        }
    }
}
