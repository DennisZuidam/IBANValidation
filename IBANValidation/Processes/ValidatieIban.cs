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

        public int GetCheckNumber(string iban)
        {
            //Replace Country Code and add '00'
            var ibanForCheckNo = ReplaceCountryCodeAddTwoZeros(iban);

            var allNumbers = ChangeLettersToNumbers(ibanForCheckNo);

            return CheckNumber(allNumbers);
        }

        private int CheckNumber(string allNumbers)
        {
            try
            {
                BigInteger toMod = BigInteger.Parse(allNumbers);
                var afterMod = (toMod % 97).ToString();
                return 98 - int.Parse(afterMod);
            }
            catch (Exception ex) { throw new Exception("Parsing to BigInteger failed..", ex); }

        }

        internal static string ReplaceCountryCodeAddTwoZeros(string iban)
        {
            try
            {
                if (!string.IsNullOrEmpty(iban))
                {
                    //get country code
                    var countryCode = iban?.Substring(0, iban.Length >= 4 ? 4 : iban.Length);
                    var justCountry = countryCode.Substring(0, 2);

                    //get rest of iban
                    var lengtIban = iban.Length - countryCode.Length;
                    var ibanWhitoutCountryCode = iban.Substring(4, lengtIban);

                    return ibanWhitoutCountryCode + justCountry + "00";
                }
            }
            catch
            {
                throw new Exception("IBAN is empty");
            }
            return null;
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
            catch(Exception ex) { throw new Exception("Parsing to BigInteger failed..", ex); }
        }
    }
}
