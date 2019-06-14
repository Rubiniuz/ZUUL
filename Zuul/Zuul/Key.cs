using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuulCS;

namespace Zuul
{
    class Key : Item
    {
        private string name;
        private string description;
        private float weight;
        private int uses;
        private int tier;
        public Key(string name, string description, int uses, float weight, int tier) : base(name, description, uses, weight)
        {
            this.name = name;
            this.description = description;
            this.uses = uses;
            this.weight = weight;
        }
        public override string GetUseDescription()
        {
            string useDescription = "";
            useDescription = "Key that is used to unlock a room. use the command unlock";
            return useDescription;
        }
        public void SetTier(int tier)
        {
            this.tier = tier;
        }
        public int GetTier()
        {
            return tier;
        }

        public override void Use(Player p)
        {
            Console.WriteLine(GetUseDescription());
        }

        public string Unlock(object o)
        {
            string returnstring = "";
            Room r;
            if (o is Room)
            {
                this.uses--;
                r = (Room)o;
                r.UnLockRoom();
                returnstring = "You unlocked: " + r + " with key";
                return returnstring;
            }
            else
            {
                string error = "cant use key on: " + o;
                return error;
            }
        }
    }
}
