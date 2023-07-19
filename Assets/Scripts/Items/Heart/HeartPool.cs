using Assets.Scripts.Traps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPool : MonoBehaviour
{
    private static HeartPool instance = null;
    public GameObject Heart; // The prefab to be pooled.
    public int poolSize = 2; // The number of instances to be created initially.
    public List<GameObject> pool;
    public static HeartPool Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new HeartPool();
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
            GameObject obj = ItemFactoryBuilding.Instance._factoryBuildings.GetComponent<ItemFactory>().CreateHeart();
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
