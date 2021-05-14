namespace _1_SOLID
{
    /// <summary>
    /// Генерация отчета
    /// </summary>
    public interface IEmployeeReportGenerate
    {
        /// <summary>
        /// Метод для генерации отчета
        /// </summary>
        /// <param name="employee"></param>
        void GenerateReport(Employee employee);
    }
}
