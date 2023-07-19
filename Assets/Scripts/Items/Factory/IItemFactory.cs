using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IItemFactory : MonoBehaviour
{
    public Transform ItemTransform;
    public abstract GameObject CreateHeart();
    public abstract GameObject CreateSnow();
    public abstract GameObject CreateShield();
}
