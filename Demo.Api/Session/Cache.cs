using System.Collections.Generic;

namespace Demo.Api
{
    public static class Cache
    {
        private static readonly Dictionary<string, object> _cache = new();
        private static readonly object _sync = new();

        public static bool Exists(string key)
        {
            lock (_sync)
            {
                return _cache.ContainsKey(key);
            }
        }

        public static T Get<T>(string key) where T : class
        {
            lock (_sync)
            {
                if (!_cache.ContainsKey(key))
                {
                    return null;
                }

                lock (_sync)
                {
                    return (T)_cache[key];
                }
            }
        }

        public static bool Add<T>(string key, T value)
        {
            lock (_sync)
            {
                if (_cache.ContainsKey(key))
                {
                    return false;
                }

                lock (_sync)
                {
                    _cache.Add(key, value);
                }

                return true;
            }
        }

        public static bool Update<T>(string key, T value)
        {
            lock (_sync)
            {
                if (!_cache.ContainsKey(key))
                {
                    return false;
                }

                lock (_sync)
                {
                    _cache[key] = key;
                }

                return true;
            }
        }

        public static bool Delete(string key)
        {
            lock (_sync)
            {
                if (!_cache.ContainsKey(key))
                {
                    return false;
                }

                lock (_sync)
                {
                    _cache.Remove(key);
                }

                return true;
            }
        }

        public static bool Clear()
        {
            _cache.Clear();
            return true;
        }
    }
}
