using AngleSharp.Dom;
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
        [Test]
        public void Test1_SelectLocation1()
        {
            // Arrange
            var cut = RenderComponent<Index>();

            // Assert
            cut.Find("select.l1").MarkupMatches("<select name=\"location1\" id=\"location1\" class=\"l1\">");
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
            cut.Find("select.l2").MarkupMatches("<select name=\"location2\" id=\"location2\" class=\"l2\">");
        }
        [Test]
        public void Test4_SelectSalary2()
        {
            // Arrange
            var cut = RenderComponent<Index>();

            // Assert
            cut.Find("input.s2").MarkupMatches("<input type=\"number\" id=\"salary2\" name=\"salary2\" class=\"s2\" />");
        }

        [Test]
        public void Test5_ClickSubmit()
        {
            // Arrange
            var cut = RenderComponent<Index>();

            // Act
            cut.Find("input.c2a").Click();

            // Assert
            Assert.IsTrue(cut.Find("input.c2a").IsFocused);
        }
        [Test]
        public void Test7_DisplaySuccess()
        {
            // Arrange
            var cut = RenderComponent<Index>();

            // Act
            cut.Find("select.l1").Click();
            cut.Find("select.l1").Click(1, 0, 0, 0, 0, 0, 0, 3, 6);
            cut.Find("input.s1").Click();
            cut.Find("input.s1").Input(12345);
            cut.Find("input.c2a").Click();

            // Assert
            cut.Find("p.success").MarkupMatches("<p>Cost of Living:</p>");
        }
        [Test]
        public void Test7_DisplayError()
        {
            // Arrange
            var cut = RenderComponent<Index>();

            // Act
            cut.Find("input.c2a").Click();

            // Assert
            cut.Find("p.fail").MarkupMatches("<p>Error: Looks like you forgot something</p>");
        }
        [Test]
        public void Test8_HideComparison()
        {
            // Arrange
            var cut = RenderComponent<Index>();

            // Act
            cut.Find("select.l1").Click();
            cut.Find("select.l1").Click(1, 0, 0, 0, 0, 0, 0, 3, 6);
            cut.Find("input.s1").Click();
            cut.Find("input.s1").Input(12345);
            cut.Find("input.c2a").Click();

            // Assert
            Assert.IsFalse(cut.Find("p.compare2").IsVisible());
        }
        [Test]
        public void Test8_DisplayComparison()
        {
            // Arrange
            var cut = RenderComponent<Index>();

            // Act
            cut.Find("select.l1").Click();
            cut.Find("select.l1").Click(1, 0, 0, 0, 0, 0, 0, 3, 6);
            cut.Find("input.s1").Click();
            cut.Find("input.s1").Input(12345);
            cut.Find("select.l2").Click();
            cut.Find("select.l2").Click(1, 0, 0, 0, 0, 0, 0, 3, 6);
            cut.Find("input.s2").Click();
            cut.Find("input.s2").Input(45678);
            cut.Find("input.c2a").Click();

            // Assert
            Assert.IsTrue(cut.Find("p.compare2").IsVisible());
        }
    }
}
