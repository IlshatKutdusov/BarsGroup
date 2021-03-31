using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BarsGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            Log logger = new Log();
            logger.Fatal("Fatal error!");
            logger.Error(new IndexOutOfRangeException());
            logger.ErrorUnique("Fatal error!", new IndexOutOfRangeException());
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add(1,"100");
            dict.Add(2, "200");
            dict.Add(3, "300");
            logger.SystemInfo("SystemInfo", dict);
            logger.Warning("Warning1!!!");
            logger.WarningUnique("Warning1!!!");
            Console.ReadLine();
        }
    }
}
