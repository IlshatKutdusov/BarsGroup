namespace _1_SOLID
{
    /// <summary>
    /// Уведомления
    /// </summary>
    public class Notification_PropertyInjection
    {
        /// <summary>
        /// Мессенджер
        /// </summary>
        private IMessenger _messenger;


        /// <summary>
        /// Задание мессенджера через свойство
        /// </summary>
        public IMessenger Messenger
        {
            set
            {
                _messenger = value;
            }
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
