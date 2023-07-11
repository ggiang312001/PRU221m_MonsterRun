    using Assets.Scripts.Traps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapFactoryBuilding : MonoBehaviour
{
    public GameObject FactoryBuilding;
    public Transform _factoryBuildings;

    private static TrapFactoryBuilding instance = null;

    public static TrapFactoryBuilding Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TrapFactoryBuilding();
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
        Transform trapTransform = null;
        CreateFactory( FactoryBuilding, out trapTransform);

        if (trapTransform == null)
        {
            Debug.Log("Could not initialize or load factory transform");
            return;
        }
        TrapFactory Factory = trapTransform.gameObject.AddComponent<TrapFactory>();
        Factory.TrapTransform = trapTransform;
    }
}
