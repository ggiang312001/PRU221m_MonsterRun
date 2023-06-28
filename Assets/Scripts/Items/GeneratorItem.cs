using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorItem : MonoBehaviour
{
    public HeartPool HeartPool;
    public SnowPool SnowPool;

    // Start is called before the first frame update
    void Start()
    {

    }

    float timeSpawner = 5.0f;
    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeSpawner)
        {
            SpawnItem();
            timer = 0;
        }
    }

    private void SpawnItem()
    {
        List<GameObject> listHearts = HeartPool.pool;
        List<GameObject> listSnows = SnowPool.pool;
        int random = UnityEngine.Random.Range(1, 3);
        if (random == 1)
        {
            int count = 0;
            foreach (GameObject obj in listHearts)
            {
                if (obj.active == false)
                {
                    count++;
                }
            }
            if (count != 0)
            {
                GameObject thorn = HeartPool.GetObject(); // Lấy trap từ pool
                thorn.transform.position = new Vector3(transform.position.x, 2, 0); // Set vị trí của trap
                thorn.SetActive(true); // Hiển thị trap lên màn hình
                count = 0;
            }
        }
        if (random == 2)
        {
            int count = 0;
            foreach (GameObject obj in listSnows)
            {
                if (obj.active == false)
                {
                    count++;
                }
            }
            if (count != 0)
            {
                GameObject woodBox = SnowPool.GetObject(); // Lấy trap từ pool
                woodBox.transform.position = new Vector3(transform.position.x, 3, 0); // Set vị trí của trap
                woodBox.SetActive(true); // Hiển thị trap lên màn hình
                count = 0;
            }
        }
    }
}
