namespace GHNamespaceL
{
    public class Class142
    {
        public long Long0;

        public long Long1;

        public int Int0;

        public Class142(Class144 class1440)
        {
            Long0 = class1440.vmethod_13(64);
            Long1 = class1440.vmethod_13(64);
            Int0 = class1440.vmethod_10(16);
        }

        public override string ToString()
        {
            return string.Concat("sampleNumber=", Long0, " streamOffset=", Long1, " frameSamples=", Int0);
        }
    }
}