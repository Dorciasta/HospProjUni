using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.ValidationAttributes
{
    /// <summary>
    /// Validates PESEL
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PeselAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => $"This is not a valid Pesel";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!IsValidPESEL(value as string))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        private bool IsValidPESEL(string pesel)
        {
            if (String.IsNullOrEmpty(pesel))
            {
                return false;
            }

            int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };

            var result = false;

            if (pesel.Length == 11)
            {
                int controlSum = CalculateControlSum(pesel, weights);
                int controlNum = controlSum % 10;
                controlNum = 10 - controlNum;

                if (controlNum == 10)
                {
                    controlNum = 0;
                }

                int lastDigit = int.Parse(pesel[^1].ToString());

                result = controlNum == lastDigit;
            }

            static int CalculateControlSum(string input, int[] weights, int offset = 0)
            {
                int controlSum = 0;

                for (int i = 0; i < input.Length - 1; i++)
                {
                    controlSum += weights[i + offset] * int.Parse(input[i].ToString());
                }

                return controlSum;
            }

            return result;
        }
    }
}
