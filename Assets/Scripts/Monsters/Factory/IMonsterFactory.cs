using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IMonsterFactory : MonoBehaviour
{
    public Transform MonsterTransform;
    public abstract GameObject CreateFighter();
    public abstract GameObject CreateWizard();
}
