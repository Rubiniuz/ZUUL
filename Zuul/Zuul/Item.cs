using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuul
{
    public class Item
    {
        private string name;
        private string description;
        private float weight;
        private int uses;
        public Item(string name , string description , int uses , float weight)
        {
            this.name = name;
            this.description = description;
            this.uses = uses;
            this.weight = weight;
        }

        public float GetWeight()
        {
            return weight;
        }
        public string GetName()
        {
            return name;
        }

        public int GetUses()
        {
            int u = this.uses;
            return u;
        }
        public void SetUses(int u)
        {
            this.uses = u;
        }

        public string GetShortDescription()
        {
            string shortDescription = name + description;
            return shortDescription;
        }
        public string GetLongDescription()
        {
            string longDescription = name + ". the item is: " + description + ". this item weighs: " + weight.ToString() + ".";
            return longDescription;
        }
        public virtual string GetUseDescription()
        {
            string useDescription = "";
            useDescription = "you used: " + this.name;
            return useDescription;
        }
        
        public virtual void Use(Player p)
        {
            this.uses--;
            Console.WriteLine(GetUseDescription());
        }
    }
}
