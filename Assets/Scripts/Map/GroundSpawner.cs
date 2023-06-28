﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
   
    [SerializeField]
    GameObject InitialGround;
    public GameObject Ground1, Ground2, Ground3;
    public ThornPool ThornPool;
    public WoodBoxPool WoodBoxPool;
    public MinePool MinePool;
    public FirePool FirePool;
    bool hasGround = true;
    Timer SpawnTime;
    GameObject beforeGround;
    bool isFirst = true;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTime = gameObject.AddComponent<Timer>();
        SpawnTime.Duration = 2f;
        SpawnTime.Run();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!hasGround)
        //{
        if (SpawnTime.Finished)
        {
            SpawnGround();
            SpawnTime.Duration = 2f;
            SpawnTime.Run();
        }
            
        //    hasGround = true;
        //}
    }
    public void SpawnGround()
    {
        if(isFirst == true) {
            int randomNum = Random.Range(1, 4);
            if (randomNum == 1)
            {
               beforeGround = Instantiate(Ground1, new Vector3(InitialGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0), Quaternion.identity);
               SpawnTrap(beforeGround, 14);
            }
            if (randomNum == 2)
            {
                beforeGround = Instantiate(Ground2, new Vector3(InitialGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0), Quaternion.identity);
                SpawnTrap(beforeGround, 18);
            }
            if (randomNum == 3)
            {
                beforeGround = Instantiate(Ground3, new Vector3(InitialGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0), Quaternion.identity);
                SpawnTrap(beforeGround, 10);
            }
            isFirst= false;
        }
        else
        {
            int randomNum = Random.Range(1, 4);
            int randomX = Random.Range(3, 5);
            if (randomNum == 1)
            {
                beforeGround = Instantiate(Ground1, new Vector3(beforeGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0), Quaternion.identity);
                SpawnTrap(beforeGround, 14);
            }
            if (randomNum == 2)
            {
                beforeGround = Instantiate(Ground2, new Vector3(beforeGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0), Quaternion.identity);
                SpawnTrap(beforeGround, 18);
            }
            if (randomNum == 3)
            {
                beforeGround = Instantiate(Ground3, new Vector3(beforeGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0), Quaternion.identity);
                SpawnTrap(beforeGround, 10);
            }
        }
        
       
    }

    private void SpawnTrap(GameObject ground, int child)
    {
        List<GameObject> listThorns = ThornPool.pool;
        List<GameObject> listWoodBoxs = WoodBoxPool.pool;
        List<GameObject> listMines = MinePool.pool;
        List<GameObject> listFires = FirePool.pool;
        int randomNum = UnityEngine.Random.Range(2, 4);
        List<int> spawned = new List<int>();

        for(int i = 0; i < randomNum; i++)
        {
            int randomTrap = UnityEngine.Random.Range(1, 5);
            int randomChild;
            while (true)
            {
                randomChild = Random.Range(1, child);
                int count = 0;
                foreach(int temp in spawned)
                {
                   if(temp == randomChild)
                    {
                        count++;
                    } 
                }
                if(count == 0)
                {
                    spawned.Add(randomChild);
                    break;
                }
            }
           
            Vector3 position = ground.transform.GetChild(randomChild).transform.position;
            if (randomTrap == 1)
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
                    thorn.transform.position = new Vector3(position.x, position.y + 0.55f, 0); // Set vị trí của trap
                    thorn.SetActive(true); // Hiển thị trap lên màn hình
                    count = 0;
                }
                
            }
            if (randomTrap == 2)
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
                    woodBox.transform.position = new Vector3(position.x, position.y + 0.6f, 0); // Set vị trí của trap
                    woodBox.SetActive(true); // Hiển thị trap lên màn hình
                    count = 0;
                }
                
            }
            if (randomTrap == 3)
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
                    mine.transform.position = new Vector3(position.x, position.y + 0.55f, 0); // Set vị trí của trap
                    mine.SetActive(true); // Hiển thị trap lên màn hình
                    count = 0;
                }
                
            }
            if (randomTrap == 4)
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
                    fire.transform.position = new Vector3(position.x, position.y + 0.9f, 0); // Set vị trí của trap
                    fire.SetActive(true); // Hiển thị trap lên màn hình
                    count = 0;
                }
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasGround = false;
        }
    }
}
