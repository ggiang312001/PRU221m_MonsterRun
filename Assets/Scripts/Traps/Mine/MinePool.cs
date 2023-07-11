using Assets.Scripts.Traps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePool : MonoBehaviour
{
    public GameObject Mine; // The prefab to be pooled.
    public int poolSize = 5; // The number of instances to be created initially.
    public List<GameObject> pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = TrapFactoryBuilding.Instance._factoryBuildings.GetComponent<TrapFactory>().CreateMineTrap();
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject obj in pool)
        {
            if (obj.transform.position.x < ScreenUtils.ScreenLeft)
            {
                obj.SetActive(false);
            }
        }
    }

    public GameObject GetObject()
    {
        if (pool.Count == 0)
        {
            Debug.LogWarning("Object pool is empty!");
            return null;
        }
        foreach (GameObject obj in pool)
        {
            if (obj.active == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
