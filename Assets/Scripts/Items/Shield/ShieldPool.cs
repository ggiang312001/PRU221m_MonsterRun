using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPool : MonoBehaviour
{
    private static ShieldPool instance = null;
    public GameObject Shield; // The prefab to be pooled.
    public int poolSize = 20; // The number of instances to be created initially.
    public List<GameObject> pool;
    public static ShieldPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ShieldPool();
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
            GameObject obj = ItemFactoryBuilding.Instance._factoryBuildings.GetComponent<ItemFactory>().CreateShield();
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
