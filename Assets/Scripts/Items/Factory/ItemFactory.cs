using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : IItemFactory
{
    public override GameObject CreateHeart()
    {
        var factoryTransformPosition = ItemTransform.transform.position;
        GameObject prefab = Resources.Load<GameObject>("Items/Heart");
        GameObject g = Instantiate(prefab, new Vector3(factoryTransformPosition.x, factoryTransformPosition.y, factoryTransformPosition.z), Quaternion.identity);
        return g;
    }

    public override GameObject CreateSnow()
    {
        var factoryTransformPosition = ItemTransform.transform.position;
        GameObject prefab = Resources.Load<GameObject>("Items/Snow");
        GameObject g = Instantiate(prefab, new Vector3(factoryTransformPosition.x, factoryTransformPosition.y, factoryTransformPosition.z), Quaternion.identity);
        return g;
    }
}
