using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuul
{
    class Weapon : Item
    {
        private string name;
        private string description;
        private float weight;
        private string effect;
        private int uses;
        private int damage;
        public Weapon(string name, string description, int uses, float weight, int damage) : base(name, description, uses, weight)
        {
            this.name = name;
            this.description = description;
            this.uses = uses;
            this.weight = weight;
            this.damage = damage;
        }
        public override string GetUseDescription()
        {
            string useDescription = "";
            useDescription = "You Used: " + name + " and you Slash Around. you did: " + damage.ToString() + " damage.";
            return useDescription;
        }

        public override void Use(Player p)
        {
            this.uses--;
            Console.WriteLine(GetUseDescription());
        }
    }
}
