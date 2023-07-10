using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirePool : MonoBehaviour
{
    public GameObject Fire; // The prefab to be pooled.
    public int poolSize = 5; // The number of instances to be created initially.
    public List<GameObject> pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
<<<<<<< Updated upstream
            //GameObject obj = Instantiate(Fire);
            GameObject obj = Transform[3].GetComponent<ITrapFactory>().CreateFireTrap();
=======
            GameObject obj = Instantiate(Fire);
            //GameObject obj = Transform[3].GetComponent<ITrapFactory>().CreateFireTrap();
>>>>>>> Stashed changes
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
