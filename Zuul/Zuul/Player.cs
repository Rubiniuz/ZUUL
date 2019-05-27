using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuulCS;

namespace Zuul
{
    public class Player
    {
        private List<Item> inventory = new List<Item>();
        private float carryLimit = 100;
        private float weight = 0;
        private int health = 100;
        private Room currentRoom;
        private bool isAlive;
        public Player()
        {
            
        }

        public void SetCurrentRoom(Room r)
        {
            this.currentRoom = r;
        }

        public Room GetCurrentRoom()
        {
            return this.currentRoom;
        }

        public void Heal(int h)
        {
            this.health += h;
        }

        public void Damage(int d)
        {
            this.health -= d;
        }

        public Item RemoveItem(string n)
        {
            Item item;
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].GetName() == n)
                {
                    item = inventory[i];
                    inventory.RemoveAt(i);
                    return item;
                }
            }
            return null;
        }
        public void AddItem(Item item)
        {
            inventory.Add(item);
        }
        public string GetInventory()
        {
            string inv = "";
            for (int i = 0; i < inventory.Count; i++)
            {
                inv += inventory[i].GetName() + ", ";
            }
            if (inv == "")
            {
                string empty = "The inventory is empty.";
                return empty;
            }
            return inv;
        }

        public string Status()
        {
            if (IsAlive() == false)
            {
                return "The player is not alive";
            }
            return "The Player is alive." + " The Player has: " + health.ToString() + " health remaining.";
        }
        public bool IsAlive()
        {
            if (health <= 0)
            {
                isAlive = false;
            }
            else
            {
                isAlive = true;
            }
            return isAlive;
        }

        public float GetWeight()
        {
            return weight;
        }
        public void AddWeight(float w)
        {
            weight += w;
        }
        public float GetCarryLimit()
        {
            return carryLimit;
        }
    }
}
