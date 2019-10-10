using System;
using IBANValidation.Processes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IBANValidation.UnitTests
{
    [TestClass]
    public class ValidateTests
    {
        [TestMethod]
        public void ValidateIsTrue()
        {
            var validator = new ValidatieIban();
            string iban = "NL20INGB0001234567";
            bool isValid = validator.Validate(iban);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void GetCheckNumberTest()
        {
            var validator = new ValidatieIban();
            string iban = "NL20INGB0001234567";
            int checkNumber = validator.GetCheckNumber(iban);
            Assert.AreEqual(60, checkNumber);
        }
    }
}
