using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuul
{
    class Food : Item
    {
        private string name;
        private string description;
        private float weight;
        private int uses;
        private int healing;
        public Food(string name, string description, int uses, float weight, int healing) : base(name, description, uses, weight)
        {
            this.name = name;
            this.description = description;
            this.uses = uses;
            this.weight = weight;
            this.healing = healing;
        }
        public override string GetUseDescription()
        {
            string useDescription = "";
            useDescription = this.name + " and you lost:" + this.healing.ToString() + "health";
            return useDescription;
        }

        public override void Use(Player p)
        {
            this.uses--;
            Console.WriteLine(GetUseDescription());
        }
    }
}
