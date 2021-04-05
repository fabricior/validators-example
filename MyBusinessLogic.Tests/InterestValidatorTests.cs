using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyBusinessLogic.Tests
{
    [TestClass]
    public class InterestValidatorTests
    {
        [TestMethod]
        public void ValidRawArgs_Validate_ReturnsNoErrorAndValidArgs()
        {
            // Arrange
            var validator = new InterestValidator();
            var args = new InterestArgs() 
            { 
                Principal = 15m, 
                Rate = .5m ,
                PeriodInYears = 3,
            };

            // Act
            var result = validator.Validate(args);

            // Assert
            Assert.AreEqual(15m, result.ValidArgs.Principal);
            Assert.AreEqual(.5m, result.ValidArgs.Rate);
            Assert.AreEqual(3, result.ValidArgs.PeriodInYears);
            Assert.AreEqual(0, result.Errors.Count);
        }

        [TestMethod]
        public void NullValues_Validate_ReturnsError()
        {
            // Arrange
            var validator = new InterestValidator();
            var args = new InterestArgs()
            {
                Principal = null,
                Rate = null,
                PeriodInYears = null,
            };

            // Act
            var result = validator.Validate(args);

            // Assert
            Assert.IsNull(result.ValidArgs);            
            Assert.AreEqual(3, result.Errors.Count);

            var errorMsg1 = result.Errors[0].ToLower();
            Assert.IsTrue(errorMsg1.Contains("principal"));
            Assert.IsTrue(errorMsg1.Contains("null"));

            var errorMsg2 = result.Errors[1].ToLower();
            Assert.IsTrue(errorMsg2.Contains("rate"));
            Assert.IsTrue(errorMsg2.Contains("null"));

            var errorMsg3 = result.Errors[2].ToLower();
            Assert.IsTrue(errorMsg3.Contains("period"));
            Assert.IsTrue(errorMsg3.Contains("null"));
        }    

        [TestMethod]
        public void NegativeValues_Validate_ReturnsError()
        {
            // Arrange
            var validator = new InterestValidator();
            var args = new InterestArgs()
            {
                Principal = -1,
                Rate = -2,
                PeriodInYears = -3,
            };

            // Act
            var result = validator.Validate(args);

            // Assert
            Assert.IsNull(result.ValidArgs);
            Assert.AreEqual(3, result.Errors.Count);

            var errorMsg1 = result.Errors[0].ToLower();
            Assert.IsTrue(errorMsg1.Contains("principal"));
            Assert.IsTrue(errorMsg1.Contains("zero"));

            var errorMsg2 = result.Errors[1].ToLower();
            Assert.IsTrue(errorMsg2.Contains("rate"));
            Assert.IsTrue(errorMsg2.Contains("zero"));

            var errorMsg3 = result.Errors[2].ToLower();
            Assert.IsTrue(errorMsg3.Contains("period"));
            Assert.IsTrue(errorMsg3.Contains("zero"));
        }

        [TestMethod]
        public void ZeroValues_Validate_ReturnsError()
        {
            // Arrange
            var validator = new InterestValidator();
            var args = new InterestArgs()
            {
                Principal = 0,
                Rate = 0,
                PeriodInYears = 0,
            };

            // Act
            var result = validator.Validate(args);

            // Assert
            Assert.IsNull(result.ValidArgs);
            Assert.AreEqual(3, result.Errors.Count);

            var errorMsg1 = result.Errors[0].ToLower();
            Assert.IsTrue(errorMsg1.Contains("principal"));
            Assert.IsTrue(errorMsg1.Contains("zero"));

            var errorMsg2 = result.Errors[1].ToLower();
            Assert.IsTrue(errorMsg2.Contains("rate"));
            Assert.IsTrue(errorMsg2.Contains("zero"));

            var errorMsg3 = result.Errors[2].ToLower();
            Assert.IsTrue(errorMsg3.Contains("period"));
            Assert.IsTrue(errorMsg3.Contains("zero"));
        }
    }
}
