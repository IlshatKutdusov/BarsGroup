namespace _1_SOLID
{
    /// <summary>
    /// Сеньор
    /// </summary>
    public class SeniorEmployee : Employee, IEmployeeGetDetails, IWorkGetDetails
    {
        /// <summary>
        /// Метод для получения данных о сеньоре
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <returns>Данные о сеньоре</returns>
        public string GetEmployeeDetails(int employeeId)
        {
            return "Senior Employee";
        }

        /// <summary>
        /// Метод для получения данных о работе сеньора
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <returns>Данные о работе сеньора</returns>
        public string GetWorkDetails(int employeeId)
        {
            return "Senior Work";
        }
    }
}
