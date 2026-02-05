using System;
using System.Collections.Generic;


namespace Core.SigBus
{
    public class SignalBus
    {
        private readonly Dictionary<Type, Delegate> signals = new Dictionary<Type, Delegate>();


        public void Subscribe<T>(Action<T> handler)
        {
            var type = typeof(T);

            if (!signals.ContainsKey(type))
            {
                signals[type] = null;
            }

            signals[type] = Delegate.Combine(signals[type], handler);
        }


        public void Unsubscribe<T>(Action<T> handler)
        {
            var type = typeof(T);

            if (signals.TryGetValue(type, out var existingDelegate))
            {
                var result = Delegate.Remove(existingDelegate, handler);

                if (result == null)
                {
                    signals.Remove(type);
                }
                else
                {
                    signals[type] = result;
                }
            }
        }


        public void Fire<T>(T signal)
        {
            var type = typeof(T);

            if (signals.TryGetValue(type, out var del))
            {
                (del as Action<T>)?.Invoke(signal);
            }
        }


        public void Clear()
        {
            signals.Clear();
        }
    }
}
