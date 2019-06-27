using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuul
{
    public class Meds : Item
    {
        private string name;
        private string description;
        private float weight;
        private int uses;
        public Meds(string name, string description, int uses, float weight) : base(name, description, uses, weight)
        {
            this.name = name;
            this.description = description;
            this.uses = uses;
            this.weight = weight;
        }
        public override string GetUseDescription()
        {
            string useDescription = "";
            useDescription = "you used: " + this.name + " and you stop the bleeding";
            return useDescription;
        }

        public override void Use(Player p)
        {
            if (p.Bleeding)
            {
                p.Bleeding = false;
            }
            Console.WriteLine(GetUseDescription());
        }
    }
}
