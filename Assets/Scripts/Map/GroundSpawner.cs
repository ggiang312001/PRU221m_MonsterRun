using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
   
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
    Timer SpawnTime;
    GameObject beforeGround;
    bool isFirst = true;
    private GameObject currentGround;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTime = gameObject.AddComponent<Timer>();
        //SpawnTime.Duration = 2f;
        //SpawnTime.Run();
        InvokeRepeating("SpawnGround", 0, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        //if (!hasGround)
        //{
        if (SpawnTime.Finished)
        {
            //SpawnGround();
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
                 currentGround =  beforeGround = ObjectPooling.SharedInstance.GetPooledObject("Ground");
                if (beforeGround != null)
                {
                    beforeGround.SetActive(true);
                    if (currentGround.transform.tag == "Ground") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 10, currentGround.transform.position.y);
                    else if (currentGround.transform.tag == "Ground2") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 30, currentGround.transform.position.y);
                    else if (currentGround.transform.tag == "Ground2") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 15, currentGround.transform.position.y);
                    else beforeGround.transform.position = new Vector3(InitialGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0);
                    beforeGround.transform.rotation = Quaternion.identity;
                }


                SpawnTrap(beforeGround, 14);
               SpawnItem(beforeGround, 14);
                SpawnMonster(beforeGround, 14);
            }
            if (randomNum == 2)
            {
              currentGround=   beforeGround = ObjectPooling.SharedInstance.GetPooledObject("Ground2");
                if (beforeGround != null)
                {
                    beforeGround.SetActive(true);
                    if (currentGround.transform.tag == "Ground") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 10, currentGround.transform.position.y);
                    else if (currentGround.transform.tag == "Ground2") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 30, currentGround.transform.position.y);
                    else if (currentGround.transform.tag == "Ground2") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 15, currentGround.transform.position.y);
                    else beforeGround.transform.position = new Vector3(InitialGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0);
                    beforeGround.transform.rotation = Quaternion.identity;
                }
                SpawnTrap(beforeGround, 18);
                SpawnItem(beforeGround, 18);
                SpawnMonster(beforeGround, 18);
            }
            if (randomNum == 3)
            {
              currentGround =  beforeGround = ObjectPooling.SharedInstance.GetPooledObject("Ground3");
                if (beforeGround != null)
                    if (beforeGround != null)
                    {
                        beforeGround.SetActive(true);
                        if (currentGround.transform.tag == "Ground") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 10, currentGround.transform.position.y);
                        else if (currentGround.transform.tag == "Ground2") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 30, currentGround.transform.position.y);
                        else if (currentGround.transform.tag == "Ground2") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 15, currentGround.transform.position.y);
                        else beforeGround.transform.position = new Vector3(InitialGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0);
                        beforeGround.transform.rotation = Quaternion.identity;
                    }
                SpawnTrap(beforeGround, 10);
                SpawnItem(beforeGround, 10);
                SpawnMonster(beforeGround, 10);
            }
            isFirst= false;
        }
        else
        {
            int randomNum = Random.Range(1, 4);
            int randomX = Random.Range(3, 5);
            if (randomNum == 1)
            {
              currentGround =  beforeGround = ObjectPooling.SharedInstance.GetPooledObject("Ground");
                if (beforeGround != null)
                {
                    beforeGround.SetActive(true);
                    if (currentGround.transform.tag == "Ground") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 10, currentGround.transform.position.y);
                    else if (currentGround.transform.tag == "Ground2") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 30, currentGround.transform.position.y);
                    else if (currentGround.transform.tag == "Ground2") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 15, currentGround.transform.position.y);
                    else beforeGround.transform.position = new Vector3(InitialGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0);
                    beforeGround.transform.rotation = Quaternion.identity;
                }
                SpawnTrap(beforeGround, 14);
                SpawnItem(beforeGround, 14);
                SpawnMonster(beforeGround, 14);
            }
            if (randomNum == 2)
            {
               currentGround = beforeGround = ObjectPooling.SharedInstance.GetPooledObject("Ground2");
                if (beforeGround != null)
                {
                    beforeGround.SetActive(true);
                    if (currentGround.transform.tag == "Ground") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 10, currentGround.transform.position.y);
                    else if (currentGround.transform.tag == "Ground2") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 30, currentGround.transform.position.y);
                    else if (currentGround.transform.tag == "Ground2") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 15, currentGround.transform.position.y);
                    else beforeGround.transform.position = new Vector3(InitialGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0);
                    beforeGround.transform.rotation = Quaternion.identity;
                }
                SpawnTrap(beforeGround, 18);
                SpawnItem(beforeGround, 18);
                SpawnMonster(beforeGround, 18);
            }
            if (randomNum == 3)
            {
               currentGround = beforeGround = ObjectPooling.SharedInstance.GetPooledObject("Ground3");
                if (beforeGround != null)
                {
                    beforeGround.SetActive(true);
                    if (currentGround.transform.tag == "Ground") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 10, currentGround.transform.position.y);
                    else if (currentGround.transform.tag == "Ground2") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 30, currentGround.transform.position.y);
                    else if (currentGround.transform.tag == "Ground2") beforeGround.transform.position = new Vector3(currentGround.transform.position.x + 15, currentGround.transform.position.y);
                    else beforeGround.transform.position = new Vector3(InitialGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0);
                    beforeGround.transform.rotation = Quaternion.identity;
                }
                SpawnTrap(beforeGround, 10);
                SpawnItem(beforeGround, 10);
                SpawnMonster(beforeGround, 10);
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
            int randomChild = child-1;
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
