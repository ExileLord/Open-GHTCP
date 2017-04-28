using System;

namespace GHNamespace9
{
    // Base class of some other classes that appear to edit qb files

    public abstract class QbEditor : IEquatable<QbEditor>
    {
        public bool method_0()
        {
            bool result;
            try
            {
                vmethod_0();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            return result;
        }

        public abstract void vmethod_0();

        public abstract override string ToString();

        public abstract bool Equals(QbEditor other);
    }
}