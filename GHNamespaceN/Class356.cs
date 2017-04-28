using System;
using System.Collections.Generic;

namespace GHNamespaceN
{
    public class Class356 : INterface15
    {
        private DateTime _dateTime0 = DateTime.MinValue;

        private int _int0 = -1;

        private DateTime _dateTime1 = DateTime.MinValue;

        private Dictionary<string, bool> _dictionary0 = new Dictionary<string, bool>();

        private readonly Dictionary<string, bool> _dictionary1 = new Dictionary<string, bool>();

        public void imethod_0(string string0)
        {
            Console.WriteLine(string0);
        }

        public void imethod_1(string string0)
        {
            var stackTrace = Environment.StackTrace;
            Console.WriteLine("WARNING: " + string0);
            Console.WriteLine(stackTrace);
            if (_dictionary1.ContainsKey(stackTrace))
            {
                return;
            }
            while (true)
            {
                Console.Write("\tContinue? This can be dangerous, corrupt your files, etc! (y/n/y!): ");
                var text = Console.ReadLine();
                string a;
                if ((a = text.ToLower()) != null)
                {
                    if (a == "y")
                    {
                        return;
                    }
                    if (!(a == "n"))
                    {
                        if (a == "y!")
                        {
                            break;
                        }
                    }
                    else
                    {
                        Environment.Exit(-1);
                    }
                }
            }
            _dictionary1[stackTrace] = true;
        }
    }
}