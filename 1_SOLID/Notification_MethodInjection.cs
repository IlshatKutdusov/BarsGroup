namespace _1_SOLID
{
    /// <summary>
    /// Уведомления
    /// </summary>
    public class Notification_MethodInjection
    {
        /// <summary>
        /// Метод для уведомления
        /// </summary>
        /// <param name="messenger">Мессенджер</param>
        public void DoNotify(IMessenger messenger)
        {
            messenger.Send();
        }
    }
}
