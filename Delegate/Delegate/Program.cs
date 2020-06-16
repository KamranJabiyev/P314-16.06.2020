using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class Program
    {
        public delegate bool Checked(int n);
        public delegate void Write(string word);
        public delegate void GenericWrite<T>(T w);
        public delegate void FullInfo(string s1, string s2);
        //public delegate void Test(string word);
        static void Main(string[] args)
        {
            #region Delegate Start
            //int[] arr = { 5, 10, 15, 20, 25 };
            //Console.WriteLine(Sum(arr, IsElder));
            #endregion

            #region Anonimous method,lambda expression
            //Write write = new Write(WordLenght);
            //Write write = WordLenght;
            //write += WordUpper;
            //write += WordToLower;
            //write -= WordLenght;
            //write += delegate (string str) { Console.WriteLine($"Anonim:{str}"); }; //anonimous method
            ////write -= delegate (string str) { Console.WriteLine($"Anonim:{str}"); };
            //write += str => Console.WriteLine($"Lambda:{str}"); //lambda expression
            //write("Salam");
            //FullInfo info = (s1, s2) => Console.WriteLine($"{s1} {s2}");
            //info("Kamran", "Jabiyev");
            //GenericWrite<string> generic = delegate (string str) { Console.WriteLine(str); };
            //GenericWrite<int> generic1 = delegate (int n) { Console.WriteLine(n); };
            #endregion

            #region Action,Func,Predicate
            //Action<string> action = delegate (string str) { Console.WriteLine(str); };
            //action += WordLenght;
            //Action<int, int> action1 = (n1, n2) => Console.WriteLine(n1+n2);
            //Func<int, string> func = n => { return "Salam"; };
            //Func<int, bool> func1 = IsOdd;
            //func1 += IsEven;
            //Console.WriteLine(func1(14));
            //Predicate<int> predicate = IsOdd;
            #endregion

            #region Event
            Student s1 = new Student("Zahid", 66);
            Student s2 = new Student("Javidan", 80);
            s1.Mesaj += delegate (bool res)
              {
                  if (res)
                  {
                      Console.WriteLine("Halaldi ogluvuza,qizil diplom alib");
                  }
                  else
                  {
                      Console.WriteLine("Ishtirakchi olaraq kursu bitirdi");
                  }
              };

            s2.Mesaj += delegate (bool res)
            {
                if (res)
                {
                    Console.WriteLine("Tebrikler");
                }
                else
                {
                    Console.WriteLine("Oglunuz kesildi");
                }
            };

            s1.NotifyParent();
            s2.NotifyParent();
            #endregion
        }

        #region Anonimous method,lambda expression
        public static void WordLenght(string str)
        {
            Console.WriteLine($"String lenght: {str.Length}");
        }

        public static void WordUpper(string word)
        {
            Console.WriteLine($"String ToUpper: {word.ToUpper()}");
        }

        public static void WordToLower(string word)
        {
            Console.WriteLine($"String ToLower: {word.ToLower()}");
        }
        #endregion

        #region Delegate Start
        public static int Sum(int[] arr, Checked callback)
        {
            int result = 0;
            foreach (int number in arr)
            {
                if (callback(number))
                    result += number;
            }
            return result;
        }

        public static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public static bool IsElder(int number)
        {
            return number > 10;
        }
        #endregion
    }

    #region Event

    class Student
    {
        public string Name { get; set; }
        public int Result { get; set; }

        public event Action<bool> Mesaj;

        public Student(string name,int res)
        {
            Name = name;
            Result = res;
        }

        public void NotifyParent()
        {
            if (Result > 65)
            {
                Mesaj(true);
            }
            else
            {
                Mesaj(false);
            }
        }
    }

    #endregion
}
