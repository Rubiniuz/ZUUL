﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuulCS;

namespace Zuul
{
    public class Inventory
    {
        private Dictionary<string, Item> inventory = new Dictionary<string, Item>();
        private float carryLimit;
        public Inventory(float cl)
        {
            carryLimit = cl;
        }
       
        public float GetWeight()
        {
            float w = 0;
            foreach(KeyValuePair<string, Item> entry in inventory)
            {
                w += entry.Value.GetWeight();
            }
            return w;
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
            Player player = p;
            Item item = i;
            if (i != null)
            {
                if (item.GetUses() <= 0)
                {
                    this.RemoveItem(i.GetName());
                    Console.WriteLine("player used up: " + i.GetName());
                }

                if (item.GetUses() == 1)
                {
                    i.Use(p);
                    this.RemoveItem(i.GetName());
                    Console.WriteLine("player used up: " + i.GetName());
                }
                
                if (item.GetUses() >= 2)
                {
                    i.SetUses(i.GetUses() - 1);
                    i.Use(p);
                }
            }
            else
            {
                Console.WriteLine("I dont have that item.");
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
