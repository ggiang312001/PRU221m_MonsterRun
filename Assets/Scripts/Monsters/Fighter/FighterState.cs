using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Monsters.Fighter
{
    public abstract class FighterState
    {
        protected FighterController fighter;
        public FighterState(FighterController fighter)
        {
            this.fighter = fighter;
        }

        public virtual void EnterState() { }
        public virtual void UpdateState() { }
        public virtual void ExitState() { }
    }
}
