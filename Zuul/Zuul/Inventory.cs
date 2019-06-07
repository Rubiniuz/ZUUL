using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuulCS;

namespace Zuul
{
    public class Inventory
    {
        Dictionary<string, Item> inventory = new Dictionary<string, Item>();
        private float carryLimit;
        private float weight = 0;
        public Inventory(float cl)
        {
            carryLimit = cl;
        }
        public void AddWeight(float w)
        {
            weight += w;
        }
        public float GetWeight()
        {
            return weight;
        }
        public float GetCarryLimit()
        {
            return carryLimit;
        }
        public Item RemoveItem(string n)
        {
            Item item;
            if (inventory.ContainsKey(n))
            {
                item = inventory[n];
                this.AddWeight(-item.GetWeight());
                inventory.Remove(n);
                return item;
            }
            else
            {
                return null;
            }
        }
        public void AddItem(Item item)
        {
            if (item == null)
            {

            }
            else
            {
                inventory[item.GetName()] = item;
                this.AddWeight(item.GetWeight());
            }
        }
        public Item GetItem(string n)
        {
            Item item;
            if (inventory.ContainsKey(n))
            {
                item = inventory[n];
                return item;
            }
            else
            {
                return null;
            }
        }
        public string GetItems()
        {
            string returnstring = "Items:";

            // because `inventory` is a Dictionary, we can't use a `for` loop
            int commas = 0;
            foreach (string key in inventory.Keys)
            {
                if (commas != 0 && commas != inventory.Count)
                {
                    returnstring += ",";
                }
                commas++;
                returnstring += " " + key;
            }
            return returnstring;
        }
        public void UseItem(Item i , Player p)
        {
            Item item = i;
            if (i != null)
            {
                int u = item.GetUses();
                Player player = p;
                if (u > 1)
                {
                    i.Use(p);
                }
                else if (u <= 1)
                {
                    i.Use(p);
                    AddWeight(-i.GetWeight());
                    this.RemoveItem(item.GetName());
                    Console.WriteLine("Player used up the: " + item.GetName());
                }
            }
            else
            {
                Console.WriteLine("I dont have that item.");
                Console.WriteLine("p.s make sure the first letter is a capital letter");
            }
        }

        public void UseKey(Player p, Item k, Room r)
        {
            Key key = (Key)k;
            int u = k.GetUses();
            Room room = r;
            if (u > 1)
            {
                key.Unlock(r);
                Console.WriteLine("Player used: " + k.GetName() + " and was able to unlock the room");
            }
            else if (u <= 1)
            {
                key.Unlock(r);
                AddWeight(-k.GetWeight());
                this.RemoveItem(k.GetName());
                Console.WriteLine("Player used up the: " + k.GetName() + " but was able to unlock the room");
            }
            else
            {
                Console.WriteLine("Item.ErrorMessage");
            }
        }
    }
}
