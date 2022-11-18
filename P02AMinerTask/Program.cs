using System;
using System.Collections.Generic;
using System.Linq;

namespace P02AMinerTask
{
    internal class Program
    {
        private static object resourceQty;

        static void Main(string[] args)
        {
            Dictionary<string, long> resources = new Dictionary<string, long>();

            string resource;
            while ((resource = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(resource))
                {
                    resources[resource] = 0;
                }

                resources[resource] += quantity;
            }
            foreach (var rqp in resources)
            {
                string currResource = rqp.Key;
                Console.WriteLine($"{currResource} -> {resourceQty}");
            }
        }
    }
}
 