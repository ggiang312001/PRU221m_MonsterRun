using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField]
    GameObject InitialGround;
    public ThornPool ThornPool;
    public MinePool MinePool;
    public FirePool FirePool;
    public HeartPool HeartPool;
    public SnowPool SnowPool;
    public FighterPool FighterPool;
    public WizardPool WizardPool;
    bool hasGround = true;
    Timer SpawnTime;
    GameObject beforeGround;
    bool isFirst = true;
    private GameObject currentGround;

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
        
        if (ContinueGame.isStart && isFirst)
        {
            int randomNum = Random.Range(1, 4);
            if (randomNum == 1)
            {
                currentGround = ObjectPooling.SharedInstance.GetPooledObject("Ground");
                currentGround.SetActive(true);
                currentGround.transform.position = new Vector3(InitialGround.transform.GetChild(3).transform.position.x + Random.Range(5, 5.5f), Random.Range(-1.35f, 2.5f), 0);
                currentGround.transform.rotation = Quaternion.identity;
                beforeGround = currentGround;
                SpawnTrap(currentGround, 14);
                SpawnItem(currentGround, 14);
                SpawnMonster(currentGround, 14);
            }
            if (randomNum == 2)
            {
                currentGround = ObjectPooling.SharedInstance.GetPooledObject("Ground2");
                currentGround.SetActive(true);
                currentGround.transform.position = new Vector3(InitialGround.transform.GetChild(3).transform.position.x + Random.Range(5, 5.5f), Random.Range(-1.35f, 2.5f), 0);
                currentGround.transform.rotation = Quaternion.identity;
                beforeGround = currentGround;
                SpawnTrap(currentGround, 18);
                SpawnItem(currentGround, 18);
                SpawnMonster(currentGround, 18);
            }
            if (randomNum == 3)
            {
                currentGround = ObjectPooling.SharedInstance.GetPooledObject("Ground3");
                currentGround.SetActive(true);
                currentGround.transform.position = new Vector3(InitialGround.transform.GetChild(3).transform.position.x + Random.Range(5, 5.5f), Random.Range(-1.35f, 2.5f), 0);
                currentGround.transform.rotation = Quaternion.identity;
                beforeGround = currentGround;
                SpawnTrap(currentGround, 10);
                SpawnItem(currentGround, 10);
                SpawnMonster(currentGround, 10);
            }
            isFirst = false;
            ContinueGame.isStart = false;
        }
        else if (ContinueGame.isContinue)
        {
            int randomNum = Random.Range(1, 4);
            if (randomNum == 1)
            {
                currentGround = ObjectPooling.SharedInstance.GetPooledObject("Ground");
                currentGround.SetActive(true);
                currentGround.transform.position = new Vector3(LoadGameSave.LastGround.transform.GetChild(3).transform.position.x + Random.Range(5, 5.5f), Random.Range(-1.35f, 2.5f), 0);
                currentGround.transform.rotation = Quaternion.identity;
                beforeGround = currentGround;
                SpawnTrap(currentGround, 14);
                SpawnItem(currentGround, 14);
                SpawnMonster(currentGround, 14);
            }
            if (randomNum == 2)
            {
                currentGround = ObjectPooling.SharedInstance.GetPooledObject("Ground2");
                currentGround.SetActive(true);
                currentGround.transform.position = new Vector3(LoadGameSave.LastGround.transform.GetChild(3).transform.position.x + Random.Range(5, 5.5f), Random.Range(-1.35f, 2.5f), 0);
                currentGround.transform.rotation = Quaternion.identity;
                beforeGround = currentGround;
                SpawnTrap(currentGround, 18);
                SpawnItem(currentGround, 18);
                SpawnMonster(currentGround, 18);
            }
            if (randomNum == 3)
            {
                currentGround = ObjectPooling.SharedInstance.GetPooledObject("Ground3");
                currentGround.SetActive(true);
                currentGround.transform.position = new Vector3(LoadGameSave.LastGround.transform.GetChild(3).transform.position.x + Random.Range(5, 5.5f), Random.Range(-1.35f, 2.5f), 0);
                currentGround.transform.rotation = Quaternion.identity;
                beforeGround = currentGround;
                SpawnTrap(currentGround, 10);
                SpawnItem(currentGround, 10);
                SpawnMonster(currentGround, 10);
            }
            ContinueGame.isContinue = false;
        }
        else
        {
            int randomNum = Random.Range(1, 4);
            int randomX = Random.Range(3, 5);
            if (randomNum == 1)
            {
                currentGround = ObjectPooling.SharedInstance.GetPooledObject("Ground");

                currentGround.SetActive(true);
                currentGround.transform.position = new Vector3(beforeGround.transform.GetChild(3).transform.position.x + Random.Range(5, 5.5f), Random.Range(-1.35f, 2.5f), 0);
                currentGround.transform.rotation = Quaternion.identity;
                beforeGround = currentGround;
                SpawnTrap(currentGround, 14);
                SpawnItem(currentGround, 14);
                SpawnMonster(currentGround, 14);
            }
            if (randomNum == 2)
            {
                currentGround = ObjectPooling.SharedInstance.GetPooledObject("Ground2");
                currentGround.SetActive(true);
                currentGround.transform.position = new Vector3(beforeGround.transform.GetChild(3).transform.position.x + Random.Range(5, 5.5f), Random.Range(-1.35f, 2.5f), 0);
                currentGround.transform.rotation = Quaternion.identity;
                beforeGround = currentGround;
                SpawnTrap(currentGround, 18);
                SpawnItem(currentGround, 18);
                SpawnMonster(currentGround, 18);
            }
            if (randomNum == 3)
            {
                currentGround = ObjectPooling.SharedInstance.GetPooledObject("Ground3");
                currentGround.SetActive(true);
                currentGround.transform.position = new Vector3(beforeGround.transform.GetChild(3).transform.position.x + Random.Range(5, 5.5f), Random.Range(-1.35f, 2.5f), 0);
                currentGround.transform.rotation = Quaternion.identity;
                beforeGround = currentGround;
                SpawnTrap(currentGround, 10);
                SpawnItem(currentGround, 10);
                SpawnMonster(currentGround, 10);
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
            //int randomChild = Random.Range(1, child);
            int randomChild = child - 1;
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
        if (appear == 1)
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
