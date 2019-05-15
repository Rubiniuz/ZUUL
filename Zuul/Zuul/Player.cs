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
        private int health = 100;
        private Room currentRoom;
        private bool isAlive = true;
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
            if (isAlive)
            {
                return "The Player is alive." + " The Player has: " + health.ToString() + " health remaining.";
            }

            return "The player is not alive";
        }
        public bool IsAlive()
        {
            if (health < 0)
            {
                isAlive = false;
            }
            else
            {
                isAlive = true;
            }
            return isAlive;
        }
    }
}
