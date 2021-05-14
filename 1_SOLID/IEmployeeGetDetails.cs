namespace _1_SOLID
{
    /// <summary>
    /// Данные о сотруднике
    /// </summary>
    public interface IEmployeeGetDetails
    {
        /// <summary>
        /// Метод для получения информации о сотруднике
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        string GetEmployeeDetails(int employeeId);
    }
}
