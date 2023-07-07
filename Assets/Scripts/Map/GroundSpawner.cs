using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField] private Transform spawnPoint;

    [SerializeField]
    GameObject InitialGround;
    public GameObject Ground1, Ground2, Ground3, Ground4, Ground5;
    Timer SpawnTime;
    bool isFirst = true;
    private string[] groundTag = new string[] { "Ground", "Ground1", "Ground2","Ground3","Ground4" };
    private Transform currentGround;
    private int posX;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnGround", 2, 2);

    }

    // Update is called once per frame

    public void SpawnGround()
    {
        GameObject ground;
        if (isFirst) 
        {
            isFirst = !isFirst;
            ground = ObjectPooling.SharedInstance.GetPooledObject(groundTag[2]);
        }
        else 
        {
            // Lấy đối tượng Ground từ Object Pool
            var randomTag = Random.Range(0, groundTag.Length);
            ground = ObjectPooling.SharedInstance.GetPooledObject(groundTag[randomTag]);
        }


        if (ground != null)
        {
            
                var offset = Random.Range(1, 5);
                if (ground.tag == groundTag[0] || ground.tag == groundTag[1]) posX = 18;
                else posX = 10;

                ground.transform.position = new Vector2(spawnPoint.position.x, spawnPoint.position.y);
                if (currentGround != null) ground.transform.position = new Vector3(currentGround.position.x + posX, spawnPoint.position.y + offset);
                currentGround = ground.transform;
              
                // Kích hoạt đối tượng Ground
                ground.SetActive(true);
        }
    }
}
