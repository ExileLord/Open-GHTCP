using System;

namespace GHNamespace6
{
    public class Class205 : ICloneable
    {
        private string _string0;

        private Class204 _class2040;

        private Class205()
        {
            _class2040 = new Class204();
        }

        public object Clone()
        {
            Class205 @class = new Class205
            {
                _string0 = _string0,
                _class2040 = (Class204)_class2040.Clone()
            };
            @class.method_1(method_0());
            return @class;
        }

        public override bool Equals(object obj)
        {
            return obj is Class205 @class && method_0().Equals(@class.method_0());
        }

        public override int GetHashCode()
        {
            return method_0().GetHashCode();
        }

        public string method_0()
        {
            return _class2040.method_0();
        }

        public void method_1(string string1)
        {
            _class2040.method_1(string1);
        }
    }
}