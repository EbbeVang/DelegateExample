using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExamples
{
    class Calculator
    {
        //definition
        public delegate double calculator(double a, double b);

        public static calculator Add = (d, d1) => d+d1;

        public static calculator Substract = (d, d1) => d-d1;

        public static calculator Divide = (d, d1) => d/d1;

        public static calculator Multiply = (d, d1) => d*d1;

        public Dictionary<String, calculator> Calculators = new Dictionary<string, calculator>();

        public Calculator()
        {
            Calculators.Add("+", Add);
            Calculators.Add("-", Substract);
            Calculators.Add("/", Divide);
            Calculators.Add("*", Multiply);

        }
    }
}
