namespace _1_SOLID
{
    /// <summary>
    /// Стажер
    /// </summary>
    public class JuniorEmployee : Employee, IEmployeeGetDetails
    {
        /// <summary>
        /// Метод для получения данных о стажере
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <returns>Данные о стажере</returns>
        public string GetEmployeeDetails(int employeeId)
        {
            return "Junior Employee";
        }
    }
}
