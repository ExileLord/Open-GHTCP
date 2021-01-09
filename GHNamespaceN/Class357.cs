using System;
using System.Collections.Generic;
using GHNamespaceG;

namespace GHNamespaceN
{
    public class Class357 : IDisposable, IEmptyInterface1
    {
        private Class352[] _class3520;

        private readonly List<IEmptyInterface1> _list0;

        public void Dispose()
        {
            foreach (IEmptyInterface1 current in _list0)
            {
                current.Dispose();
            }
            for (int i = 0; i < _class3520.Length; i++)
            {
                _class3520[i].Dispose();
            }
        }
    }
}