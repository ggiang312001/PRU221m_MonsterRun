using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : IMonsterFactory
{
    public override GameObject CreateFighter()
    {
        var factoryTransformPosition = MonsterTransform.transform.position;
        GameObject prefab = Resources.Load<GameObject>("Monsters/Fighter");
        GameObject g = Instantiate(prefab, new Vector3(factoryTransformPosition.x, factoryTransformPosition.y, factoryTransformPosition.z), Quaternion.identity);
        return g;
    }

    public override GameObject CreateWizard()
    {
        var factoryTransformPosition = MonsterTransform.transform.position;
        GameObject prefab = Resources.Load<GameObject>("Monsters/Wizard");
        GameObject g = Instantiate(prefab, new Vector3(factoryTransformPosition.x, factoryTransformPosition.y, factoryTransformPosition.z), Quaternion.identity);
        return g;
    }
}
