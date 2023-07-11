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
        public override GameObject CreateFireTrap()
        {
            var factoryTransformPosition = TrapTransform.transform.position;
            GameObject prefab = Resources.Load<GameObject>("Traps/Fire");
            GameObject g = Instantiate(prefab, new Vector3(factoryTransformPosition.x, factoryTransformPosition.y, factoryTransformPosition.z), Quaternion.identity);
            return g;
        }

        public override GameObject CreateMineTrap()
        {
            var factoryTransformPosition = TrapTransform.transform.position;
            GameObject prefab = Resources.Load<GameObject>("Traps/Mine");
            GameObject g = Instantiate(prefab, new Vector3(factoryTransformPosition.x, factoryTransformPosition.y, factoryTransformPosition.z), Quaternion.identity);
            return g;
        }

        public override GameObject CreateThornTrap()
        {
            var factoryTransformPosition = TrapTransform.transform.position;
            GameObject prefab = Resources.Load<GameObject>("Traps/Thorn");
            GameObject g = Instantiate(prefab, new Vector3(factoryTransformPosition.x, factoryTransformPosition.y, factoryTransformPosition.z), Quaternion.identity);
            return g;
        }
    }
}
