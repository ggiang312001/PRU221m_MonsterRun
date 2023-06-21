using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    private float x;
    private float y;
    private float z;
     // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsDestroyed())
        {
            transform.position = new Vector3(x, y, z);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x + offset.x, transform.position.y, transform.position.z);
            x= player.transform.position.x + offset.x;
            y= transform.position.y;
            z= transform.position.z;
        }
       
    }
}
