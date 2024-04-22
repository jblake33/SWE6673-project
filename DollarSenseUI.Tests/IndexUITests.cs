using AngleSharp.Dom;
using Bunit;
using DollarSenseUI.Pages;
using System.Security.Cryptography;
namespace DollarSenseUI.Tests
{
    /// <summary>
    /// These tests are written entirely in C#.
    /// Learn more at https://bunit.dev/docs/getting-started/writing-tests.html#creating-basic-tests-in-cs-files
    /// </summary>
    public class IndexUITests : BunitTestContext
    {
		// TODO: If time allows, revisit the UI test suite.
        [Test]
        public void Test1_SelectLocation1()
        {
            // Arrange
            var cut = RenderComponent<Index>();

			// Assert
			// updated to include the 4 default states options. this also help provided an exact HTML match
			cut.Find("select.l1").MarkupMatches("<select name=\"location1\" id=\"location1\" class=\"l1\">" +
                "\r\n\t\t<option value=\"1\">Georgia</option>" +
                "\r\n\t\t<option value=\"2\">Alabama</option>" +
                "\r\n\t\t<option value=\"3\">Florida</option>" +
                "\r\n\t\t<option value=\"4\">Maine</option>" +
				"\r\n\t\t</select>");
        }
        [Test]
        public void Test2_SelectSalary1()
        {
            // Arrange
            var cut = RenderComponent<Index>();
        
			// Assert
			cut.Find("input.s1").MarkupMatches("<input type=\"number\" id=\"salary1\" name=\"salary1\" class=\"s1\" />");
		}
		[Test]
        public void Test3_SelectLocation2()
        {
            // Arrange
            var cut = RenderComponent<Index>();

			// Assert
			// updated to include the 4 default states options. this also help provided an exact HTML match
			cut.Find("select.l2").MarkupMatches("<select name=\"location2\" id=\"location2\" class=\"l2\">"
			   +
				"\r\n\t\t<option value=\"1\">Georgia</option>" +
				"\r\n\t\t<option value=\"2\">Alabama</option>" +
				"\r\n\t\t<option value=\"3\">Florida</option>" +
				"\r\n\t\t<option value=\"4\">Maine</option>" +
				"\r\n\t\t</select>");
        }
        [Test]
        public void Test4_SelectSalary2()
        {
            // Arrange
            var cut = RenderComponent<Index>();
			
			// Assert
			cut.Find("input.s1").MarkupMatches("<input type=\"number\" id=\"salary1\" name=\"salary1\" class=\"s1\" />");

		}

		[Test]
		// We were unable to successfuly test this due to the .IsFocused
		// is not something that can be tested within Bunit
		// https://stackoverflow.com/questions/76911950/how-to-check-if-an-element-is-focused-using-bunit
		// This test case will remain as "failed" 
		// We created a "public void selectedClickDummy()" to stimulate the click

		public void Test5_ClickSubmit()
        {
            // Arrange
            var cut = RenderComponent<Index>();
            
            // Act
            cut.Find("button.c2a").Click();

            // Assert
            Assert.IsTrue(cut.Find("button.c2a").IsFocused);
        }
        [Test]

        //In order for us to get the remaining test cases to pass, we changed the "submit" button from a select type (previous (select.c2a) to a button (button.c2a).

        public void Test7_DisplaySuccess()
        {
            // Arrange
            var cut = RenderComponent<Index>();

			// Act
			/*        
			 *        //Previous test case code kept for reference
			 *        
			 *        cut.Find("select.l1").Click();
                       cut.Find("select.l1").Click(1, 0, 0, 0, 0, 0, 0, 3, 6);
                       cut.Find("input.s1").Click();
                       cut.Find("input.s1").Input(12345);
                       cut.Find("button.c2a").Click();*/


			// Re-simplified test. Bunit test case does not really "click" an element.
			// .Click() just calls the "onClick" event handler.
			cut.Find("select.l1").Click(1, 0, 0, 0, 0, 0, 0, 3, 6);
			cut.Find("input.s1").Change("12345"); //Instead of using .Input() -> .Change()
			cut.Find("button.c2a").Click();
			// Assert
			cut.Find("p.success").MarkupMatches("<p class=\"success\">Cost of Living:</p>");
		}
        [Test]
        public void Test7_DisplayError()
        {
            // Arrange
            var cut = RenderComponent<Index>();

            // Act
            cut.Find("button.c2a").Click();

            // Assert
			//included in the MarkUpMatch() the class=fail to provide an exact match
            cut.Find("p.fail").MarkupMatches("<p class =\"fail\">Error: Looks like you forgot something</p>");

		}
        [Test]
		public void Test8_HideComparison()
		{
			// Arrange
			var cut = RenderComponent<Index>();

			// Act
			//cut.Find("select.l1").Click();
			//cut.Find("select.l1").Click(1, 0, 0, 0, 0, 0, 0, 3, 6);
			//cut.Find("input.s1").Click();
			//cut.Find("input.s1").Input(12345);

			// Re-simplified test. Bunit test case does not really "click" an element.
			// .Click() just calls the "onClick" event handler.
			cut.Find("select.l1").Click(1, 0, 0, 0, 0, 0, 0, 3, 6);
			cut.Find("input.s1").Change(12345);
			cut.Find("button.c2a").Click();

			// Assert
			//Assert.IsFalse(cut.Find("p.compare2").IsVisible());
			// Re-worked the Assert. Were not able to find how to change the visible property
			// so we opt with checking the hidden attribute. Also, assert should check
			// if the element is hidden.
			Assert.IsTrue(cut.Find("p.compare2").HasAttribute("hidden"));
		}
		[Test]
		public void Test8_DisplayComparison()
		{
			// Arrange
			var cut = RenderComponent<Index>();

			// Act
			//cut.Find("select.l1").Click();
			cut.Find("select.l1").Click(1, 0, 0, 0, 0, 0, 0, 3, 6);
			//cut.Find("input.s1").Click();
			//cut.Find("input.s1").Input(12345);
			cut.Find("input.s1").Change(12345);
			//cut.Find("select.l2").Click();
			cut.Find("select.l2").Click(1, 0, 0, 0, 0, 0, 0, 3, 6);
			//cut.Find("input.s2").Click();
			//cut.Find("input.s2").Input(45678);
			cut.Find("input.s2").Change(45678);
			cut.Find("button.c2a").Click();

			// Assert
			//Assert.IsTrue(cut.Find("p.compare2").IsVisible());
			// Re-worked the Assert. Were not able to find how to change the visible property
			// so we opt with checking the hidden attribute. Also, assert should check
			// if the element is not hidden.
			Assert.IsFalse(cut.Find("p.compare2").HasAttribute("hidden"));
		}
	}
}
