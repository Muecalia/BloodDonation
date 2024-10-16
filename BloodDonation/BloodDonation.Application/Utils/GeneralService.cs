namespace BloodDonation.Application.Utils
{
    public class GeneralService
    {
        public static bool IsvalidFactorRh(string factorRh)
        {
            var tipes = new List<string> { "Positivo", "Negativo" };
            return tipes.Any(t => string.Equals(t, factorRh));
        }

        public static bool IsvalidBloodType(string bloodType)
        {
            var tipes = new List<string> { "A", "B", "AB", "O" };
            return tipes.Any(t => string.Equals(t, bloodType));
        }

        public static bool IsvalidGender(char gender)
        {
            var tipes = new List<char> { 'M', 'F' };
            return tipes.Any(t => t == gender );
        }

        public static bool IsValidDateOfBirth(string dateOfBirth)
        {
            if (DateTime.TryParse(dateOfBirth, out DateTime date))
            {
                if (date <= DateTime.Now.AddYears(-15))
                    return true;
            }
            return false;
        }

    }
}
