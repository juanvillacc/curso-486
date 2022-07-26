using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nevus.Models
{
    public class NoNumbersValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return ((string)value).All(Char.IsLetter);   
        }
    }
}
