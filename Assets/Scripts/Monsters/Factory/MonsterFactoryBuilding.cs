using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactoryBuilding : MonoBehaviour
{
    public GameObject FactoryBuilding;
    public Transform _factoryBuildings;

    private static MonsterFactoryBuilding instance = null;

    public static MonsterFactoryBuilding Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MonsterFactoryBuilding();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        AssignFactoryToBuilding();
    }

    private Transform CreateFactoryBuilding(GameObject Fac)
    {
        Transform newFactory = Instantiate(FactoryBuilding.transform, new Vector2(Fac.transform.position.x, Fac.transform.position.y), Quaternion.identity);
        return newFactory;
    }

    private void CreateFactory(GameObject Fac, out Transform factoryBuildingTransform)
    {
        if (_factoryBuildings == null)
        {
            // Create transforms for factory building
            _factoryBuildings = CreateFactoryBuilding(Fac);
            factoryBuildingTransform = _factoryBuildings;
        }
        else
        {
            // Reuse existing transforms
            factoryBuildingTransform = _factoryBuildings;
        }
    }
    public void AssignFactoryToBuilding()
    {
        Transform monsterTransform = null;
        CreateFactory(FactoryBuilding, out monsterTransform);

        if (monsterTransform == null)
        {
            Debug.Log("Could not initialize or load factory transform");
            return;
        }
        MonsterFactory Factory = monsterTransform.gameObject.AddComponent<MonsterFactory>();
        Factory.MonsterTransform = monsterTransform;
    }
}
