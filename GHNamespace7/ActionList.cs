using System;
using System.Collections.Generic;
using System.Threading;
using GHNamespace9;

namespace GHNamespace7
{
    public class ActionList
    {
        public delegate void Delegate6(object sender, EventArgs0 e);

        private Delegate6 _delegate60;

        private readonly List<QbEditor> _actionList;

        public void method_0(Delegate6 delegate61)
        {
            var @delegate = _delegate60;
            Delegate6 delegate2;
            do
            {
                delegate2 = @delegate;
                var value = (Delegate6) Delegate.Combine(delegate2, delegate61);
                @delegate = Interlocked.CompareExchange(ref _delegate60, value, delegate2);
            } while (@delegate != delegate2);
        }

        public ActionList(List<QbEditor> actionList)
        {
            _actionList = actionList;
        }

        public void method_1()
        {
            EventArgs0 e;
            foreach (var current in _actionList)
            {
                var int_ = 100 * _actionList.IndexOf(current) / _actionList.Count;
                e = new EventArgs0(current + " Processing...", int_);
                _delegate60(this, e);
                string finalStatus;
                using (new Class217(current.ToString()))
                {
                    if (current.method_0())
                    {
                        finalStatus = "DONE!\n";
                    }
                    else
                    {
                        finalStatus = "FAILED!\n";
                    }
                }
                e = new EventArgs0(finalStatus, int_);
                _delegate60(this, e);
            }
            e = new EventArgs0("", 100);
            _delegate60(this, e);
        }
    }
}