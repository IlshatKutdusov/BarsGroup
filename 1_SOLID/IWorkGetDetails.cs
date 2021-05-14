namespace _1_SOLID
{
    /// <summary>
    /// Данные о работе
    /// </summary>
    public interface IWorkGetDetails
    {
        /// <summary>
        /// Метод для получения данных о работе
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        string GetWorkDetails(int employeeId);
    }
}
