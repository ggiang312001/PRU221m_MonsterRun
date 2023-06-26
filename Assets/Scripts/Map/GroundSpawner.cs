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
                 
            }
            if (randomNum == 2)
            {
                beforeGround = Instantiate(Ground2, new Vector3(InitialGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0), Quaternion.identity);
            }
            if (randomNum == 3)
            {
                beforeGround = Instantiate(Ground3, new Vector3(InitialGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0), Quaternion.identity);
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

            }
            if (randomNum == 2)
            {
                beforeGround = Instantiate(Ground2, new Vector3(beforeGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0), Quaternion.identity);
            }
            if (randomNum == 3)
            {
                beforeGround = Instantiate(Ground3, new Vector3(beforeGround.transform.GetChild(3).transform.position.x + 5, Random.Range(-1.35f, 2.5f), 0), Quaternion.identity);
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
