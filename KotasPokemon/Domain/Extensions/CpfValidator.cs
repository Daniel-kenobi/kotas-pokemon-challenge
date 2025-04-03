using System.Text.RegularExpressions;

namespace Domain.Extensions
{

    public static class CpfValidator
    {
        public static bool IsValid(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || !Regex.IsMatch(cpf, @"^\d{11}$"))
                return false;

            var tempCpf = cpf.Substring(0, 9);
            var digit = CalculateDigit(tempCpf);
            tempCpf += digit;
            digit = CalculateDigit(tempCpf);
            tempCpf += digit;

            return cpf.EndsWith(digit.ToString());
        }

        private static int CalculateDigit(string cpf)
        {
            int sum = 0;
            for (int i = 0; i < cpf.Length; i++)
            {
                sum += int.Parse(cpf[i].ToString()) * (cpf.Length + 1 - i);
            }

            int remainder = sum % 11;
            return remainder < 2 ? 0 : 11 - remainder;
        }
    }
}
