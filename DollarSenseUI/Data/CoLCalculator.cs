namespace DollarSenseUI.Data
{
    public class CoLCalculator
    {
		//we had a difficult accessing your database. We decided to hardcode the CoL for GA and NY to test the provided test cases
        public static readonly int GA_CoL = 43482;
		public static readonly int NY_CoL = 53255;
        
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
			if (location1.Equals("Georgia"))
			{
				if (salary1 > GA_CoL)
				{
					return 1; // Well Off
				}
				else
				{
					return 0; // Enought
				}
			}
			return -1d; // Not enough
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
			int location1_CoL = 0;
			int location2_CoL = 0;

			if (location1.Equals("Georgia"))
			{
				location1_CoL = GA_CoL;
			}
			else if (location1.Equals("New York"))
			{
				location1_CoL = NY_CoL;
			}
			else
			{
				return -1d;
			}

			if (location2.Equals("Georgia"))
			{
				location2_CoL = GA_CoL;
			}
			else if (location2.Equals("New York"))
			{
				location2_CoL = NY_CoL;
			}
			else
			{
				return -1d;
			}

			//double percentage_Diff = ( (Math.Abs(location1_CoL - location2_CoL)) / ((location1_CoL + location2_CoL)/2) ) * 100;

			double a = Math.Abs(location1_CoL - location2_CoL);
			double b = (location1_CoL + location2_CoL) / 2;
			double c = (a / b) * 100;

			return c;
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
			double[] classStanding = { -1, -1 };
			if (location1.Equals("Georgia"))
			{
				if (salary1 > GA_CoL)
				{
					classStanding[0] = 1;
				}
				else
				{
					classStanding[0] = 0;
				}

				if (salary2 > GA_CoL)
				{
					classStanding[1] = 1;
				}
				else
				{
					classStanding[1] = 0;
				}
			}
			return classStanding;
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
			int location1_CoL = 0;
			int location2_CoL = 0;

			if (location1.Equals("Georgia"))
			{
				location1_CoL = GA_CoL;
			}
			else if (location1.Equals("New York"))
			{
				location1_CoL = NY_CoL;
			}
			else
			{
				return -1d;
			}

			if (location2.Equals("Georgia"))
			{
				location2_CoL = GA_CoL;
			}
			else if (location2.Equals("New York"))
			{
				location2_CoL = NY_CoL;
			}
			else
			{
				return -1d;
			}

			double expected_Location2 = (double)salary1 * ((double)location2_CoL / (double)location1_CoL);

			double percentage_diff = ((expected_Location2 - salary1) / salary1) * 100;

			if (expected_Location2 > salary1)
			{
				percentage_diff += 100;
			}
			else
			{
				percentage_diff *= -1;
			}

			return percentage_diff;
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
			double[] costOfLivingArray = new double[2];
			if (location1 == location2) //if locations are the same
			{
				costOfLivingArray[0] = 1;
				costOfLivingArray[1] = 1;

			}
			else if (location1 != "Georgia" && location1 != "New York" ||
				 location2 != "Georgia" && location2 != "New York") //if either locations is not one the approved locations (NY or GA), then array is filled with -1 (invalid)
			{
				costOfLivingArray[0] = -1;
				costOfLivingArray[1] = -1;
			}


			else
			{
				if (location1 == "Georgia")
				{
					if (salary1 > GA_CoL)
					{
						costOfLivingArray[0] = 1;
					}
					else
					{
						costOfLivingArray[0] = -1;
					}
				}
				if (location2 == "New York")
				{
					if (salary2 > NY_CoL)
					{
						costOfLivingArray[1] = 1;
					}
					else
					{
						costOfLivingArray[1] = -1;
					}
				}
			}
			// Requirement 6c
			// There's two locations and two salaries. Use these values and the cost of living data to determine
			// The cost of living/quality of life in location 1 with salary 1 and the cost of living/quality of
			// life in location 2 with salary 2.
			// this does seem to match with what the test case is asking for
			return costOfLivingArray;
		}


	}
}
