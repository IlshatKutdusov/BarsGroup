using System;

namespace SubsidyCalculation
{
    public class SubsidyCalculation : ISubsidyCalculation
    {
        public event EventHandler<string> OnNotify;
        public event EventHandler<Tuple<string, Exception>> OnException;

        public Charge CalculateSubsidy(Volume volumes, Tariff tariff)
        {
            OnNotify?.Invoke(this, $"Расчёт начат в {DateTime.UtcNow:G}");

            Charge charge = null;

            if (isCorrectData(volumes, tariff))
            {
                try
                {
                    charge = new Charge();
                    charge.ServiceId = volumes.ServiceId;
                    charge.HouseId = volumes.HouseId;
                    charge.Month = volumes.Month;
                    charge.Value = volumes.Value * tariff.Value;
                }
                catch (Exception ex)
                {
                    OnException?.Invoke(this, new Tuple<string, Exception>("Subsidy calculation error! Message: ", ex));
                    throw;
                }
            }

            OnNotify?.Invoke(this, $"Расчёт успешно завершён в {DateTime.UtcNow:G}");

            return charge;
        }

        private bool isCorrectData(Volume volumes, Tariff tariff)
        {
            if (volumes.ServiceId != tariff.ServiceId)
                InvalidInput("ServiceId", new Exception("Идентификаторы услуг у объёма и у тарифа не совпадают!"));
            if (volumes.HouseId != tariff.HouseId)
                InvalidInput("HouseId", new Exception("Идентификаторы домов у объёма и у тарифа не совпадают!"));
            if (tariff.PeriodBegin.Month <= volumes.Month.Month && volumes.Month.Month <= tariff.PeriodEnd.Month)
                InvalidInput("Month", new Exception("Месяц объёма не входит в период действия тарифа!"));
            if (tariff.Value <= 0)
                InvalidInput("Tariff Value", new Exception("Нулевое или отрицательное значение тарифа!"));
            if (volumes.Value < 0)
                InvalidInput("Volumes Value", new Exception("Отрицательное значение объема!"));
            return true;
        }

        private void InvalidInput(string message, Exception ex)
        {
            OnException?.Invoke(this, new Tuple<string, Exception>(message, ex));
            throw ex;
        }
    }
}
