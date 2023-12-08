using Calculator;
using MyJourneyToWork;
using System;
using TechTalk.SpecFlow;

namespace TestProject1
{
    [Binding]
    public class DistanceMeasurementStepDefinitions
    {
        private Calculator.Calculator calculator;

        [Given(@"the user selects miles")]
        public void GivenTheUserSelectsMiles()
        {
            calculator = new Calculator.Calculator();
            calculator.milesOrKms = DistanceMeasurement.miles;
        }

        [When(@"the user enters a distance")]
        public void WhenTheUserEntersADistance()
        {
            // Implement as needed (e.g., set a test distance)
            // For example, you might want to set a test distance like this:
            calculator.distance = 10; // Set a sample distance for testing
        }

        [Then(@"the distance should be in miles")]
        public void ThenTheDistanceShouldBeInMiles()
        {
            // Implement assertion based on your specific test scenario
            Assert.AreEqual(DistanceMeasurement.miles, calculator.milesOrKms);
            // Add more assertions as needed for your specific scenario
            Assert.AreEqual(10, calculator.distance); // Adjust based on the expected distance
        }
    }
}
