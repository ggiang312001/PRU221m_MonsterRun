using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GeneratorTrap : MonoBehaviour
{
    public ThornPool ThornPool;
    public WoodBoxPool WoodBoxPool;
    public MinePool MinePool;
    public FirePool FirePool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float timeSpawner = 5.0f;
    float count = 0;
    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeSpawner)
        {
            SpawnTrap();
            timer = 0;
        }
        count += Time.deltaTime;
        if (count >= 2 && (int)count % 2 == 0)
        {
            if (timeSpawner > 1.5)
            {
                timeSpawner -= 0.5f;
            }
            count = 0;
        }
    }

    private void SpawnTrap()
    {
        List<GameObject> listThorns = ThornPool.pool;
        List<GameObject> listWoodBoxs = WoodBoxPool.pool;
        List<GameObject> listMines = MinePool.pool;
        List<GameObject> listFires = FirePool.pool;
        int random = UnityEngine.Random.Range(1,5);
        if(random == 1)
        {
            int count = 0;
            foreach (GameObject obj in listThorns)
            {
                if (obj.active == false)
                {
                    count++;
                }
            }
            if (count != 0)
            {
                GameObject thorn = ThornPool.GetObject(); // Lấy trap từ pool
                thorn.transform.position = new Vector3(transform.position.x, 2,0); // Set vị trí của trap
                thorn.SetActive(true); // Hiển thị trap lên màn hình
                count = 0;
            }
        }
        if(random == 2)
        {
            int count = 0;
            foreach (GameObject obj in listWoodBoxs)
            {
                if (obj.active == false)
                {
                    count++;
                }
            }
            if (count != 0)
            {
                GameObject woodBox = WoodBoxPool.GetObject(); // Lấy trap từ pool
                woodBox.transform.position = new Vector3(transform.position.x, 3, 0); // Set vị trí của trap
                woodBox.SetActive(true); // Hiển thị trap lên màn hình
                count = 0;
            }
        }
        if(random == 3)
        {
            int count = 0;
            foreach (GameObject obj in listMines)
            {
                if (obj.active == false)
                {
                    count++;
                }
            }
            if (count != 0)
            {
                GameObject mine = MinePool.GetObject(); // Lấy trap từ pool
                mine.transform.position = new Vector3(transform.position.x, 3, 0); // Set vị trí của trap
                mine.SetActive(true); // Hiển thị trap lên màn hình
                count = 0;
            }
        }
        if(random == 4)
        {
            int count = 0;
            foreach (GameObject obj in listFires)
            {
                if (obj.active == false)
                {
                    count++;
                }
            }
            if (count != 0)
            {
                GameObject fire = FirePool.GetObject(); // Lấy trap từ pool
                fire.transform.position = new Vector3(transform.position.x, 3, 0); // Set vị trí của trap
                fire.SetActive(true); // Hiển thị trap lên màn hình
                count = 0;
            }
        }
    }
}
