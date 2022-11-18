using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.LegendaryFarming
{
    internal class Program
    {
        private static string currMaterial;
        private static int currMaterialQty;

        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>() { { "shards", 0 }, { "motes", 0 }, { "fragments", 0 } };

            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            string legendaryItem = string.Empty;
            bool isFound = false;

            while (legendaryItem == "")
            {
                string[] foundMaterials = Console.ReadLine().Split();

                for (int i = 0; i < foundMaterials.Length; i += 2)
                {
                    int quantity = int.Parse(foundMaterials[i]);
                    string materialName = foundMaterials[i + 1].ToLower();

                    CollectItems(quantity, materialName, keyMaterials, junkMaterials);

                    if (keyMaterials.ContainsKey(materialName))
                    {
                        if (keyMaterials[materialName] >= 250)
                        {
                            legendaryItem = GetLegendaryItemName(materialName);

                            keyMaterials[materialName] -= 250;
                            isFound = true;
                        }
                    }

                    if (isFound)
                    {
                        break;
                    }

                }
            }

            Console.WriteLine($"{legendaryItem} obtained!");

            foreach (var item in keyMaterials)
            {
                Console.WriteLine($"{item.Key.ToLower()}: {item.Value}");
            }

            foreach (var item in junkMaterials)
            {
                Console.WriteLine($"{item.Key.ToLower()}: {item.Value}");
            }
        }

        public static void CollectItems(int quantity, string material, Dictionary<string, int> keyMaterials, Dictionary<string, int> junkMaterials)
        {
            if (keyMaterials.ContainsKey(material))
            {
                keyMaterials[material] += quantity;
            }
            else
            {
                if (junkMaterials.ContainsKey(material))
                {
                    junkMaterials[material] += quantity;
                }
                else
                {
                    junkMaterials.Add(material, quantity);
                }
            }
        }

        public static string GetLegendaryItemName(string materialName)
        {
            if (materialName == "shards")
            {
                return "Shadowmourne";
            }
            else if (materialName == "motes")
            {
                return "Dragonwrath";
            }
            else if (materialName == "fragments")
            {
                return "Valanyr";
            }

            return "";
        } 
    }
}
