using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DailyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryCacheImpl<object> memory = new MemoryCacheImpl<object>("TestDev",CacheManager.Core.ExpirationMode.None,TimeSpan.FromDays(100));
            memory.Put("Key1", "dev", "The First Keys");
            object obj = memory.Get("Key1", "dev");
            Console.WriteLine(obj.ToString());

            MemoryCacheImpl<object> memory1 = new MemoryCacheImpl<object>("TestDev1", CacheManager.Core.ExpirationMode.None, TimeSpan.FromDays(100));
            memory1.Put("Key2", "dev", "The Second Keys");
            obj = memory1.Get("Key2", "dev");
            Console.WriteLine(obj.ToString());

            obj = memory.Get("Key1", "dev");
            Console.WriteLine(obj.ToString());

            memory.Clear();

            obj = memory1.Get("Key2", "dev");
            Console.WriteLine(obj.ToString());

            obj = memory.Get("Key1", "dev");
            if (obj == null)
                Console.WriteLine("The Value is Null");

            memory = new MemoryCacheImpl<object>("TestDev", CacheManager.Core.ExpirationMode.None, TimeSpan.FromDays(100));
            memory.Put("Key2", "dev", "The Third Keys");
            obj = memory.Get("Key2", "dev");
            Console.WriteLine(obj.ToString());

            obj = memory1.Get("Key2", "dev");
            Console.WriteLine(obj.ToString());

            Console.ReadKey();
        }
    }
}
