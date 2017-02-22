using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventure
{    
	class Item
	{
        public string Name;
	
		public Item(string _name)
		{
            Name = _name;
		}

        public override string ToString()
        {
            //return base.ToString();)
            return Name;
        }
    }
}
