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
    interface IMagicSpell {        
        String SpellName { get; set; }
        void CastSpell();
    }

    class Weapon : IItem, IMagicSpell
    {
        public string Name { get; set; }
        public int GoldValue { get; set; }
        public string SpellName { get; set; }
        
        public void CastSpell()
        {
            Console.WriteLine($"Spell casted {SpellName}");
            Swing?.Invoke(this);
        }

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
        private Func<object, bool> Swing;

        public Weapon()
        {

        }
        public Weapon(Func<object, bool> func)
        {
            Swing = func;
        }

    }


    class Program
    {
        

         

        static void Main(string[] args)
        {
            List<Weapon> weapons = new List<Weapon>();
            weapons.Add(new Weapon { Name = "Axe", GoldValue = 100, SpellName = "Blackmagic" });
            weapons.Add(new Weapon { Name = "Hammer", GoldValue = 30, SpellName = "Ghostmagic" });
            weapons.Add(new Weapon { Name = "Spear", GoldValue = 50, SpellName = "Powerboost" });

            Weapon myweapon = new Weapon((object o) => {
                Console.WriteLine($"I guess someone swing this weapon { (o as Weapon).Name }");
                return true;
            });
            myweapon.Name = "Sledgehammer";



            weapons.Where(w => w.Name == "Hammer").FirstOrDefault().ThrowAway();
            weapons.Where(w => w.Name == "Axe").FirstOrDefault().CastSpell();
            myweapon.CastSpell();

            string strJson = JsonConvert.SerializeObject(weapons);
            Console.ReadLine();
        }
    }
}
