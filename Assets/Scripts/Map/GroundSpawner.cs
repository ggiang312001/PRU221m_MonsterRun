using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField]
    GameObject InitialGround;
    public GameObject Ground1, Ground2, Ground3;
    Timer SpawnTime;
    GameObject beforeGround;
    bool isFirst = true;
    private string[] groundTag = new string[] { "Ground", "Ground1", "Ground2" };

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
        if (SpawnTime.Finished)
        {
            SpawnGround();
            SpawnTime.Duration = 2f;
            SpawnTime.Run();

        }
}
    public void SpawnGround()
    {
        var randomTag = Random.Range(0, groundTag.Length);
        GameObject ground = ObjectPooling.SharedInstance.GetPooledObject(groundTag[randomTag]);

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
