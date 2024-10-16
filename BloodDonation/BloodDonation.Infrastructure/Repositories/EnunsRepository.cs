using BloodDonation.Core.Enuns;

namespace BloodDonation.Infrastructure.Repositories
{
    public class EnunsRepository
    {
        public static BloodType GetBloodType(int CodigoBloodType)
        {
            return Enum.GetValues(typeof(BloodType)).Cast<BloodType>().FirstOrDefault(x => (int)x == CodigoBloodType);
        }

        public static Gender GetGender(char CodigoGender) => Enum.GetValues(typeof(Gender)).Cast<Gender>().FirstOrDefault(x => (char)x == CodigoGender);
        
        public static FactorRh GetFactorRh(char CodigoFactorRh) => Enum.GetValues(typeof(FactorRh)).Cast<FactorRh>().FirstOrDefault(x => (int)x == CodigoFactorRh);


        public static string GetGenderName(Gender gender)
        {
            string name = gender switch
            {
                Gender.MALE => "Masculino",
                Gender.FEMALE => "Feminino"
            };
            return name;
        }

        public static string GetBloodTypeName(BloodType bloodType) 
        {
            string name = bloodType switch
            {
                BloodType.TYPE_A => "A",
                BloodType.TYPE_B => "B",
                BloodType.TYPE_AB => "AB",
                BloodType.TYPE_O => "O"
            };
            return name;
        }

        public static string GetFactorRhName(FactorRh factorRh) 
        {
            string name = factorRh switch 
            {
                FactorRh.RH_POSITIVE => "Positivo",
                FactorRh.RH_NEGATIVE => "Negativo"
            };
            return name;
        }

    }
}
