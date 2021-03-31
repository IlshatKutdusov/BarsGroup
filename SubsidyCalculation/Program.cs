using System;

namespace SubsidyCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            Tariff tariff = new Tariff() { ServiceId = 1, HouseId = 1, PeriodBegin = DateTime.UtcNow, PeriodEnd = DateTime.UtcNow, Value = -10};
            Volume volume = new Volume() { ServiceId = 1, HouseId = 1, Month = DateTime.UtcNow, Value = 1000};
            SubsidyCalculation subsidyCalculation = new SubsidyCalculation();
            try {
                Charge charge = subsidyCalculation.CalculateSubsidy(volume, tariff);
                Console.WriteLine("{0} {1} {2} {3}", charge.ServiceId, charge.HouseId, charge.Month, charge.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! Message: " + ex.Message);
            }
            Console.ReadLine();
        }
    }
}
