using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyBusinessLogic.Tests
{
    [TestClass]
    public class ProcessInvoiceValidatorTests
    {
        [TestMethod]
        public void ValidRawArgs_Validate_ReturnsNoErrorAndValidArgs()
        {
            // Arrange
            var validator = new ProcessInvoiceValidator();
            var args = new ProcessInvoiceArgs() 
            { 
                Date = new DateTime(2021, 4, 30), 
                Amount = 10m 
            };

            // Act
            var result = validator.Validate(args);

            // Assert
            Assert.AreEqual(new DateTime(2021, 4, 30), result.ValidArgs.Date);
            Assert.AreEqual(10m, result.ValidArgs.Amount);
            Assert.AreEqual(0, result.Errors.Count);
        }

        [TestMethod]
        public void NullDate_Validate_ReturnsError()
        {
            // Arrange
            var validator = new ProcessInvoiceValidator();
            var args = new ProcessInvoiceArgs()
            {
                Date = null,
                Amount = 10m
            };

            // Act
            var result = validator.Validate(args);

            // Assert
            Assert.IsNull(result.ValidArgs);            
            Assert.AreEqual(1, result.Errors.Count);
            Assert.IsTrue(result.Errors[0].ToLower().Contains("date"));
        }

        [TestMethod]
        public void NullAmount_Validate_ReturnsError()
        {
            // Arrange
            var validator = new ProcessInvoiceValidator();
            var args = new ProcessInvoiceArgs()
            {
                Date = new DateTime(2021, 4, 30),
                Amount = null
            };

            // Act
            var result = validator.Validate(args);

            // Assert
            Assert.IsNull(result.ValidArgs);
            Assert.AreEqual(1, result.Errors.Count);
            Assert.IsTrue(result.Errors[0].ToLower().Contains("amount"));
            Assert.IsTrue(result.Errors[0].ToLower().Contains("null"));
        }

        [TestMethod]
        public void NegativeAmount_Validate_ReturnsError()
        {
            // Arrange
            var validator = new ProcessInvoiceValidator();
            var args = new ProcessInvoiceArgs()
            {
                Date = new DateTime(2021, 4, 30),
                Amount = -1m
            };

            // Act
            var result = validator.Validate(args);

            // Assert
            Assert.IsNull(result.ValidArgs);
            Assert.AreEqual(1, result.Errors.Count);
            Assert.IsTrue(result.Errors[0].ToLower().Contains("amount"));
            Assert.IsTrue(result.Errors[0].ToLower().Contains("negative"));
        }
    }
}
