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
        private Inventory inventory = new Inventory(100);
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

        public string Status()
        {
            if (IsAlive() == false)
            {
                return "The player is not alive";
            }
            return "The Player is alive." + " The Player has: " + health.ToString() + " health remaining. The Player has: " + (inventory.GetCarryLimit() - inventory.GetWeight()) + " weight remaining.";
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
        public float GetHealth()
        {
            return health;
        }
        public void SetHealth(int h)
        {
            health = h;
        }

        public Inventory GetInventory()
        {
            return this.inventory;
        }
    }
}
