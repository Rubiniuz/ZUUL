using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuul
{
    class BadItem : Item
    {
        private string name;
        private string description;
        private float weight;
        private int uses;
        private int damage;
        public BadItem(string name, string description, int uses , float weight , int damage) : base(name, description, uses, weight)
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
            useDescription = "You used: " + this.name + " and you lost:" + this.damage.ToString() + "health";
            return useDescription;
        }

        public override void Use(Player p)
        {
            p.Damage(damage);
            Console.WriteLine(GetUseDescription());
        }
    }
}