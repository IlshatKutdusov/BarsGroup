namespace _1_SOLID
{
    /// <summary>
    /// Основной класс сотрудннка
    /// </summary>
    public class Employee
    {
        public int ID { get; set; }
        public string FullName { get; set; }

        /// <summary>
        /// Метод для добавления в БД нового сотрудника
        /// </summary>
        /// <param name="employee">Объект для вставки</param>
        /// <returns>Результат вставки новых данных</returns>
        public bool Add(Employee employee)
        {
            // Вставка данных сотрудника в таблицу БД
            return true;
        }
    }
}
