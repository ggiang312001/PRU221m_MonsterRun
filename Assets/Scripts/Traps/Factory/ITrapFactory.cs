using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ITrapFactory : MonoBehaviour
{
    public Transform TrapTransform;
    public abstract GameObject CreateFireTrap();
    public abstract GameObject CreateMineTrap();
    public abstract GameObject CreateThornTrap();
}
