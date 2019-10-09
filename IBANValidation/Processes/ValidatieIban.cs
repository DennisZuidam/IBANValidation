using IBANValidation.Interface;
using IBANValidation.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace IBANValidation.Processes
{
    public class ValidatieIban : IValidateIBAN
    {
        public bool Validate(string iban)
        {
            //place country and control number ad the end
            var countryCode = AdjustCountryCode(iban);

            //convert all letters to numbers
            var allNumbers = ChangeLettersToNumbers(countryCode);

            //check if valid IBAN
            return Mod97(allNumbers);
        }

        internal static string AdjustCountryCode(string iban)
        {
            try
            {
                if (!string.IsNullOrEmpty(iban))
                {
                    //get country code
                    var countryCode = iban?.Substring(0, iban.Length >= 4 ? 4 : iban.Length);

                    //get rest of iban
                    var lengtIban = iban.Length - countryCode.Length;
                    var ibanWhitoutCountryCode = iban.Substring(4, lengtIban);

                    return ibanWhitoutCountryCode + countryCode;
                }
            }
            catch
            {
                throw new Exception("IBAN is empty");
            }
            return null;
        }

        internal string ChangeLettersToNumbers(string countryCode)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var c in countryCode)
            {
                if (int.TryParse(c.ToString(), out int no))
                    sb.Append(no.ToString());
                else
                {
                    string numberFromChar = Converter.ConvertLetterToNumber(c).ToString();
                    sb.Append(numberFromChar);
                }
            }
            return sb.ToString();
        }

        internal string ControllNumber(string iban)
        {
            var controlNo = iban?.Substring(2, iban.Length >= 2 ? 2 : iban.Length);
            return controlNo;
        }

        internal bool Mod97(string allNumbersIban)
        {
            try
            {
                BigInteger toMod = BigInteger.Parse(allNumbersIban);
                if (toMod % 97 == 1)
                    return true;
                else
                    return false;
            }
            catch(Exception ex) { throw new Exception("Parsing to Int32 failed..", ex); }
        }
    }
}
