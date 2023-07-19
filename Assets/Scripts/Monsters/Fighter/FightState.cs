using Assets.Scripts.ObjectSave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Monsters.Fighter
{
    public class FightState : FighterState
    {
        public FightState(FighterController fighter) : base(fighter)
        {
        }
        public override void EnterState()
        {
            fighter.animator.SetTrigger("attack");
        }

        public override void UpdateState()
        {
            
        }


    }
}
