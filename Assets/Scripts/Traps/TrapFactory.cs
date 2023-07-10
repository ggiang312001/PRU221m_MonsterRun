using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Traps
{
    public class TrapFactory : ITrapFactory
    {
        public GameObject Fire;
        public GameObject Mine;
        public GameObject Thorn;
        public override GameObject CreateFireTrap()
        {
            return Instantiate(Fire);
        }

        public override GameObject CreateMineTrap()
        {
            return Instantiate(Mine);
        }

        public override GameObject CreateThornTrap()
        {
            return Instantiate(Thorn);
        }
    }
}
