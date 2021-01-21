using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_Demo.Cores
{
    public sealed class EventAggregator : IEventAggregator
    {
        private readonly ConcurrentDictionary<String, dynamic> keyValuePairs = new ConcurrentDictionary<string, dynamic>();

        void IEventAggregator.Publish<TEventArgs>(string eventKey, TEventArgs eventArgs)
        {
            var action = keyValuePairs[eventKey] as Action<TEventArgs>;
            action?.Invoke(eventArgs);
        }

        void IEventAggregator.Subscribe<TEventArgs>(string eventKey, Action<TEventArgs> action)
        {
            keyValuePairs.GetOrAdd(eventKey, action);
        }

        void IEventAggregator.UnSubscribe(string eventKey)
        {
            dynamic action = default(dynamic);
            keyValuePairs.TryRemove(eventKey, out action);
        }
    }
}