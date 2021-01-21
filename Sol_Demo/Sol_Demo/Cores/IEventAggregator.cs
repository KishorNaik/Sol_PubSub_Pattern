using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Cores
{
    public interface IEventAggregator
    {
        void Subscribe<TEventArgs>(string eventKey, Action<TEventArgs> action);

        void UnSubscribe(string eventKey);

        void Publish<TEventArgs>(string eventKey, TEventArgs eventArgs);
    }
}