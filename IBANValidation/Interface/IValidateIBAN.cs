using System;
using System.Collections.Generic;
using System.Text;

namespace IBANValidation.Interface
{
    interface IValidateIBAN
    {
        bool Validate(string iban);
    }
}
