using System;
using System.Collections.Generic;

namespace ConsoleAppTest
{
    class Program
    {
        //#1
        /*class A
        {
            virtual void Foo() //нужно поставить модификатор public
            {
                Console.Write("Class A");
            }
        }

        class B : A
        {
            override void Foo() //нужно поставить модификатор public
            {
                Console.Write("Class B");
            }
        }

        static void Main(string[] args)
        {
            B obj1 = new A(); //неправильное приведение
            obj1.Foo();

            B obj2 = new B();
            obj2.Foo();

            A obj3 = new B();
            obj3.Foo();

            Console.ReadLine();
        }*/
        //Class B, ClassB



        //#2
        /*public struct S : IDisposable //заменить struct на class
        {
            private bool dispose;

            public void Dispose()
            {
                dispose = true;
            }

            public bool GetDispose()
            {
                return dispose;
            }
        }

        static void Main(string[] args)
        {
            var s = new S();
            using (s)
            {
                Console.WriteLine(s.GetDispose());
            }

            Console.WriteLine(s.GetDispose());

            Console.ReadLine();
        }*/
        //False,False; Если поправить, то False, True



        //#3
        /*static void Main(string[] args)
        {
            List<Action> actions = new List<Action>();
            for (var count = 0; count < 10; count++)
            {
                actions.Add(() => Console.WriteLine(count));
            }

            foreach (var action in actions)
            {
                action(); //обращение к переменной count, которая осталась равно 10
            }

            Console.ReadLine();
        }*/
        //10,10,10, ... ,10,10



        //#4
        /*static void Main(string[] args)
        {
            int i = 1;
            object obj = i;
            ++i;

            Console.WriteLine(i);
            Console.WriteLine(obj);
            Console.WriteLine((short)obj); //System.InvalidCastException: "Unable to cast object of type 'System.Int32' to type 'System.Int16'."

            Console.ReadLine();
        }*/
        //2,1



        //#5
        /*static void Main(string[] args)
        {
            var s1 = string.Format("{0}{1}", "abc", "cba");
            var s2 = "abc" + "cba";
            var s3 = "abccba";

            Console.WriteLine(s1 == s2);
            Console.WriteLine((object)s1 == (object)s2);
            Console.WriteLine(s2 == s3);
            Console.WriteLine((object)s2 == (object)s3);

            Console.ReadLine();
        }*/
        //true,false, true,true


        //#6
        /*private static Object suncObject = new Object();
        private static void Write()
        {
            lock (suncObject)
            {
                Console.WriteLine("test");
            }
        }

        static void Main(string[] args)
        {
            lock (suncObject)
            {
                Write();
            }

            Console.ReadLine();
        }*/
        //test



        //#7
    }
}
