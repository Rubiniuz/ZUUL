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
        public Item(string n , string d , float w)
        {
            name = n;
            description = d;
            weight = w;
        }

        public float GetWeight()
        {
            return weight;
        }
        public string GetName()
        {
            return name;
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

    }
}
