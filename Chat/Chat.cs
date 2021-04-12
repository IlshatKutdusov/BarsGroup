using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Chat
{
    public class Chat
    {
        private readonly string _host;
        private readonly int _port;
        private string _chatKey, _userKey;

        private Dictionary<long, string> _messageList = new Dictionary<long, string>();

        private ConnectionMultiplexer _redis;
        private IDatabase _dataBase;

        public Chat(string host = "localhost", int port = 6379)
        {
            this._host = host;
            this._port = port;
            Init();
        }

        private string ValidatingConsoleInput()
        {
            string result, pattern = @"^[A-Za-z0-9]+$";

            do
            {
                result = Console.ReadLine();
                if (!Regex.IsMatch(result, pattern, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Ошибка! Некорректное значение. Необходимо повторить ввод: ");
                }
                else
                    break;

            } while (true);

            return result;
        }

        private void Init()
        {
            var conf = new ConfigurationOptions();
            conf.EndPoints.Add(_host, _port);

            _redis = ConnectionMultiplexer.Connect(conf);
            _dataBase = _redis.GetDatabase(0);

            Console.WriteLine("Укажите чат:");
            _chatKey = ValidatingConsoleInput();

            Console.WriteLine("Введите свой ник:");
            _userKey = ValidatingConsoleInput();

            Console.WriteLine("Добро пожаловать в чат {0}, {1}!", _chatKey, _userKey);

            DownloadMessage(true);

            ChattingStart();
        }

        private void DownloadMessage(bool all)
        {
            if (_dataBase.KeyExists(_chatKey))
            {
                if (all == true)
                {
                    for (int i = 0; i < _dataBase.ListLength(_chatKey); i++)
                    {
                        _messageList.Add(i, _dataBase.ListGetByIndex(_chatKey, i));
                    }

                    foreach (var message in _messageList)
                    {
                        Console.WriteLine("{0}", message.Value);
                    }
                }
                else
                {
                    _messageList.Add(_dataBase.ListLength(_chatKey) - 1, _dataBase.ListGetByIndex(_chatKey, _dataBase.ListLength(_chatKey) - 1));
                    Console.WriteLine("{0}", _messageList[_dataBase.ListLength(_chatKey) - 1]);
                }
            }
        }

        private void ChattingStart()
        {
            do
            {
                Console.Write("<{0}>: ", _userKey);
                string message = Console.ReadLine();
                if (message != "/exit" && message != "")
                {
                    _dataBase.ListRightPush(_chatKey, $"<{_userKey}>: {message}");
                    _messageList.Add(_messageList.Count, message);
                }
                else
                    break;

            } while (true);
        }
    }
}
