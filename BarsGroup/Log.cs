using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;

namespace BarsGroup
{
    public class Log : ILog
    {
        const double CheckInterval = 1000 * 60 * 30; // [мс]*[с]*[мин] Каждые 30 минут проверка
        private int nowDay;
        private Dictionary<string, string> DayErrorCollection = new Dictionary<string, string>();
        private Dictionary<string, string> DayWarningCollection = new Dictionary<string, string>();
        private string LogFilePath;
        private readonly string ApplicationPath = Directory.GetCurrentDirectory();
        public Log()
        {
            this.LogFilePath = ApplicationPath + "\\logs\\" + DateTime.UtcNow.Year + "-" + DateTime.UtcNow.Month + "-" + DateTime.UtcNow.Day + ".txt";
            Init();
            nowDay = DateTime.UtcNow.Day;
            Timer inspector = new Timer(CheckInterval);
            inspector.Elapsed += new ElapsedEventHandler(Checking);
            inspector.Start();
        }

        private void Checking(object sender, ElapsedEventArgs e)
        {
            if (nowDay != DateTime.UtcNow.Day)
            {
                Init();
                nowDay = DateTime.UtcNow.Day;
            }
        }

        private void Init()
        {
            try
            {
                DayErrorCollection.Clear();
                DayWarningCollection.Clear();

                if (!File.Exists(LogFilePath))
                {
                    if (!Directory.Exists(ApplicationPath + "\\logs"))
                        Directory.CreateDirectory(ApplicationPath + "\\logs");
                    using (File.Create(LogFilePath)) ;
                    StreamWriter sw = new StreamWriter(LogFilePath);
                    sw.WriteLine(DateTime.UtcNow + " # Logger started # ");
                    sw.Close();
                }
                else
                {
                    using (StreamReader sr = new StreamReader(LogFilePath))
                    {
                        while (!sr.EndOfStream)
                        {
                            string str = sr.ReadLine();
                            string[] arr = str.Split(" # ");
                            if (arr[1] == "ERROR")
                                DayErrorCollection.Add(arr[0], arr[2]);
                            if (arr[1] == "WARNING")
                                DayWarningCollection.Add(arr[0], arr[2]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! Message: " + ex);
            }
        }

        private void SendToFile(string message, string e)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(LogFilePath, true))
                {
                    sw.WriteLine("{0} # {1} # {2}", DateTime.UtcNow, message, e);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! Message: " + ex.Message);
            }
        }

        public void Fatal(string message)
        {
            //Process.GetCurrentProcess().Kill();
            SendToFile("FATAL", message);
        }
        public void Fatal(string message, Exception e)
        {
            //Process.GetCurrentProcess().Kill();
            SendToFile("FATAL", message + " " + e.Message);
        }
        public void Error(string message)
        {
            try
            {
                SendToFile("ERROR", message);
                DayErrorCollection.Add(message, "ERROR");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! Message: " + ex.Message);
            }
        }
        public void Error(string message, Exception e)
        {
            try
            {
                SendToFile("ERROR", message + " " + e.Message);
                DayErrorCollection.Add(message, e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! Message: " + ex.Message);
            }
        }
        public void Error(Exception e)
        {
            try
            {
                SendToFile("ERROR", e.Message);
                DayErrorCollection.Add(e.Message, "ERROR");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! Message: " + ex.Message);
            }
        }
        public void ErrorUnique(string message, Exception e)
        {
            try
            {
                string value;
                if (!DayErrorCollection.TryGetValue(message, out value))
                    if (!DayErrorCollection.TryGetValue(e.Message, out value))
                        SendToFile("ERROR", message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! Message: " + ex.Message);
            }
        }
        public void Warning(string message)
        {
            try
            {
                SendToFile("WARNING", message);
                DayWarningCollection.Add(message, "WARNING");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! Message: " + ex.Message);
            }
        }
        public void Warning(string message, Exception e)
        {
            try
            {
                SendToFile("WARNING", message + " " + e.Message);
                DayWarningCollection.Add(message, e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! Message: " + ex.Message);
            }
        }
        public void WarningUnique(string message)
        {
            try
            {
                string value;
                if (!DayWarningCollection.TryGetValue(message, out value))
                    SendToFile("WARNING", message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! Message: " + ex.Message);
            }
        }
        public void Info(string message)
        {
            SendToFile("INFO", message);
        }
        public void Info(string message, Exception e)
        {
            SendToFile("INFO", message + " " + e.Message);
        }
        public void Info(string message, params object[] args)
        {
            SendToFile("INFO", message + " " + args);
        }
        public void Debug(string message)
        {
            SendToFile("DEBUG", message);
        }
        public void Debug(string message, Exception e)
        {
            SendToFile("DEBUG", message + " " + e.Message);
        }
        public void DebugFormat(string message, params object[] args)
        {
            SendToFile("DEBUG", message + " " + args);
        }
        public void SystemInfo(string message, Dictionary<object, object> properties = null)
        {
            try
            {
                if (properties != null)
                    foreach (var x in properties)
                        SendToFile("SYSTEMINFO", message + " " + x.Key + " " + x.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! Message: " + ex.Message);
            }
        }
    }
}
