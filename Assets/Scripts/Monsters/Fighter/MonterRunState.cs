using Assets.Scripts.ObjectSave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Monsters.Fighter
{
    public class MonterRunState : FighterState
    {
        public MonterRunState(FighterController fighter) : base(fighter)
        {
        }

        public override void EnterState()
        {
        }

        public override void UpdateState()
        {
           fighter.ChangeState(new FightState(fighter));
        }
    }
}
