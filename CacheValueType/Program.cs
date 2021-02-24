using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CacheValueType
{
    class Program
    {
        static void Main(string[] args)
        {
            var runner = new Runner();
            runner.Run();
        }
    }

    class Runner
    {
        public void Run()
        {
            var types = this.GetType().Assembly.GetTypes();
            var cacheTypes = types.Where(t => t.GetInterfaces().Any(x =>
                x.IsGenericType &&
                x.GetGenericTypeDefinition() == typeof(ICache<,>)));
            // Nun habe ich BoolCache und ComplexCache
            // Jetzt will ich den zweiten der generischen Parameter haben
            foreach (var cacheType in cacheTypes)
            {
                var genTypes = cacheType
                    .GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICache<,>))
                    .SelectMany(i => i.GetGenericArguments())
                    .ToArray();
                
                Console.WriteLine();
                Console.WriteLine(cacheType);
                foreach (var genType in genTypes)
                {
                    Console.WriteLine(genType);
                }
            }
        }
    }
    interface ICache<K, V>
    {
        void SetValue(K key, V value);
        V GetValue(K key);
    }

    class BoolCache : ICache<string, bool>
    {
        public void SetValue(string key, bool value)
        {
            throw new NotImplementedException();
        }

        public bool GetValue(string key)
        {
            throw new NotImplementedException();
        }
    }

    class ComplexCache : ICache<string, Tuple<string, bool, int>>
    {
        public void SetValue(string key, Tuple<string, bool, int> value)
        {
            throw new NotImplementedException();
        }

        public Tuple<string, bool, int> GetValue(string key)
        {
            throw new NotImplementedException();
        }
    }
}