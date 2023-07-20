using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectPoolItem
{
    public int amountToPool;
    public GameObject objectToPool;
    public bool shouldExpand;
}

public class ObjectPooling : MonoBehaviour
{
    public List<ObjectPoolItem> itemsToPool;
    public static ObjectPooling instance;
    public List<GameObject> pooledObjects;
    public List<GameObject> listGround;
    public List<GameObject> listGround2;
    public List<GameObject> listGround3;
    public static ObjectPooling Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ObjectPooling();
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
        CreatePooling();
        foreach (var item in pooledObjects)
        {
            if (item.tag.Equals("Ground"))
            {
                listGround.Add(item);
            }
            if (item.tag.Equals("Ground2"))
            {
                listGround2.Add(item);
            }
            if (item.tag.Equals("Ground3"))
            {
                listGround3.Add(item);
            }

        }

    }

    void Update()
    {
     
    }

    private void CreatePooling()
    {
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.transform.parent = transform;
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        if (tag.Equals("Ground"))
        {
            for (int i = 0; i < listGround.Count; i++)
            {
                if (!listGround[i].activeInHierarchy)
                {
                    return listGround[i];
                }
            }
        }
        if (tag.Equals("Ground2"))
        {
            for (int i = 0; i < listGround2.Count; i++)
            {
                if (!listGround2[i].activeInHierarchy)
                {
                    return listGround2[i];
                }
            }
        }
        if (tag.Equals("Ground3"))
        {
            for (int i = 0; i < listGround3.Count; i++)
            {
                if (!listGround3[i].activeInHierarchy)
                {
                    return listGround3[i];
                }
            }
        }
        //foreach (ObjectPoolItem item in itemsToPool)
        //{
        //    if (item.objectToPool.tag == tag)
        //    {
        //        if (item.shouldExpand)
        //        {
        //            GameObject obj = (GameObject)Instantiate(item.objectToPool);
        //            obj.transform.parent = transform;
        //            obj.SetActive(false);
        //            pooledObjects.Add(obj);
        //            return obj;
        //        }
        //    }
        //}
        return null;
    }
}
