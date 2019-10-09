using System;
using System.Collections.Generic;
using System.Text;

namespace IBANValidation.Helpers
{
    public class Converter
    {
        public static int ConvertLetterToNumber(char c)
        {
            string letter = c.ToString().ToUpper();
            try
            {
                switch (letter)
                {
                    case "A":
                        return 10;
                    case "B":
                        return 11;
                    case "C":
                        return 12;
                    case "D":
                        return 13;
                    case "E":
                        return 14;
                    case "F":
                        return 15;
                    case "G":
                        return 16;
                    case "H":
                        return 17;
                    case "I":
                        return 18;
                    case "J":
                        return 19;
                    case "K":
                        return 20;
                    case "L":
                        return 21;
                    case "M":
                        return 22;
                    case "N":
                        return 23;
                    case "O":
                        return 24;
                    case "P":
                        return 25;
                    case "Q":
                        return 26;
                    case "R":
                        return 27;
                    case "S":
                        return 28;
                    case "T":
                        return 29;
                    case "U":
                        return 30;
                    case "V":
                        return 31;
                    case "W":
                        return 32;
                    case "X":
                        return 33;
                    case "Y":
                        return 34;
                    case "Z":
                        return 35;
                    default:
                        return 0;
                }
            }
            catch
            {
                throw new Exception("Convert Letter to number failed");
            }
        }
    }
}
