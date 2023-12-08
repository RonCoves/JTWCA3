using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal class CalculatorTests
    {
        //Unit Test
        [TestMethod]
        public void CalculateSustainabilityWeighting_PetrolMode()
        {
            // Arrange
            var calculator = new Calculator.Calculator
            {
                distance = 50,
                numDays = 5,
                transportMode = TransportModes.petrol,
                milesOrKms = DistanceMeasurement.miles
            };

            // Act
            var result = calculator.sustainabilityWeighting;

            // Assert
            NUnit.Framework.Assert.AreEqual(4000, result);
        }

    }
}
