using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    interface IItem {
        string Name { get; set; }
        int GoldValue { get; set; }

        void Equip();
        void Sell();
        void ThrowAway();
    }

    class Weapon : IItem
    {
        public string Name { get; set; }
        public int GoldValue { get; set; }

        public void Equip()
        {
            Console.Write("Equipped");
        }

        public void Sell()
        {
            Console.WriteLine("Sold");
        }

        public void ThrowAway()
        {
            Console.WriteLine($"Threw away my { Name }");
        }
    }


    class Program
    {
        

         

        static void Main(string[] args)
        {
            List<Weapon> weapons = new List<Weapon>();
            weapons.Add(new Weapon { Name = "Axe", GoldValue = 100 });
            weapons.Add(new Weapon { Name = "Hammer", GoldValue = 30 });
            weapons.Add(new Weapon { Name = "Spear", GoldValue = 50 });

            weapons.Where(w => w.Name == "Hammer").FirstOrDefault().ThrowAway();

            string strJson = JsonConvert.SerializeObject(weapons);
            Console.ReadLine();
        }
    }
}
