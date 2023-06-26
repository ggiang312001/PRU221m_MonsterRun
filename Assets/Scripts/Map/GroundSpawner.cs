using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject InitialGround;
    public GameObject Ground1, Ground2, Ground3;
    bool hasGround = true;
    Timer SpawnTime;
    List<GameObject> groundPool;
    int poolSize = 10;
    int currentIndex = 0;
    GameObject beforeGround;
    bool isFirst = true;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTime = gameObject.AddComponent<Timer>();
        SpawnTime.Duration = 2f;
        SpawnTime.Run();

        // Khởi tạo Object Pool
        groundPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject ground = CreateGround();
            ground.SetActive(false);
            groundPool.Add(ground);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnTime.Finished)
        {
            SpawnGround();
            SpawnTime.Duration = 2f;
            SpawnTime.Run();
        }
    }

    public void SpawnGround()
    {
        // Lấy đối tượng Ground từ Object Pool
        GameObject ground = GetPooledGround();

        if (ground != null)
        {
            if (isFirst)
            {
                int randomNum = Random.Range(1, 4);
                switch (randomNum)
                {
                    case 1:
                        ground.transform.position = new Vector3(InitialGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0);
                        break;
                    case 2:
                        ground.transform.position = new Vector3(InitialGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0);
                        break;
                    case 3:
                        ground.transform.position = new Vector3(InitialGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0);
                        break;
                }

                isFirst = false;
            }
            else
            {
                int randomNum = Random.Range(1, 4);
                int randomX = Random.Range(3, 5);
                switch (randomNum)
                {
                    case 1:
                        ground.transform.position = new Vector3(beforeGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0);
                        break;
                    case 2:
                        ground.transform.position = new Vector3(beforeGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0);
                        break;
                    case 3:
                        ground.transform.position = new Vector3(beforeGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0);
                        break;
                }
            }

            // Kích hoạt đối tượng Ground
            ground.SetActive(true);

            // Lưu đối tượng Ground cho sử dụng sau này
            beforeGround = ground;
        }
    }

    private GameObject GetPooledGround()
    {
        // Lấy đối tượng Ground từ Object Pool
        GameObject ground = groundPool[currentIndex];
        currentIndex = (currentIndex + 1) % poolSize;

        // Kiểm tra xem đối tượng Ground đã được sử dụng hay chưa
        if (ground.activeInHierarchy)
        {
            // Tìm đối tượng Ground không được sử dụng
            for (int i = 0; i < poolSize; i++)
            {
                if (!groundPool[i].activeInHierarchy)
                {
                    ground = groundPool[i];
                    currentIndex = (i + 1) % poolSize;
                    break;
                }
            }
        }

        return ground;
    }

    private GameObject CreateGround()
    {
        int randomNum = Random.Range(1, 4);
        switch (randomNum)
        {
            case 1:
                return Instantiate(Ground1);
            case 2:
                return Instantiate(Ground2);
            case 3:
                return Instantiate(Ground3);
            default:
                return null;
        }
    }
}
