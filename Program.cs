using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples
{
    class Program
    {
        //used as a dynamic method
        delegate void MyDelegate(string str);

        private static MyDelegate del;
    
        static void Main(string[] args)
        {
            #region delegate
            del = delegate(string str)
            {
                Console.WriteLine(str.ToUpper());
            };
#endregion
            del("hello world of delegates");

            #region delegate
            del = delegate(string str)
            {
                char[] chars = str.ToCharArray();
                foreach (char c in chars)
                {
                    Console.Write(c+" ");
                }
                Console.WriteLine();
            };
#endregion
            del("hello world of delegates");

            #region delegate
            del = str =>
            {
                char[] chars = str.ToCharArray();
                Array.Reverse(chars);
                foreach (char c in chars)
                {
                    Console.Write(c);
                }
                Console.WriteLine();
            };
            #endregion
            del("hello world of delegates");

            del = Del;
            del("hello world of delegates");

            Console.WriteLine("\n**************************\n\n");
           
            #region using predicates
            Predicate<String> predicate1 = new Predicate<String>(ContainsA);

            Predicate<String> predicate2 = delegate(String s)
            {
                return s.Contains("A") || s.Contains("a");
            };
            
            Predicate<String> predicate3 = s => s.Contains("A") || s.Contains("a");

            //Using a predicate
            List<String> strings = new List<string>() {"Ape", "Lion", "Tiger", "Koala"};
            var result = strings.FindAll(predicate1);
            foreach (string s in result)
            {
                Console.WriteLine(s);
            }
            #endregion

            Console.WriteLine("\n**************************\n\n");

            Func<String[], String> commaDelimiterFunc = delegate(string[] strings1)
            {
                return string.Join(", ", strings1);
            };

            Func<String[], String> writeInColumnFunc = delegate(string[] strings1)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("|----------|\n");
                foreach (string s in strings1)
                {
                    sb.Append("|"+s.PadRight(10)+"|\n");
                    sb.Append("|----------|\n");
                }
                return sb.ToString();
            };

            IDictionary<String, Func<String[], string>> displayArrayFunctions = new Dictionary<string, Func<string[], string>>();
            displayArrayFunctions.Add("Commaseparated", commaDelimiterFunc);
            displayArrayFunctions.Add("ColumnView", writeInColumnFunc);
            
            string[] stringsForFunc = {"Ape", "Lion", "Tiger"};
            //Console.WriteLine(commaDelimiterFunc(stringsForFunc));

            string format = displayArrayFunctions["ColumnView"](stringsForFunc);
            Console.WriteLine(format);
        }

        private static void Del(string str)
        {
            Random random = new Random();
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Count() - 5; i++)
            {
                int randomPosition = random.Next(0, chars.Count());
                chars[randomPosition] = Char.ToUpper(chars[randomPosition]);
            }
            foreach (char c in chars)
            {
                Console.Write(c);
            }
            Console.WriteLine();

        }
        
        private static bool ContainsA(String s)
        {
            if (s.Contains("A") || s.Contains("a")) return true;
            return false;
        }


    }
}
