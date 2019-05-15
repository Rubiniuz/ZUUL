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
        private Room currentRoom;
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
    }
}
