using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Palermo.BlazorMvc
{
    public class MvcBus : IUiBus
    {
        private bool _disposed;
        private readonly ISet<IListener> _listeners = new HashSet<IListener>();
        private readonly ILogger<MvcBus> _logger;

        public MvcBus(ILogger<MvcBus> logger)
        {
            _logger = logger;
        }

        public void Register(IListener listener)
        {
            if (listener == null) return;
            _logger.LogDebug("Listener registering: {0}", GetObjectIdentifier(listener));

            _listeners.Add(listener);
        }

        public void UnRegister(IListener listener)
        {
            _logger.LogDebug("Listener unregistering: {0}", GetObjectIdentifier(listener));
            _listeners.Remove(listener);
        }

        public IListener<T>[] GetListeners<T>() where T : IUiBusEvent
        {
            IEnumerable<IListener> listeners = _listeners.Where(c => c is IListener<T>);
            IEnumerable<IListener<T>> enumerable = listeners.Select(listener => (IListener<T>)listener);
            return enumerable.ToArray();
        }

        public void Notify<T>(T notification) where T : IUiBusEvent
        {
            IListener<T>[] listeners = GetListeners<T>();
            string message = string.Format("Notifying {0} of {1} listeners with {2} on bus {3}",
                listeners.Length, _listeners.Count, notification.GetType().Name, GetHashCode());
            
            _logger.LogInformation(message);
            foreach (IListener<T> listener in listeners)
            {
                _logger.LogInformation("Notifying: {0} with {1}", 
                    GetObjectIdentifier(listener), notification.GetType().Name);
                listener.Handle(notification);
            }
        }

        public void UnRegisterAll()
        {
            _listeners.Clear();
        }

        private static string GetObjectIdentifier(object obj)
        {
            return $"{obj.GetType().Name}-{obj.GetHashCode()}";
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) { return; }
            if (disposing) {
                UnRegisterAll();
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}