using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterPool : MonoBehaviour
{
    private static FighterPool instance = null;
    public GameObject Fighter; // The prefab to be pooled.
    public int poolSize = 30; // The number of instances to be created initially.
    public List<GameObject> pool;

    public static FighterPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new FighterPool();
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
    // Start is called before the first frame update
    void Start()
    {
  
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = MonsterFactoryBuilding.Instance._factoryBuildings.GetComponent<MonsterFactory>().CreateFighter();
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
