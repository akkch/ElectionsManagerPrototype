using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectionsManagerPrototype.Model
{
    public class Vote
    {
        public bool Voted { get; private set; } = false;

        public ElectoralBodyPosition Position { get; private set; }

        public Vote(ElectoralBodyPosition position) 
        { 
            Position = position;
        }
    }
}
