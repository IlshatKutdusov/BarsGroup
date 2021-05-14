namespace _1_SOLID
{
    /// <summary>
    /// Базовый отчет
    /// </summary>
    public class EmployeeReport : IEmployeeReportGenerate
    {
        /// <summary>
        /// Метод для генерации базоваого отчета
        /// </summary>
        /// <param name="employee"></param>
        public virtual void GenerateReport(Employee employee)
        {
            // Базовая генерация отчета
        }
    }
}
