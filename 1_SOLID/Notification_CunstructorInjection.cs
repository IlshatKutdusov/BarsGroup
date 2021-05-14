namespace _1_SOLID
{
    /// <summary>
    /// Уведомления
    /// </summary>
    public class Notification_CunstructorInjection
    {
        /// <summary>
        /// Мессенджер
        /// </summary>
        private IMessenger _messenger;

        /// <summary>
        /// Конструктор с заданием мессенджера
        /// </summary>
        /// <param name="messenger">Мессенджер</param>
        public Notification_CunstructorInjection(IMessenger messenger)
        {
            _messenger = messenger;
        }

        /// <summary>
        /// Метод для уведомления
        /// </summary>
        public void DoNotify()
        {
            _messenger.Send();
        }
    }
}
