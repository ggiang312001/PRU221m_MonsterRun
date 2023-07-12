using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField]
    GameObject InitialGround;
    public GameObject Ground1, Ground2, Ground3;
    public ThornPool ThornPool;
    public MinePool MinePool;
    public FirePool FirePool;
    public HeartPool HeartPool;
    public SnowPool SnowPool;
    public FighterPool FighterPool;
    public WizardPool WizardPool;
    bool hasGround = true;
    GameObject beforeGround;
    bool isFirst = true;
    private GameObject ground;
    private string[] groundTag = new string[] { "Ground", "SnowItem", "HUD"};
    private Transform currentGround;
    private int posX;
    // Start is called before the first frame update
    void Start()
    {
        isFirst = true;
        InvokeRepeating("SpawnGround", 1, 2);
    }

    // Update is called once per frame
  
    public void SpawnGround()
    {
        if (isFirst)
        {
            isFirst = false;
            ground = ObjectPooling.SharedInstance.GetPooledObject(groundTag[1]);
            ground.transform.position = spawnPoint.position;
            currentGround = ground.transform;
        }
        else
        {
            // Lấy đối tượng Ground từ Object Pool
            var randomTag = Random.Range(0, groundTag.Length);
            ground = ObjectPooling.SharedInstance.GetPooledObject(groundTag[randomTag]);

            if (ground != null)
            {

                var offset = Random.Range(-1, 2);
                if (currentGround.tag == groundTag[0] || currentGround.tag == groundTag[1]) posX = 21;
                else posX = 15;

                ground.transform.position = new Vector2(spawnPoint.position.x, spawnPoint.position.y);
                if (currentGround != null) ground.transform.position = new Vector3(currentGround.position.x + posX, spawnPoint.position.y + offset);
                currentGround = ground.transform;

                // Kích hoạt đối tượng Ground
                ground.SetActive(true);

                Debug.Log(currentGround.tag);
            }

        }
    }


private void SpawnMonster(GameObject ground, int child)
    {
        int appear = Random.Range(1, 1); // tỉ lệ xuất hiện quái
        if (appear == 1)
        {
            List<GameObject> listFighters = FighterPool.pool;
            List<GameObject> listWizard = WizardPool.pool;
            int randomChild = Random.Range(1, child);
            Vector3 position = ground.transform.GetChild(randomChild).transform.position;
            int random = UnityEngine.Random.Range(1, 3);
            if (random == 1)
            {
                int count = 0;
                foreach (GameObject obj in listWizard)
                {
                    if (obj.active == false)
                    {
                        count++;
                    }
                }
                if (count != 0)
                {
                    GameObject thorn = WizardPool.GetObject(); // Lấy trap từ pool
                    thorn.transform.position = new Vector3(position.x, position.y + 0.8f, 0); // Set vị trí của trap
                    thorn.SetActive(true); // Hiển thị trap lên màn hình
                    count = 0;
                }
            }

            if (random == 2)
            {
                int count = 0;
                foreach (GameObject obj in listFighters)
                {
                    if (obj.active == false)
                    {
                        count++;
                    }
                }
                if (count != 0)
                {
                    GameObject thorn = FighterPool.GetObject(); // Lấy trap từ pool
                    thorn.transform.position = new Vector3(position.x, position.y + 0.8f, 0); // Set vị trí của trap
                    thorn.SetActive(true); // Hiển thị trap lên màn hình
                    count = 0;
                }
            }
        }
    }

    private void SpawnItem(GameObject ground, int child)
    {
        int appear = Random.Range(1, 2);
        if(appear == 1)
        {
            List<GameObject> listHearts = HeartPool.pool;
            List<GameObject> listSnows = SnowPool.pool;
            int randomChild = Random.Range(1, child);
            Vector3 position = ground.transform.GetChild(randomChild).transform.position;
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
                    thorn.transform.position = new Vector3(position.x, Random.Range(position.y + 1f, position.y + 3f), 0); // Set vị trí của trap
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
                    woodBox.transform.position = new Vector3(position.x, Random.Range(position.y + 1f, position.y + 3f), 0); // Set vị trí của trap
                    woodBox.SetActive(true); // Hiển thị trap lên màn hình
                    count = 0;
                }
            }
        }
    }

    private void SpawnTrap(GameObject ground, int child)
    {
        List<GameObject> listThorns = ThornPool.pool;
        List<GameObject> listMines = MinePool.pool;
        List<GameObject> listFires = FirePool.pool;
        int randomNum = UnityEngine.Random.Range(2, 4);
        List<int> spawned = new List<int>();

        for (int i = 0; i < randomNum; i++)
        {
            int randomTrap = UnityEngine.Random.Range(1, 4);
            int randomChild;
            while (true)
            {
                randomChild = Random.Range(1, child);
                int count = 0;
                foreach (int temp in spawned)
                {
                    if (temp == randomChild)
                    {
                        count++;
                    }
                }
                if (count == 0)
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
            if (randomTrap == 3)
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
}
