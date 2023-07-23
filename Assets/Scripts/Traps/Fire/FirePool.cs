using Assets.Scripts.Traps;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirePool : MonoBehaviour
{
    private static FirePool instance = null;
    public GameObject Fire; // The prefab to be pooled.
    public int poolSize = 50; // The number of instances to be created initially.
    public List<GameObject> pool;

    // Start is called before the first frame update
    public static FirePool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new FirePool();
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
    }
    void Start()

    {
    
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = TrapFactoryBuilding.Instance._factoryBuildings.GetComponent<TrapFactory>().CreateFireTrap();
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
