using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuul
{
    public class ResourceNode
    {
        private string name;
        private int amount;
        private string resourceType;
        public ResourceNode(string name, int amount, string resourceType)
        {
            this.name = name;
            this.amount = amount;
            this.resourceType = resourceType;
        }

        public string GetResourceType()
        {
            return resourceType;
        }
        public string GetName()
        {
            return name;
        }

        public int Amount()
        {
            return amount;
        }

        public int RemoveAmount(int a)
        {
            if (amount - a >= 0)
            {
                amount = 0;
                a -= amount;
                return a;
            }
            else
            {
                amount -= a;
                return a;
            }
        }
    }
}
