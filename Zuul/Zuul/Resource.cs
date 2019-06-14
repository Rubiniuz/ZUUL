using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuul
{
    public class Resource : Item
    {
        private string name;
        private string description;
        private float weight;
        private int uses;
        private string resourceType;
        private int maxStack;
        private int amount = 0;
        public Resource(string name, string description, int uses, float weight, int maxStack, string resourceType) : base(name, description, uses, weight)
        {
            this.name = name;
            this.description = description;
            this.uses = uses;
            this.weight = weight;
            this.resourceType = resourceType;
            this.maxStack = maxStack;
        }

        public void AddWeight(float w)
        {
            weight += w;
        }
        public void RemoveWeight(float w)
        {
            weight -= w;
        }

        public string GetResourceType()
        {
            return resourceType;
        }

        public override void Use(Player p)
        {
            Console.WriteLine("you can't use wood");
        }

        public int Amount{
            get { return amount; }

            set{
                if (value > maxStack)
                {
                    amount = maxStack;
                }
                else
                {
                    amount = value;
                }
            }
        }
    }
}
