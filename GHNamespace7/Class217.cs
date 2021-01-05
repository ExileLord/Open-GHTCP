using System;
using System.IO;

namespace GHNamespace7
{
    public class Class217 : IDisposable
    {
        private readonly StringWriter _stringWriter0;

        private readonly TextWriter _textWriter0;

        private readonly string _string0;

        public Class217(string string1)
        {
            _string0 = string1;
            _textWriter0 = Console.Out;
            _stringWriter0 = new StringWriter();
            Console.SetOut(_stringWriter0);
        }

        public void Dispose()
        {
            Console.SetOut(_textWriter0);
            Class216.smethod_1(_string0, _stringWriter0.GetStringBuilder().ToString());
            _stringWriter0.Close();
        }
    }
}