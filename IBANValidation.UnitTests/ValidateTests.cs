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
            string iban = "NL93ABNA0529004100";
            bool isValid = validator.Validate(iban);
            Assert.IsTrue(isValid);
        }
    }
}
